﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluation.Data;
using Evaluation.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Evaluation.ViewModels;
using Evaluation.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace Evaluation.Controllers
{
    public class ExamsController : Controller
    {
        private readonly EvaluationDBContext _context;

        public ExamsController(EvaluationDBContext context)
        {
            _context = context;
        }

        // GET: Exams
        [Authorize(Roles = "Profesor")]
        public IActionResult Index(ExamCourse examCourse)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = _context.Exam.Where(m=> m.ApplicationUserId == userId)
                .Select(x => new ExamCourse
                {
                    examDate = x.examDate,
                    examDifficulty = x.examDifficulty,
                    Group = x.Group,
                    courseName = x.Course.courseName,
                    eId = x.eId
                });

            return View(query.ToList());
        }

        // GET: Exams/Details/5
        [Authorize(Roles = "Profesor")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = _context.StudExam.Where(e => e.EId == id)
                .Select(x => new StudGrades
                {
                    ApplicationUserId = x.ApplicationUserId,
                    Grade = x.Grade,
                    Group = x.Exam.Group,
                    IsSolved = x.IsSolved,
                    studExamId = x.StudExamId
                });

            return View(query.ToList());
        }

        [Authorize(Roles ="Profesor")]
        public IActionResult Grade(string id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var query = _context.StudAnswer.Where(e => e.ExamId == id)
                        .Select(x => new GradeExam
                        {
                            QuestionText = x.Question.Text,
                            CorrectAnswer = x.Question.Answer,
                            StudentAnswer = x.Answer
                        });
            return View(query.ToList());
        }




        // GET: Exams/Create
        [Authorize(Roles = "Profesor")]
        public ActionResult Create(int Id)
        {
            Exam examCourse = new Exam();

            var loggedUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = new SelectList(_context.Course.Where(c => c.ApplicationUserId == loggedUser).ToDictionary(us => us.cId, us => us.courseName), "Key", "Value");

            ViewBag.Exams = query;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
        public IActionResult Grade(GradeExam gradeExam)
        {
            var examId = RouteData.Values["id"];
            var GradeExam = _context.StudExam.Where(x => x.StudExamId == examId.ToString()).FirstOrDefault();
            var StudentGrade = Request.Form["grade1"].ToString();
            GradeExam.Grade = decimal.Parse(StudentGrade);

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = GradeExam.EId });
           
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
        public IActionResult Create([Bind("eId,nrQuestions,examTime,examDifficulty,Group,ApplicationUserId,CourseID,examDate")] Exam exam)
        {
            var list = new List<Question>();
            var questionGenerated = new Services.QuestionList(_context);
            list = questionGenerated.SendExam(exam.nrQuestions, exam.examTime, exam.examDifficulty, exam.CourseID);

            StudExam studExam = new StudExam();
            var studId = _context.ApplicationUser.Where(a => a.Group == exam.Group).Select(u => u.Id).ToList();

            var loggedUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                exam.ApplicationUserId = loggedUser;
                exam.examDate = DateTime.Now;
                _context.Add(exam);
                _context.SaveChanges();

                studExam.EId = exam.eId;
                studExam.IsSolved = false;
                for(int i=0; i<studId.Count; i++)
                {
                    studExam.ApplicationUserId = studId[i];
                    studExam.StudExamId = Guid.NewGuid().ToString();
                    _context.Add(studExam);
                    _context.SaveChanges();
                }
               
                return RedirectToAction("Index", "ExamQuestions");
            }
            return RedirectToAction("Index", "ExamQuestions");
        }



        // GET: Exams/Edit/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            var loggedUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", exam.ApplicationUserId);
            ViewData["CourseID"] = new SelectList(_context.Course, "cId", "courseName", exam.CourseID);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Profesor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eId,nrQuestions,examTime,examDifficulty,Group,ApplicationUserId,CourseID")] Exam exam)
        {
            if (id != exam.eId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.eId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", exam.ApplicationUserId);
            ViewData["CourseID"] = new SelectList(_context.Course, "cId", "courseName", exam.CourseID);
            return View(exam);
        }

        // GET: Exams/Delete/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .Include(e => e.ApplicationUser)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(m => m.eId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Profesor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _context.Exam.FindAsync(id);
            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.eId == id);
        }
    }
}
