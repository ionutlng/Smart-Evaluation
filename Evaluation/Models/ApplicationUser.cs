using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Range(1, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Group { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<StudExam> StudExams { get; set; }
    }
}
