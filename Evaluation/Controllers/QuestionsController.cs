using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluation.Data;
using Evaluation.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var evaluationDBContext = _context.Question.Include(q => q.ApplicationUser)
                                                .Where(m => m.ApplicationUserId == userId).ToListAsync();

            return View(await evaluationDBContext);
        }

        // GET: Questions/Details/5
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Details(int? id)
        {
           var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.ApplicationUser)
                .FirstOrDefaultAsync(m => m.qId == id && m.ApplicationUserId == userId );
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Profesor")]
        public async Task<IActionResult> Create([Bind("qId,Text,Answer,Difficulty,Time")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", question.ApplicationUserId);
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", question.ApplicationUserId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> Edit(int id, [Bind("qId,Text,Answer,Difficulty,Time,ApplicationUserId")] Question question)
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", question.ApplicationUserId);
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
                .Include(q => q.ApplicationUser)
                .FirstOrDefaultAsync(m => m.qId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Profesor")]
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
