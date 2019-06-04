using Evaluation.Data;
using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluation.Services
{
    public class QuestionList
    {
        private readonly EvaluationDBContext _context;

        public QuestionList(EvaluationDBContext context)
        {
            _context = context;
        }

        public List<Question> SendExam(int nrquestions, int time, int examDifficulty, int courseId)
        {
            List<Question> list = new List<Question>(nrquestions);
            int avgTime = time / nrquestions;
            if (examDifficulty == 5)
            {
                var easyQuestion = _context.Question.Where(q => q.Difficulty == 8 && q.CourseId == courseId).ToList().FirstOrDefault();
                var normalQuestions = _context.Question.Where(q => q.Difficulty == 9 && q.CourseId == courseId).ToList().Take(nrquestions - 2);
                var hardQuestion = _context.Question.Where(q => q.Difficulty == 10 && q.CourseId == courseId).ToList().FirstOrDefault();
                list.Add(easyQuestion);
                foreach (var i in normalQuestions)
                {
                    list.Add(i);
                }
                list.Add(hardQuestion);
            }
            else
            {
                var easyQuestion = _context.Question.Where(
                                            q => q.Difficulty == ((examDifficulty * 2) - 1) &&
                                            Enumerable.Range(avgTime - 3, avgTime + 3).Contains(q.Time) == true &&
                                            q.CourseId == courseId).ToList().FirstOrDefault();

                var normalQuestions = _context.Question.Where(
                                            q => q.Difficulty == (examDifficulty * 2) &&
                                            Enumerable.Range(avgTime - 3, avgTime + 3).Contains(q.Time) == true &&
                                            q.CourseId == courseId).ToList().Take(nrquestions - 2);

                var hardQuestion = _context.Question.Where(
                                            q => q.Difficulty == ((examDifficulty * 2) + 1) &&
                                            Enumerable.Range(avgTime - 3, avgTime + 3).Contains(q.Time) == true &&
                                            q.CourseId == courseId).ToList().FirstOrDefault();

                list.Add(easyQuestion);
                foreach (var i in normalQuestions)
                {
                    list.Add(i);
                }
                list.Add(hardQuestion);
            }

            if (list.Count != nrquestions)
            {
                for (var i = 0; i < nrquestions - list.Count; i++)
                {
                    list.Add(_context.Question.Where(
                                        q => Enumerable.Range((examDifficulty * 2) - 1, (examDifficulty * 2) + 1).Contains(q.Difficulty) == true &&
                                        q.CourseId == courseId).ToList().FirstOrDefault());
                }
            }
            return list;
        }
    }
}
