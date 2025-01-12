using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeugdLinkDAL.Migrations
{
    /// <inheritdoc />
    public partial class addEnrolledstudentToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolledstudents_AspNetUsers_studentId",
                table: "Enrolledstudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolledstudents_Course_courseid",
                table: "Enrolledstudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolledstudents",
                table: "Enrolledstudents");

            migrationBuilder.RenameTable(
                name: "Enrolledstudents",
                newName: "Enrolledstudent");

            migrationBuilder.RenameIndex(
                name: "IX_Enrolledstudents_studentId",
                table: "Enrolledstudent",
                newName: "IX_Enrolledstudent_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrolledstudents_courseid",
                table: "Enrolledstudent",
                newName: "IX_Enrolledstudent_courseid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolledstudent",
                table: "Enrolledstudent",
                column: "enrolledstudentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolledstudent_AspNetUsers_studentId",
                table: "Enrolledstudent",
                column: "studentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolledstudent_Course_courseid",
                table: "Enrolledstudent",
                column: "courseid",
                principalTable: "Course",
                principalColumn: "courseid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolledstudent_AspNetUsers_studentId",
                table: "Enrolledstudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolledstudent_Course_courseid",
                table: "Enrolledstudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolledstudent",
                table: "Enrolledstudent");

            migrationBuilder.RenameTable(
                name: "Enrolledstudent",
                newName: "Enrolledstudents");

            migrationBuilder.RenameIndex(
                name: "IX_Enrolledstudent_studentId",
                table: "Enrolledstudents",
                newName: "IX_Enrolledstudents_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrolledstudent_courseid",
                table: "Enrolledstudents",
                newName: "IX_Enrolledstudents_courseid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolledstudents",
                table: "Enrolledstudents",
                column: "enrolledstudentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolledstudents_AspNetUsers_studentId",
                table: "Enrolledstudents",
                column: "studentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolledstudents_Course_courseid",
                table: "Enrolledstudents",
                column: "courseid",
                principalTable: "Course",
                principalColumn: "courseid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
