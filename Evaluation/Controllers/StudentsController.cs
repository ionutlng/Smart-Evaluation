using Evaluation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using Evaluation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Evaluation.Models;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using System;

namespace Evaluation.Controllers
{
    public class StudentsController : Controller
    {

        private readonly EvaluationDBContext _context;

        public StudentsController(EvaluationDBContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Student")]
        [HttpGet]
        public ActionResult LogIn()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser applicationUser = new ApplicationUser();

            var group = _context.ApplicationUser.Where(a => a.Id == userId).FirstOrDefault();

            var query = _context.Exam.Where(m => m.Group == group.Group)
                .Select(x => new ExamCourse
                {
                    examDate = x.examDate,
                    examDifficulty = x.examDifficulty,
                    courseName = x.Course.courseName,
                    eId = x.eId
                }).ToList();

            for(int i = 0; i<query.Count; i++)
            {
                query[i].solved = IsExamSolved(query[i].eId);
            }
            
            return View(query);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = from q in _context.Question
                            join eq in _context.ExamQuestion on q.qId equals eq.qId
                            where eq.eId == id
                            select q;

            if (questions == null)
            {
                return NotFound();
            }
            return View(questions.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Details(StudAnswer studAnswer)
        {
            var examId = RouteData.Values["id"];
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            System.Collections.Generic.List<ExamQuestion> StudQuestionsList = _context.ExamQuestion.Where(aa => aa.eId == Convert.ToUInt32(examId)).ToList();

            string[] StudAnswerList = Request.Form["textarea3"].ToString().Split(new[] { ',' });

            var CurrentExam  = _context.StudExam.Where(a => a.EId == Convert.ToUInt32(examId) && a.ApplicationUserId == userId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                for(int i = 0; i < StudQuestionsList.Count; i++)
                {
                    studAnswer.AnswerId = Guid.NewGuid().ToString();
                    studAnswer.Answer = StudAnswerList[i];
                    studAnswer.QuestionId = StudQuestionsList[i].qId;
                    studAnswer.ExamId = CurrentExam.StudExamId;
                    CurrentExam.IsSolved = true;

                    _context.Add(studAnswer);
                    await _context.SaveChangesAsync();
                }
            }

            return Redirect("~/Students/LogIn");
        }

        public bool IsExamSolved(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentExam = _context.StudExam.Where(a => a.EId == id && a.ApplicationUserId == userId).FirstOrDefault();

            return CurrentExam.IsSolved == true ? true : false;
        }


        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            SignOut();
            return RedirectToAction("Login", "Students");
        }
    }
}
