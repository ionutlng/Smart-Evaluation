﻿using Evaluation.Models;
using Evaluation.ViewModels;
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
        public DbSet<Exam> Exams;
        public DbSet<ExamQuestion> ExamQuestions;
        public DbSet<Feedback> Feedbacks;
        public DbSet<Question> Questions;
        public DbSet<ApplicationUser> ApplicationUsers;
        public DbQuery<ExamCourse> ExamCourses;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One Prof can have many courses
            modelBuilder.Entity<Course>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(c => c.Courses)
                .HasForeignKey(f => f.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            //On course can have many questions
            modelBuilder.Entity<Question>()
                .HasOne(c => c.Course)
                .WithMany(q => q.Questions)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //One course can have many exams
            modelBuilder.Entity<Exam>()
               .HasOne(a => a.Course)
               .WithMany(e => e.Exams)
               .HasForeignKey(f => f.CourseID)
               .OnDelete(DeleteBehavior.Cascade);
           

            //One exam can have many feedbacks
            modelBuilder.Entity<Feedback>()
                .HasOne(e => e.Exam)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(e => e.examId)
                .OnDelete(DeleteBehavior.Cascade);
          

            // One exam can have many questions
            // * One question can appear in more exams

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

        //public DbSet<StudAnswer> Answer { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ExamQuestion> ExamQuestion { get; set; }
        public DbSet<StudExam> StudExam { get; set; }
        public DbSet<StudAnswer> StudAnswer { get; set; }
    }

}
