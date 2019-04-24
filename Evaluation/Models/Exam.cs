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

        [Range(1, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Group { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}