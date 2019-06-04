using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Question
    {
        [Key] public int qId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(1200)]
        public string Text { get; set; }

        [Required]
        [StringLength(500)]
        public string Answer { get; set; }

        [Required]
        [Range(1, 10)]
        [Display (Prompt = "Between 1 and 10")]
        public int Difficulty { get; set; }

        [Required]
        [Range(1, 8)]
        [Display(Prompt = "Between 1 and 8")]
        public int Time { get; set; }

        public int CourseId{get;set;}
        public virtual Course Course { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; }

        public static implicit operator List<object>(Question v)
        {
            throw new NotImplementedException();
        }
    }
}