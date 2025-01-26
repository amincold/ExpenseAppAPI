using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class renametable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_authentications",
                table: "authentications");

            migrationBuilder.RenameTable(
                name: "authentications",
                newName: "VPAuthentication");

            migrationBuilder.AlterColumn<string>(
                name: "Manager_Username",
                table: "VPAuthentication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPAuthentication",
                table: "VPAuthentication",
                column: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VPAuthentication",
                table: "VPAuthentication");

            migrationBuilder.RenameTable(
                name: "VPAuthentication",
                newName: "authentications");

            migrationBuilder.AlterColumn<string>(
                name: "Manager_Username",
                table: "authentications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_authentications",
                table: "authentications",
                column: "Username");
        }
    }
}
