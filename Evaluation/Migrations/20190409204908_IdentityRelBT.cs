using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluation.Migrations
{
    public partial class IdentityRelBT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Profesor_profesorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Profesor_profesorId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Profesor_profesorId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Question_profesorId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exam_profesorId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Course_profesorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "profesorId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "profesorId",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "profesorId",
                table: "Course",
                newName: "AuID");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Question",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Exam",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Exam",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Course",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoursecId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationUserId1",
                table: "Question",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ApplicationUserId",
                table: "Exam",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ApplicationUserId1",
                table: "Exam",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ApplicationUserId",
                table: "Course",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ApplicationUserId1",
                table: "Course",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CoursecId",
                table: "AspNetUsers",
                column: "CoursecId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Course_CoursecId",
                table: "AspNetUsers",
                column: "CoursecId",
                principalTable: "Course",
                principalColumn: "cId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_ApplicationUserId",
                table: "Course",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_ApplicationUserId1",
                table: "Course",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId1",
                table: "Exam",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict  );

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId1",
                table: "Question",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Course_CoursecId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_ApplicationUserId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_ApplicationUserId1",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId1",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId1",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApplicationUserId1",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ApplicationUserId1",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Course_ApplicationUserId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ApplicationUserId1",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CoursecId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CoursecId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AuID",
                table: "Course",
                newName: "profesorId");

            migrationBuilder.AddColumn<int>(
                name: "profesorId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "profesorId",
                table: "Exam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    pId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(maxLength: 18, nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: false)
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
                    studPassword = table.Column<string>(maxLength: 500, nullable: false),
                    studUsername = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.sId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Question_profesorId",
                table: "Question",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_profesorId",
                table: "Exam",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_profesorId",
                table: "Course",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_cId",
                table: "CourseStudent",
                column: "cId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Profesor_profesorId",
                table: "Course",
                column: "profesorId",
                principalTable: "Profesor",
                principalColumn: "pId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Profesor_profesorId",
                table: "Exam",
                column: "profesorId",
                principalTable: "Profesor",
                principalColumn: "pId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Profesor_profesorId",
                table: "Question",
                column: "profesorId",
                principalTable: "Profesor",
                principalColumn: "pId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
