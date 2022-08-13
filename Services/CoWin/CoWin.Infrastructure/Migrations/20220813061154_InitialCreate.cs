using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWin.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccinationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstDose = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondDose = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstDose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondDose = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfVaccinationId = table.Column<int>(type: "int", nullable: true),
                    VaccinationPlaceId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationDetails_VaccinationDates_DateOfVaccinationId",
                        column: x => x.DateOfVaccinationId,
                        principalTable: "VaccinationDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationDetails_VaccinationPlaces_VaccinationPlaceId",
                        column: x => x.VaccinationPlaceId,
                        principalTable: "VaccinationPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDetails_DateOfVaccinationId",
                table: "VaccinationDetails",
                column: "DateOfVaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDetails_VaccinationPlaceId",
                table: "VaccinationDetails",
                column: "VaccinationPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationDetails");

            migrationBuilder.DropTable(
                name: "VaccinationDates");

            migrationBuilder.DropTable(
                name: "VaccinationPlaces");
        }
    }
}
