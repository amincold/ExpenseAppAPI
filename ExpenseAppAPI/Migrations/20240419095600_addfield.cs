using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class addfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VPAuthentication",
                table: "VPAuthentication");

            migrationBuilder.RenameColumn(
                name: "updateDate",
                table: "VPAuthentication",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "VPAuthentication",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VPAuthentication",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "VPAuthentication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VPAuthentication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VPAuthentication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPAuthentication",
                table: "VPAuthentication",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VPAuthentication",
                table: "VPAuthentication");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VPAuthentication");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "VPAuthentication");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VPAuthentication");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VPAuthentication");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "VPAuthentication",
                newName: "updateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "VPAuthentication",
                newName: "createDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPAuthentication",
                table: "VPAuthentication",
                column: "Username");
        }
    }
}
