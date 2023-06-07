using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Sollution.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    EmployeeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPresent = table.Column<int>(type: "int", nullable: false),
                    TotalAbsent = table.Column<int>(type: "int", nullable: false),
                    TotalOffday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.EmployeeName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
