using System;
using System.Collections.Generic;
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

            /*

             var evaluationDBContext = _context.Exam.Include(e => e.ApplicationUser)
                                                .Where(m => m.ApplicationUserId == userId).ToList();*/

            return View(query.ToList());
        }


        // GET: Exams/Details/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Details(int? id)
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

        // GET: Exams/Create
        [Authorize(Roles = "Profesor")]
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CourseID"] = new SelectList(_context.Course, "cId", "courseName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Create([Bind("eId,nrQuestions,examTime,examDifficulty,Group,ApplicationUserId,CourseID,examDate")] Exam exam)
        {
            var loggedUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                exam.ApplicationUserId = loggedUser;
                exam.examDate = DateTime.Now;
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SendExam));
            }

            

            var examList = from c in _context.Course
                 join q in _context.Exams on c.cId equals q.eId
                 where c.ApplicationUserId == loggedUser
                 select c.courseName;

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", exam.ApplicationUserId);
            ViewData["CourseID"] = new SelectList(_context.Course, "cId", "courseName", examList);
            return View(exam);
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

        [Authorize(Roles = "Profesor")]
        public IActionResult SendExam(ExamQuestion examQuestion)
        {
            return View(examQuestion);
        }


        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.eId == id);
        }
    }
}
