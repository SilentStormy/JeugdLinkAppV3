using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeugdLinkDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

           

            migrationBuilder.CreateTable(
                name: "Enrolledstudents",
                columns: table => new
                {
                    enrolledstudentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    
                    studentId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    courseid = table.Column<int>(type: "int", nullable: false),
                    enrollementdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolledstudents", x => x.enrolledstudentid);
                    table.ForeignKey(
                        name: "FK_Enrolledstudents_AspNetUsers_studentId",
                        column: x => x.studentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrolledstudents_Course_courseid",
                        column: x => x.courseid,
                        principalTable: "Course",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

          

            migrationBuilder.CreateIndex(
                name: "IX_Enrolledstudents_courseid",
                table: "Enrolledstudents",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolledstudents_studentId",
                table: "Enrolledstudents",
                column: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Enrolledstudents");

            
        }
    }
}
