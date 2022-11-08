using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class UserTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Vaccinations_VaccinationId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitsConclusions_VisitsConclusionsId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "UserVisits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitsConclusionsId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_VaccinationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VisitsConclusionsId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DateOfBirgth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VaccinationId",
                table: "Doctors");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitsConclusions_VisitsId",
                table: "VisitsConclusions",
                column: "VisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DoctorsId",
                table: "Vaccinations",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisitsId",
                table: "Users",
                column: "VisitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Visits_VisitsId",
                table: "Users",
                column: "VisitsId",
                principalTable: "Visits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorsId",
                table: "Vaccinations",
                column: "DoctorsId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitsConclusions_Visits_VisitsId",
                table: "VisitsConclusions",
                column: "VisitsId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Visits_VisitsId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorsId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitsConclusions_Visits_VisitsId",
                table: "VisitsConclusions");

            migrationBuilder.DropIndex(
                name: "IX_VisitsConclusions_VisitsId",
                table: "VisitsConclusions");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_DoctorsId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Users_VisitsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VisitsId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitsConclusionsId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirgth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VaccinationId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserVisits",
                columns: table => new
                {
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVisits", x => new { x.UsersId, x.VisitId });
                    table.ForeignKey(
                        name: "FK_UserVisits_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVisits_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitsConclusionsId",
                table: "Visits",
                column: "VisitsConclusionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VaccinationId",
                table: "Doctors",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVisits_VisitId",
                table: "UserVisits",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Vaccinations_VaccinationId",
                table: "Doctors",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitsConclusions_VisitsConclusionsId",
                table: "Visits",
                column: "VisitsConclusionsId",
                principalTable: "VisitsConclusions",
                principalColumn: "Id");
        }
    }
}
