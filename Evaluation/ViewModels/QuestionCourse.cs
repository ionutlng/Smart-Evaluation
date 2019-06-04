using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluation.ViewModels
{
    public class QuestionCourse
    {
        public string Text { get; set;}
        public string Answer { get; set; }
        public int Difficulty { get; set; }
        public int Time { get; set; }

        public int qId { get; set; }
        public string Course { get; internal set; }

        public List<Question> ExamList { get; set; }
    }
}
