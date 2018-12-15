using Evaluation.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.Data
{
    public class EvaluationDBContext : DbContext
    {
        public EvaluationDBContext(DbContextOptions<EvaluationDBContext> options) : base(options)
        {
        }

        public EvaluationDBContext()
        {
        }

        public DbSet<Course> Courses;
        public DbSet<CourseStudent> CourseStudents;
        public DbSet<Exam> Exams;
        public DbSet<ExamQuestion> ExamQuestions;
        public DbSet<Feedback> Feedbacks;
        public DbSet<Profesor> Profesors;
        public DbSet<Question> Questions;
        public DbSet<Student> Students;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne( p => p.Profesor)
                .WithMany(c => c.Courses)
                .HasForeignKey( p => p.profesorId )
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exam>()
                .HasOne(p => p.Profesor)
                .WithMany(e => e.Exams)
                .HasForeignKey(p => p.profesorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(e => e.Exam)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(e => e.examId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasOne(p => p.Profesor)
                .WithMany(q => q.Questions)
                .HasForeignKey(p => p.profesorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseStudent>().HasKey(sc => new {sc.sId, sc.cId});

            modelBuilder.Entity<CourseStudent>()
                .HasOne(sc => sc.Student)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(sc => sc.sId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(sc => sc.cId)
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<ExamQuestion>().HasKey(eq => new { eq.eId, eq.qId });

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(e => e.Exam)
                .WithMany(eq => eq.ExamQuestions)
                .HasForeignKey(eq => eq.eId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(q => q.Question)
                .WithMany(eq => eq.ExamQuestions)
                .HasForeignKey(eq => eq.qId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Evaluation.Models.Exam> Exam { get; set; }

        public DbSet<Evaluation.Models.Student> Student { get; set; }
    }
        
}
