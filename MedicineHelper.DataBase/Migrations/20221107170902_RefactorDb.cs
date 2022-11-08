using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class RefactorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Visits_VisitsId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorsId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Currencies_CurrenciesId",
                table: "Vaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Vaccinations_VaccinationId",
                table: "Vaccines");

            migrationBuilder.DropTable(
                name: "DoctorsSpecializations");

            migrationBuilder.DropTable(
                name: "DoctorsVisits");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "VisitsConclusions");

            migrationBuilder.DropTable(
                name: "MedicinesPrescriptons");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_CurrenciesId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_VaccinationId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Users_VisitsId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "DateOfEndVaccine",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "VaccinationId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "VisitsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "DoctorsId",
                table: "Visits",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vaccines",
                newName: "PharmName");

            migrationBuilder.RenameColumn(
                name: "CurrenciesId",
                table: "Vaccines",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "VaccinesId",
                table: "Vaccinations",
                newName: "VaccineId");

            migrationBuilder.RenameColumn(
                name: "DoctorsId",
                table: "Vaccinations",
                newName: "VaccinationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_DoctorsId",
                table: "Vaccinations",
                newName: "IX_Vaccinations_VaccinationStatusId");

            migrationBuilder.RenameColumn(
                name: "VisitsId",
                table: "Doctors",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EffectiveTermInDays",
                table: "Vaccines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "Vaccines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "Vaccines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "Vaccinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorPersonalDataId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SpecializationId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPersonalDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPersonalDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitCosts_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitResults_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicPhones_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    NumberOfDosesPerDay = table.Column<int>(type: "int", nullable: false),
                    NumberOfTreatmentDays = table.Column<int>(type: "int", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugs_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDrugCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionDrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDrugCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugCosts_PrescriptionDrugs_PrescriptionDrugId",
                        column: x => x.PrescriptionDrugId,
                        principalTable: "PrescriptionDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_ClinicId",
                table: "Vaccinations",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorPersonalDataId",
                table: "Doctors",
                column: "DoctorPersonalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPhones_ClinicId",
                table: "ClinicPhones",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDrugCosts_CurrencyId",
                table: "PrescriptionDrugCosts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDrugCosts_PrescriptionDrugId",
                table: "PrescriptionDrugCosts",
                column: "PrescriptionDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDrugs_DrugId",
                table: "PrescriptionDrugs",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDrugs_PrescriptionId",
                table: "PrescriptionDrugs",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_VisitId",
                table: "Prescriptions",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCosts_CurrencyId",
                table: "VaccinationCosts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitCosts_CurrencyId",
                table: "VisitCosts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitCosts_VisitId",
                table: "VisitCosts",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitResults_VisitId",
                table: "VisitResults",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorPersonalDatas_DoctorPersonalDataId",
                table: "Doctors",
                column: "DoctorPersonalDataId",
                principalTable: "DoctorPersonalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Clinics_ClinicId",
                table: "Vaccinations",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_VaccinationStatuses_VaccinationStatusId",
                table: "Vaccinations",
                column: "VaccinationStatusId",
                principalTable: "VaccinationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Vaccines_VaccineId",
                table: "Vaccinations",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorPersonalDatas_DoctorPersonalDataId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Clinics_ClinicId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_VaccinationStatuses_VaccinationStatusId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Vaccines_VaccineId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "ClinicPhones");

            migrationBuilder.DropTable(
                name: "DoctorPersonalDatas");

            migrationBuilder.DropTable(
                name: "PrescriptionDrugCosts");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "VaccinationCosts");

            migrationBuilder.DropTable(
                name: "VaccinationStatuses");

            migrationBuilder.DropTable(
                name: "VisitCosts");

            migrationBuilder.DropTable(
                name: "VisitResults");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "PrescriptionDrugs");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_ClinicId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorPersonalDataId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "EffectiveTermInDays",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorPersonalDataId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Visits",
                newName: "DoctorsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Vaccines",
                newName: "CurrenciesId");

            migrationBuilder.RenameColumn(
                name: "PharmName",
                table: "Vaccines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "VaccineId",
                table: "Vaccinations",
                newName: "VaccinesId");

            migrationBuilder.RenameColumn(
                name: "VaccinationStatusId",
                table: "Vaccinations",
                newName: "DoctorsId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_VaccinationStatusId",
                table: "Vaccinations",
                newName: "IX_Vaccinations_DoctorsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Doctors",
                newName: "VisitsId");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Visits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Vaccines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEndVaccine",
                table: "Vaccines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "VaccinationId",
                table: "Vaccines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vaccinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VisitsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DoctorsSpecializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsSpecializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsVisits",
                columns: table => new
                {
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitedDoctorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsVisits", x => new { x.VisitId, x.VisitedDoctorsId });
                    table.ForeignKey(
                        name: "FK_DoctorsVisits_Doctors_VisitedDoctorsId",
                        column: x => x.VisitedDoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorsVisits_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinesPrescriptons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfPrescriptionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysOfMedication = table.Column<int>(type: "int", nullable: false),
                    MedicineDose = table.Column<int>(type: "int", nullable: false),
                    MedicinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfMedicinePerDay = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VisitsConclusionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesPrescriptons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currescies = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicinesPrescriptonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Currencies_CurrencieId",
                        column: x => x.CurrencieId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicines_MedicinesPrescriptons_MedicinesPrescriptonsId",
                        column: x => x.MedicinesPrescriptonsId,
                        principalTable: "MedicinesPrescriptons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitsConclusions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicinesPrescriptonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitsConclusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitsConclusions_MedicinesPrescriptons_MedicinesPrescriptonsId",
                        column: x => x.MedicinesPrescriptonsId,
                        principalTable: "MedicinesPrescriptons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitsConclusions_Visits_VisitsId",
                        column: x => x.VisitsId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_CurrenciesId",
                table: "Vaccines",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_VaccinationId",
                table: "Vaccines",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisitsId",
                table: "Users",
                column: "VisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsVisits_VisitedDoctorsId",
                table: "DoctorsVisits",
                column: "VisitedDoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_CurrencieId",
                table: "Medicines",
                column: "CurrencieId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicinesPrescriptonsId",
                table: "Medicines",
                column: "MedicinesPrescriptonsId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitsConclusions_MedicinesPrescriptonsId",
                table: "VisitsConclusions",
                column: "MedicinesPrescriptonsId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitsConclusions_VisitsId",
                table: "VisitsConclusions",
                column: "VisitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Vaccines_Currencies_CurrenciesId",
                table: "Vaccines",
                column: "CurrenciesId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Vaccinations_VaccinationId",
                table: "Vaccines",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "Id");
        }
    }
}
