using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Exam
    {
        [Key] public int eId { get; set; }

        [Required]
        [Range(6,60)]
        public int nrQuestions { get; set; }

        [Required]
        [Range(15,150)]
        public int examTime { get; set;}

        [Required]
        [Range(1,5)]
        public int examDifficulty { get; set;}

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}