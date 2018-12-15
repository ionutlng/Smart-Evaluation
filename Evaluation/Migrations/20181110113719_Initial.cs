using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    pId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.pId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    sId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    studUsername = table.Column<string>(maxLength: 30, nullable: false),
                    studPassword = table.Column<string>(maxLength: 18, nullable: false),
                    grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.sId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    cId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    courseName = table.Column<string>(nullable: false),
                    profesorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.cId);
                    table.ForeignKey(
                        name: "FK_Course_Profesor_profesorId",
                        column: x => x.profesorId,
                        principalTable: "Profesor",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    qId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 1200, nullable: false),
                    Answer = table.Column<string>(maxLength: 500, nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    profesorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.qId);
                    table.ForeignKey(
                        name: "FK_Question_Profesor_profesorId",
                        column: x => x.profesorId,
                        principalTable: "Profesor",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    sId = table.Column<int>(nullable: false),
                    cId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.sId, x.cId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_cId",
                        column: x => x.cId,
                        principalTable: "Course",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_sId",
                        column: x => x.sId,
                        principalTable: "Student",
                        principalColumn: "sId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    eId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nrQuestions = table.Column<int>(nullable: false),
                    examTime = table.Column<int>(nullable: false),
                    examDifficulty = table.Column<int>(nullable: false),
                    profesorId = table.Column<int>(nullable: false),
                    CoursecId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.eId);
                    table.ForeignKey(
                        name: "FK_Exam_Course_CoursecId",
                        column: x => x.CoursecId,
                        principalTable: "Course",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exam_Profesor_profesorId",
                        column: x => x.profesorId,
                        principalTable: "Profesor",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    qId = table.Column<int>(nullable: false),
                    eId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.eId, x.qId });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exam_eId",
                        column: x => x.eId,
                        principalTable: "Exam",
                        principalColumn: "eId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Question_qId",
                        column: x => x.qId,
                        principalTable: "Question",
                        principalColumn: "qId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    fId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 5000, nullable: false),
                    examId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.fId);
                    table.ForeignKey(
                        name: "FK_Feedback_Exam_examId",
                        column: x => x.examId,
                        principalTable: "Exam",
                        principalColumn: "eId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_profesorId",
                table: "Course",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_cId",
                table: "CourseStudent",
                column: "cId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CoursecId",
                table: "Exam",
                column: "CoursecId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_profesorId",
                table: "Exam",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_qId",
                table: "ExamQuestion",
                column: "qId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_examId",
                table: "Feedback",
                column: "examId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_profesorId",
                table: "Question",
                column: "profesorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
