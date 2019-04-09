using Evaluation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.Data
{
    public class EvaluationDBContext : IdentityDbContext<ApplicationUser>
    {
        public EvaluationDBContext(DbContextOptions<EvaluationDBContext> options) : base(options)
        {
        }

        public EvaluationDBContext()
        {
        }

        public DbSet<Course> Courses;
        //public DbSet<CourseStudent> CourseStudents;
        public DbSet<Exam> Exams;
        public DbSet<ExamQuestion> ExamQuestions;
        public DbSet<Feedback> Feedbacks;
       // public DbSet<Profesor> Profesors;
        public DbSet<Question> Questions;
        //public DbSet<Student> Students;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //One Prof can have many courses
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Courses)
                  .WithOne()
                  .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            });

            //One prof can have many exams
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Exams)
                  .WithOne()
                  .IsRequired()
.OnDelete(DeleteBehavior.Restrict);
            });


            //One exam can have many feedbacks
            modelBuilder.Entity<Feedback>()
                .HasOne(e => e.Exam)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(e => e.examId)
                .OnDelete(DeleteBehavior.Cascade);

            //One prof can have many questions created
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Questions)
                  .WithOne()
                  .IsRequired()
                                    .OnDelete(DeleteBehavior.Restrict);

            });


            /* One student can have many courses
             * One course can have many students
            modelBuilder.Entity<CourseStudent>().HasKey(sc => new {sc.ApplicationUser.Id, sc.cId});
            */
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Courses)
                  .WithOne()
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Course>(b =>
            {
                b.HasMany(e => e.ApplicationUsers)
                  .WithOne()
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            });

            

            /* One exam can have many questions
             * One question can appear in more exams*/

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

       // public DbSet<Evaluation.Models.Student> Student { get; set; }
    }
        
}
