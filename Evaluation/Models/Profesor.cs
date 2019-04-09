/*using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Profesor
    {
        [Key]
        public int pId { get; set; }

        [Required]
        [StringLength(30,ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public ICollection<Course> Courses { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}*/