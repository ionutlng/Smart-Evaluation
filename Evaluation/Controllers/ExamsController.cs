using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evaluation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluation.Models;

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
        public async Task<IActionResult> Index()
        {
            var evaluationDBContext = _context.Exam.Include(e => e.Profesor);
            return View(await evaluationDBContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .Include(e => e.Profesor)
                .FirstOrDefaultAsync(m => m.eId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["profesorId"] = new SelectList(_context.Set<Profesor>(), "pId", "Password");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eId,nrQuestions,examTime,examDifficulty,profesorId   ")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["profesorId"] = new SelectList(_context.Set<Profesor>(), "pId", "Password", exam.profesorId);
            return View(exam);
        }

        // GET: Exams/Edit/5
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
            ViewData["profesorId"] = new SelectList(_context.Set<Profesor>(), "pId", "Password", exam.profesorId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eId,nrQuestions,examTime,examDifficulty,profesorId")] Exam exam)
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
            ViewData["profesorId"] = new SelectList(_context.Set<Profesor>(), "pId", "Password", exam.profesorId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .Include(e => e.Profesor)
                .FirstOrDefaultAsync(m => m.eId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
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
