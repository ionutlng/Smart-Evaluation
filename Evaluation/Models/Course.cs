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

        public int AuID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        //public ICollection<CourseStudent> CourseStudents { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}