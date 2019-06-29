using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation.Models
{
    public class Exam
    {
        [Key] public int eId { get; set; }

        [Required]
        [Range(6,20)]
        [Display(Prompt =" Between 6 and 20")]
        public int nrQuestions { get; set; }

        [Required]
        [Range(30,150)]
        [Display(Prompt = " Between 30 and 120")]
        public int examTime { get; set;}

        [Required]
        [Range(1,5)]
        [Display(Prompt = " Between 1 and 5")]
        public int examDifficulty { get; set;}

        [DataType(DataType.Date)]
        public System.DateTime examDate { get; set; }


        [Range(1, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Group { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<StudExam> StudExams { get; set; }
    }
}