﻿// <auto-generated />
using System;
using Evaluation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Evaluation.Migrations
{
    [DbContext(typeof(EvaluationDBContext))]
    [Migration("20190409174041_UpdateUser")]
    partial class UpdateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evaluation.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("Group");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Evaluation.Models.Course", b =>
                {
                    b.Property<int>("cId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("courseName")
                        .IsRequired();

                    b.Property<int>("profesorId");

                    b.HasKey("cId");

                    b.HasIndex("profesorId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Evaluation.Models.CourseStudent", b =>
                {
                    b.Property<int>("sId");

                    b.Property<int>("cId");

                    b.HasKey("sId", "cId");

                    b.HasIndex("cId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("Evaluation.Models.Exam", b =>
                {
                    b.Property<int>("eId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoursecId");

                    b.Property<int>("examDifficulty");

                    b.Property<int>("examTime");

                    b.Property<int>("nrQuestions");

                    b.Property<int>("profesorId");

                    b.HasKey("eId");

                    b.HasIndex("CoursecId");

                    b.HasIndex("profesorId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("Evaluation.Models.ExamQuestion", b =>
                {
                    b.Property<int>("eId");

                    b.Property<int>("qId");

                    b.HasKey("eId", "qId");

                    b.HasIndex("qId");

                    b.ToTable("ExamQuestion");
                });

            modelBuilder.Entity("Evaluation.Models.Feedback", b =>
                {
                    b.Property<int>("fId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<int>("examId");

                    b.HasKey("fId");

                    b.HasIndex("examId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Evaluation.Models.Profesor", b =>
                {
                    b.Property<int>("pId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("pId");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("Evaluation.Models.Question", b =>
                {
                    b.Property<int>("qId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("Difficulty");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1200);

                    b.Property<int>("Time");

                    b.Property<int>("profesorId");

                    b.HasKey("qId");

                    b.HasIndex("profesorId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Evaluation.Models.Student", b =>
                {
                    b.Property<int>("sId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("studPassword")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("studUsername")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("sId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Evaluation.Models.Course", b =>
                {
                    b.HasOne("Evaluation.Models.Profesor", "Profesor")
                        .WithMany("Courses")
                        .HasForeignKey("profesorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Evaluation.Models.CourseStudent", b =>
                {
                    b.HasOne("Evaluation.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("cId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Evaluation.Models.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("sId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Evaluation.Models.Exam", b =>
                {
                    b.HasOne("Evaluation.Models.Course")
                        .WithMany("Exams")
                        .HasForeignKey("CoursecId");

                    b.HasOne("Evaluation.Models.Profesor", "Profesor")
                        .WithMany("Exams")
                        .HasForeignKey("profesorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Evaluation.Models.ExamQuestion", b =>
                {
                    b.HasOne("Evaluation.Models.Exam", "Exam")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("eId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Evaluation.Models.Question", "Question")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("qId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Evaluation.Models.Feedback", b =>
                {
                    b.HasOne("Evaluation.Models.Exam", "Exam")
                        .WithMany("Feedbacks")
                        .HasForeignKey("examId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Evaluation.Models.Question", b =>
                {
                    b.HasOne("Evaluation.Models.Profesor", "Profesor")
                        .WithMany("Questions")
                        .HasForeignKey("profesorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Evaluation.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Evaluation.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Evaluation.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Evaluation.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
