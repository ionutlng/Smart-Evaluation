using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Feedback
    {
        [Key]
        public int fId { get; set; }

        [Required]
        [StringLength(5000)]
        public string Text { get; set; }

        public int examId { get; set; }
        public Exam Exam { get; set; }
    }
}