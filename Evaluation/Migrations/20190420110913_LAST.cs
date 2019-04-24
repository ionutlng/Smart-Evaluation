using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluation.Migrations
{
    public partial class LAST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_CoursecId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exam_CoursecId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "CoursecId",
                table: "Exam",
                newName: "Group");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Exam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Question_CourseId",
                table: "Question",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CourseID",
                table: "Exam",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_CourseID",
                table: "Exam",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "cId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "cId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_CourseID",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_CourseId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exam_CourseID",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "Group",
                table: "Exam",
                newName: "CoursecId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Question",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.ApplicationUserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CoursecId",
                table: "Exam",
                column: "CoursecId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_ApplicationUserId",
                table: "Exam",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_CoursecId",
                table: "Exam",
                column: "CoursecId",
                principalTable: "Course",
                principalColumn: "cId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
