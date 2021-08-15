using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseCore.Persistence.Migrations
{
    public partial class add_CaseAssignmentTypeDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAssignment_CaseAssignmentType_CaseAssignmentTypeId",
                table: "CaseAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseAssignmentType",
                table: "CaseAssignmentType");

            migrationBuilder.RenameTable(
                name: "CaseAssignmentType",
                newName: "CaseAssignmentTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseAssignmentTypes",
                table: "CaseAssignmentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAssignment_CaseAssignmentTypes_CaseAssignmentTypeId",
                table: "CaseAssignment",
                column: "CaseAssignmentTypeId",
                principalTable: "CaseAssignmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAssignment_CaseAssignmentTypes_CaseAssignmentTypeId",
                table: "CaseAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseAssignmentTypes",
                table: "CaseAssignmentTypes");

            migrationBuilder.RenameTable(
                name: "CaseAssignmentTypes",
                newName: "CaseAssignmentType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseAssignmentType",
                table: "CaseAssignmentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAssignment_CaseAssignmentType_CaseAssignmentTypeId",
                table: "CaseAssignment",
                column: "CaseAssignmentTypeId",
                principalTable: "CaseAssignmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
