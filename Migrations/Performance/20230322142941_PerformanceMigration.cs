using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personaldetails.Migrations.Performance
{
    /// <inheritdoc />
    public partial class PerformanceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "performancedetails",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_lead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_mem1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_mem2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_mem3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_performancedetails", x => x.empid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "performancedetails");
        }
    }
}
