using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class Statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicinesPrescriptons_MedicinesPrescriptionsStatuses_MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_VaccinationsStatuses_VaccinationsStatusId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitsStatuses_VisitsStatusId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "MedicinesPrescriptionsStatuses");

            migrationBuilder.DropTable(
                name: "VaccinationsStatuses");

            migrationBuilder.DropTable(
                name: "VisitsStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitsStatusId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_VaccinationsStatusId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_MedicinesPrescriptons_MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons");

            migrationBuilder.DropColumn(
                name: "VisitsStatusId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VaccinationsStatusId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vaccinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MedicinesPrescriptons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MedicinesPrescriptons");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitsStatusId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VaccinationsStatusId",
                table: "Vaccinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MedicinesPrescriptionsStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesPrescriptionsStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationsStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationsStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitsStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitsStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitsStatusId",
                table: "Visits",
                column: "VisitsStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccinationsStatusId",
                table: "Vaccinations",
                column: "VaccinationsStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinesPrescriptons_MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons",
                column: "MedicinesPrescriptionsStatusesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinesPrescriptons_MedicinesPrescriptionsStatuses_MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons",
                column: "MedicinesPrescriptionsStatusesId",
                principalTable: "MedicinesPrescriptionsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_VaccinationsStatuses_VaccinationsStatusId",
                table: "Vaccinations",
                column: "VaccinationsStatusId",
                principalTable: "VaccinationsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitsStatuses_VisitsStatusId",
                table: "Visits",
                column: "VisitsStatusId",
                principalTable: "VisitsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
