using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personaldetails.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SignupDetails",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emppass = table.Column<int>(type: "int", nullable: false),
                    emp_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empphoneno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emprole = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    empaddr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empcity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    empstate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    empbg = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    empjoiningdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empdob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignupDetails", x => x.empid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignupDetails");
        }
    }
}
