using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class addstatuscode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusCode",
                table: "VPChangeRequestStatus",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusCode",
                table: "VPChangeRequestStatus");
        }
    }
}
