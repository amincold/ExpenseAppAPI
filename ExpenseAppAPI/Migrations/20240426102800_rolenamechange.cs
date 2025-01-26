using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class rolenamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "roleName",
                table: "VPRole",
                newName: "RoleName");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "VPRole",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "VPRole",
                newName: "roleName");

            migrationBuilder.AlterColumn<string>(
                name: "roleName",
                table: "VPRole",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
