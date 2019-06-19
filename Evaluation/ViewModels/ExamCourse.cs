using System;

namespace Evaluation.ViewModels
{
    public class ExamCourse
    {
        public DateTime examDate { get; set; }
        public string courseName { get; set; }
        public int Time { get; set; }
        public int examDifficulty { get; set; }
        public int? Group { get; set; }

        public bool solved { get; set; }

        public int eId { get; set; }
    }
}
