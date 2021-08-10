using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseCore.Persistence.Migrations
{
#pragma warning disable IDE1006 // Naming Styles
    public partial class overhaul : Migration
#pragma warning restore IDE1006 // Naming Styles
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cases_CaseId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CaseId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "HeightInInches",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OccurredBetweenEndDate",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OccurredBetweenStartDate",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OccurredOnExactDate",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportedOnDate",
                table: "Cases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "CaseAssignmentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseAssignmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasePerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasePerson_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasePerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatusType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OffenseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    CaseAssignmentTypeId = table.Column<int>(nullable: false),
                    AssignedToName = table.Column<string>(maxLength: 100, nullable: false),
                    AssignmentDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseAssignment_CaseAssignmentType_CaseAssignmentTypeId",
                        column: x => x.CaseAssignmentTypeId,
                        principalTable: "CaseAssignmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseAssignment_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    CaseStatusTypeId = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseStatus_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseStatus_CaseStatusType_CaseStatusTypeId",
                        column: x => x.CaseStatusTypeId,
                        principalTable: "CaseStatusType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseOffense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    OffenseTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseOffense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseOffense_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseOffense_OffenseType_OffenseTypeId",
                        column: x => x.OffenseTypeId,
                        principalTable: "OffenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CaseAssignmentType",
                columns: new[] { "Id", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, null, "Initial" },
                    { 2, null, "Reassigned" }
                });

            migrationBuilder.InsertData(
                table: "CaseStatusType",
                columns: new[] { "Id", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, null, "Open" },
                    { 2, null, "InActive" },
                    { 3, null, "Closed (Arrest)" },
                    { 4, null, "Closed (Admin)" },
                    { 5, null, "Closed (Exception)" }
                });

            migrationBuilder.InsertData(
                table: "OffenseType",
                columns: new[] { "Id", "Abbreviation", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, "HOMI", null, "Homicide" },
                    { 2, "RAPE", null, "Rape" },
                    { 3, "ROBB", null, "Robbery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseAssignment_CaseAssignmentTypeId",
                table: "CaseAssignment",
                column: "CaseAssignmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAssignment_CaseId",
                table: "CaseAssignment",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffense_CaseId",
                table: "CaseOffense",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffense_OffenseTypeId",
                table: "CaseOffense",
                column: "OffenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_CaseId",
                table: "CasePerson",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_PersonId",
                table: "CasePerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatus_CaseId",
                table: "CaseStatus",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatus_CaseStatusTypeId",
                table: "CaseStatus",
                column: "CaseStatusTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseAssignment");

            migrationBuilder.DropTable(
                name: "CaseOffense");

            migrationBuilder.DropTable(
                name: "CasePerson");

            migrationBuilder.DropTable(
                name: "CaseStatus");

            migrationBuilder.DropTable(
                name: "CaseAssignmentType");

            migrationBuilder.DropTable(
                name: "OffenseType");

            migrationBuilder.DropTable(
                name: "CaseStatusType");

            migrationBuilder.DropColumn(
                name: "HeightInInches",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "OccurredBetweenEndDate",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "OccurredBetweenStartDate",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "OccurredOnExactDate",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ReportedOnDate",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Addresses",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Addresses",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CaseId",
                table: "Persons",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cases_CaseId",
                table: "Persons",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
