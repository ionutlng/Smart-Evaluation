using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Evaluation.Models
{
    public class Course
    {
        [Key]
        public int cId { get; set; }
        [Required]
        public string courseName { get; set; }

        
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}