using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class File : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Vaccinations_VaccinationsId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Visits_VisitsId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Vaccinations_VaccinationsId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Users_VisitsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VisitsId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "VaccinationsId",
                table: "Vaccines",
                newName: "VaccinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccines_VaccinationsId",
                table: "Vaccines",
                newName: "IX_Vaccines_VaccinationId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DoctorsSpecializations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VaccinationsId",
                table: "Doctors",
                newName: "VaccinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_VaccinationsId",
                table: "Doctors",
                newName: "IX_Doctors_VaccinationId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

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
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

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
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Vaccinations_VaccinationId",
                table: "Vaccines",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Vaccinations_VaccinationId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Vaccinations_VaccinationId",
                table: "Vaccines");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserVisits");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "VaccinationId",
                table: "Vaccines",
                newName: "VaccinationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccines_VaccinationId",
                table: "Vaccines",
                newName: "IX_Vaccines_VaccinationsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DoctorsSpecializations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VaccinationId",
                table: "Doctors",
                newName: "VaccinationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_VaccinationId",
                table: "Doctors",
                newName: "IX_Doctors_VaccinationsId");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisitsId",
                table: "Users",
                column: "VisitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Vaccinations_VaccinationsId",
                table: "Doctors",
                column: "VaccinationsId",
                principalTable: "Vaccinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Visits_VisitsId",
                table: "Users",
                column: "VisitsId",
                principalTable: "Visits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Vaccinations_VaccinationsId",
                table: "Vaccines",
                column: "VaccinationsId",
                principalTable: "Vaccinations",
                principalColumn: "Id");
        }
    }
}
