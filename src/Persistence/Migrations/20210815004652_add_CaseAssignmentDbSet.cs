using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseCore.Persistence.Migrations
{
    public partial class add_CaseAssignmentDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAssignment_CaseAssignmentTypes_CaseAssignmentTypeId",
                table: "CaseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAssignment_Cases_CaseId",
                table: "CaseAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseAssignment",
                table: "CaseAssignment");

            migrationBuilder.RenameTable(
                name: "CaseAssignment",
                newName: "CaseAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_CaseAssignment_CaseId",
                table: "CaseAssignments",
                newName: "IX_CaseAssignments_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseAssignment_CaseAssignmentTypeId",
                table: "CaseAssignments",
                newName: "IX_CaseAssignments_CaseAssignmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseAssignments",
                table: "CaseAssignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAssignments_CaseAssignmentTypes_CaseAssignmentTypeId",
                table: "CaseAssignments",
                column: "CaseAssignmentTypeId",
                principalTable: "CaseAssignmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAssignments_Cases_CaseId",
                table: "CaseAssignments",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAssignments_CaseAssignmentTypes_CaseAssignmentTypeId",
                table: "CaseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAssignments_Cases_CaseId",
                table: "CaseAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseAssignments",
                table: "CaseAssignments");

            migrationBuilder.RenameTable(
                name: "CaseAssignments",
                newName: "CaseAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_CaseAssignments_CaseId",
                table: "CaseAssignment",
                newName: "IX_CaseAssignment_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseAssignments_CaseAssignmentTypeId",
                table: "CaseAssignment",
                newName: "IX_CaseAssignment_CaseAssignmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseAssignment",
                table: "CaseAssignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAssignment_CaseAssignmentTypes_CaseAssignmentTypeId",
                table: "CaseAssignment",
                column: "CaseAssignmentTypeId",
                principalTable: "CaseAssignmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAssignment_Cases_CaseId",
                table: "CaseAssignment",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
