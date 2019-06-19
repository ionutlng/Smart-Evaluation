using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluation.Data;
using Evaluation.Models;
using System.Security.Claims;
using Evaluation.ViewModels;

namespace Evaluation.Controllers
{
    public class ExamQuestionsController : Controller
    {
        private readonly EvaluationDBContext _context;

        public ExamQuestionsController(EvaluationDBContext context)
        {
            _context = context;
        }

        // GET: ExamQuestions
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exam = _context.Exam.Where(a => a.ApplicationUserId == userId).Last();

            var list = new List<Question>();
            var questionGenerated = new Services.QuestionList(_context);
            list = questionGenerated.SendExam(exam.nrQuestions, exam.examTime, exam.examDifficulty, exam.CourseID).ToList();

            ExamQuestion examQuestion = new ExamQuestion();
            examQuestion.eId = exam.eId;

            for(int i = 0; i<list.Count; i++)
            {
                examQuestion.qId = list[i].qId;
                _context.Add(examQuestion);
                _context.SaveChanges();
            }
            return View(list);

        }

        // GET: ExamQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestion
                .Include(e => e.Exam)
                .Include(e => e.Question)
                .FirstOrDefaultAsync(m => m.eId == id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // GET: ExamQuestions/Create
        public IActionResult Create()
        {
           return Redirect("~/Profesor/Index");
        }

        // POST: ExamQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("qId,eId")] ExamQuestion examQuestion)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(examQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eId"] = new SelectList(_context.Exam, "eId", "eId", examQuestion.eId);
            ViewData["qId"] = new SelectList(_context.Question, "qId", "qId", examQuestion.qId);
            return View(examQuestion);
        }

        // GET: ExamQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestion.FindAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }
            ViewData["eId"] = new SelectList(_context.Exam, "eId", "eId", examQuestion.eId);
            ViewData["qId"] = new SelectList(_context.Question, "qId", "qId", examQuestion.qId);
            return View(examQuestion);
        }

        // POST: ExamQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("qId,eId")] ExamQuestion examQuestion)
        {
            if (id != examQuestion.eId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamQuestionExists(examQuestion.eId))
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
            ViewData["eId"] = new SelectList(_context.Exam, "eId", "eId", examQuestion.eId);
            ViewData["qId"] = new SelectList(_context.Question, "qId", "qId", examQuestion.qId);
            return View(examQuestion);
        }

        // GET: ExamQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestion
                .Include(e => e.Exam)
                .Include(e => e.Question)
                .FirstOrDefaultAsync(m => m.eId == id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // POST: ExamQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examQuestion = await _context.ExamQuestion.FindAsync(id);
            _context.ExamQuestion.Remove(examQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamQuestionExists(int id)
        {
            return _context.ExamQuestion.Any(e => e.eId == id);
        }
    }
}
