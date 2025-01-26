using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class modifyschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenses",
                table: "expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenseLists",
                table: "expenseLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenseDetails",
                table: "expenseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_changeRequestStatus",
                table: "changeRequestStatus");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "VPRole");

            migrationBuilder.RenameTable(
                name: "expenses",
                newName: "VPExpense");

            migrationBuilder.RenameTable(
                name: "expenseLists",
                newName: "VPExpenseList");

            migrationBuilder.RenameTable(
                name: "expenseDetails",
                newName: "VPExpenseDetail");

            migrationBuilder.RenameTable(
                name: "changeRequestStatus",
                newName: "VPChangeRequestStatus");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "VPRole",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "VPRole",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "VPExpense",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "VPExpenseDetail",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "VPChangeRequestStatus",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "VPChangeRequestStatus",
                newName: "ModifyDate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VPRole",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "VPRole",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VPRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VPRole",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VPExpense",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "VPExpense",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VPExpense",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VPExpense",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VPExpenseList",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "VPExpenseList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VPExpenseList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "VPExpenseList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VPExpenseDetail",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "VPExpenseDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VPExpenseDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VPExpenseDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VPChangeRequestStatus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "VPChangeRequestStatus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VPChangeRequestStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VPChangeRequestStatus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPRole",
                table: "VPRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPExpense",
                table: "VPExpense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPExpenseList",
                table: "VPExpenseList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPExpenseDetail",
                table: "VPExpenseDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VPChangeRequestStatus",
                table: "VPChangeRequestStatus",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VPRole",
                table: "VPRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VPExpenseList",
                table: "VPExpenseList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VPExpenseDetail",
                table: "VPExpenseDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VPExpense",
                table: "VPExpense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VPChangeRequestStatus",
                table: "VPChangeRequestStatus");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "VPRole");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VPRole");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VPRole");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "VPExpenseList");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VPExpenseList");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "VPExpenseList");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "VPExpenseDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VPExpenseDetail");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VPExpenseDetail");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "VPExpense");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VPExpense");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VPExpense");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "VPChangeRequestStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VPChangeRequestStatus");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VPChangeRequestStatus");

            migrationBuilder.RenameTable(
                name: "VPRole",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "VPExpenseList",
                newName: "expenseLists");

            migrationBuilder.RenameTable(
                name: "VPExpenseDetail",
                newName: "expenseDetails");

            migrationBuilder.RenameTable(
                name: "VPExpense",
                newName: "expenses");

            migrationBuilder.RenameTable(
                name: "VPChangeRequestStatus",
                newName: "changeRequestStatus");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Roles",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Roles",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "expenseDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "expenses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "changeRequestStatus",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "changeRequestStatus",
                newName: "createdAt");

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "Roles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "expenseLists",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "expenseDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "expenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "changeRequestStatus",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenseLists",
                table: "expenseLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenseDetails",
                table: "expenseDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenses",
                table: "expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_changeRequestStatus",
                table: "changeRequestStatus",
                column: "Id");
        }
    }
}
