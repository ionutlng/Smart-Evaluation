﻿using System;
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
    public class QuestionsController : Controller
    {
        private readonly EvaluationDBContext _context;

        public QuestionsController(EvaluationDBContext context)
        {
            _context = context;
        }

        // GET: Questions
        [Authorize(Roles = "Profesor")]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = _context.Question.Where(m => m.Course.ApplicationUserId == userId)
                .Select(x => new QuestionCourse
                {
                    Text = x.Text,
                    Answer = x.Answer,
                    Difficulty = x.Difficulty,
                    Time = x.Time,
                    Course = x.Course.courseName,
                    qId = x.qId
                });

            return View(query.ToList());

        }

        // GET: Questions/Details/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.Course)
                .FirstOrDefaultAsync(m => m.qId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        [Authorize(Roles = "Profesor")]
        public IActionResult Create()
        {
            var loggedUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = new SelectList(_context.Course.Where(c => c.ApplicationUserId == loggedUser).ToDictionary(us => us.cId, us => us.courseName), "Key", "Value");

            ViewBag.Questions = query;

            return View();
           
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Create([Bind("qId,Text,Answer,Difficulty,Time,CourseId")] Question question)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var loggedUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var coursesList = from c in _context.Course
                              join q in _context.Question on c.cId equals q.CourseId
                              where c.ApplicationUserId == loggedUser
                              select c.courseName;

            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "cId", "courseName", coursesList.FirstOrDefault());
            return View(question);
        }

        // GET: Questions/Edit/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "cId", "courseName", question.CourseId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Edit(int id, [Bind("qId,Text,Answer,Difficulty,Time,CourseId")] Question question)
        {
            if (id != question.qId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.qId))
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
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "cId", "courseName", question.CourseId);
            return View(question);
        }

        // GET: Questions/Delete/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.Course)
                .FirstOrDefaultAsync(m => m.qId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Profesor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.qId == id);
        }
    }
}
