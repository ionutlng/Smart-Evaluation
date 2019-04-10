using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluation.Migrations
{
    public partial class ASPUserRELTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Profesor_profesorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Course_cId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Student_sId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Profesor_profesorId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Profesor_profesorId",
                table: "Question");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Course_profesorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "profesorId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "profesorId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "sId",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "profesorId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "cId",
                table: "CourseStudent",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_cId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Exam",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CourseStudent",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "ApplicationUserId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ApplicationUserId",
                table: "Exam",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ApplicationUserId",
                table: "Course",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_ApplicationUserId",
                table: "Course",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_AspNetUsers_ApplicationUserId",
                table: "CourseStudent",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Course_CourseId",
                table: "CourseStudent",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "cId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_ApplicationUserId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_AspNetUsers_ApplicationUserId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Course_CourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Course_ApplicationUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseStudent",
                newName: "cId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_cId");

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

            migrationBuilder.AddColumn<int>(
                name: "sId",
                table: "CourseStudent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "profesorId",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "sId", "cId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Profesor_profesorId",
                table: "Course",
                column: "profesorId",
                principalTable: "Profesor",
                principalColumn: "pId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Course_cId",
                table: "CourseStudent",
                column: "cId",
                principalTable: "Course",
                principalColumn: "cId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Student_sId",
                table: "CourseStudent",
                column: "sId",
                principalTable: "Student",
                principalColumn: "sId",
                onDelete: ReferentialAction.Restrict);

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
