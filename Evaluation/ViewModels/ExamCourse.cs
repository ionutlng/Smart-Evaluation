using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluation.ViewModels
{
    public class ExamCourse
    {
        public DateTime examDate { get; set; }
        public string courseName { get; set; }
        public int examDifficulty { get; set; }
        public int? Group { get; set; }

        public int eId { get; set; }
    }
}
