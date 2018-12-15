using System.Collections;
using Microsoft.EntityFrameworkCore;
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

        public int profesorId { get; set; }
        public Profesor Profesor { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}