using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseCore.Persistence.Migrations
{
#pragma warning disable IDE1006 // Naming Styles
    public partial class initial : Migration
#pragma warning restore IDE1006 // Naming Styles
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CaseNumber = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    AddressTypeId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(maxLength: 200, nullable: false),
                    Suite = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(maxLength: 10, nullable: false),
                    Beat = table.Column<string>(maxLength: 10, nullable: false),
                    ReportingArea = table.Column<string>(maxLength: 10, nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Race = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    SSN = table.Column<string>(nullable: true),
                    CaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    PhoneNumberTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_PhoneNumberTypes_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseAddress_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAddress_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonEmailAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    EmailAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEmailAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonEmailAddress_EmailAddress_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalTable: "EmailAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEmailAddress_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    PhoneNumberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPhoneNumber_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhoneNumber_PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Abbreviation", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, "LOI", null, "Location of Incident" },
                    { 2, "HOME", null, "Home Address" },
                    { 3, "WORK", null, "Work Address" },
                    { 4, "MAIL", null, "Mailing Address" },
                    { 5, "LOA", null, "Location of Apprehension" }
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Abbreviation", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, "V", null, "Victim" },
                    { 2, "W", null, "Witness" },
                    { 3, "S", null, "Suspect" },
                    { 4, "POC", null, "Point of Contact" },
                    { 5, "NOK", null, "Next of Kin" },
                    { 6, "A", null, "Arrestee" },
                    { 7, "O", null, "Other" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumberTypes",
                columns: new[] { "Id", "Abbreviation", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, "H", null, "Home" },
                    { 2, "W", null, "Work" },
                    { 3, "M", null, "Mobile" },
                    { 4, "F", null, "Fax" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAddress_AddressId",
                table: "CaseAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAddress_CaseId",
                table: "CaseAddress",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_AddressId",
                table: "PersonAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_PersonId",
                table: "PersonAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEmailAddress_EmailAddressId",
                table: "PersonEmailAddress",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEmailAddress_PersonId",
                table: "PersonEmailAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhoneNumber_PersonId",
                table: "PersonPhoneNumber",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhoneNumber_PhoneNumberId",
                table: "PersonPhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CaseId",
                table: "Persons",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_PhoneNumberTypeId",
                table: "PhoneNumber",
                column: "PhoneNumberTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseAddress");

            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropTable(
                name: "PersonEmailAddress");

            migrationBuilder.DropTable(
                name: "PersonPhoneNumber");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes");
        }
    }
}
