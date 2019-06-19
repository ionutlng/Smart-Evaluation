using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public partial class StudExam
    {
        [Key]
        public string StudExamId { get; set; }

        public string ApplicationUserId { get; set; }
        public int EId { get; set; }
        public bool IsSolved { get; set; }
        public decimal? Grade { get; set; }
    }
}
