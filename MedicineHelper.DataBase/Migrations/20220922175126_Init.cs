using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsClinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsClinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsSpecializations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsSpecializations", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "DoctorsClinicsPhone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsClinicsPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorsClinicsPhone_DoctorsClinic_DoctorsClinicId",
                        column: x => x.DoctorsClinicId,
                        principalTable: "DoctorsClinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinesPrescriptons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfPrescriptionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicineDose = table.Column<int>(type: "int", nullable: false),
                    NumberOfMedicinePerDay = table.Column<int>(type: "int", nullable: false),
                    DaysOfMedication = table.Column<int>(type: "int", nullable: false),
                    MedicinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitsConclusionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicinesPrescriptionsStatusesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesPrescriptons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinesPrescriptons_MedicinesPrescriptionsStatuses_MedicinesPrescriptionsStatusesId",
                        column: x => x.MedicinesPrescriptionsStatusesId,
                        principalTable: "MedicinesPrescriptionsStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currescies = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicinesPrescriptonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicinesPrescriptonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrenciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitsStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitsConclusionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_VisitsConclusions_VisitsConclusionsId",
                        column: x => x.VisitsConclusionsId,
                        principalTable: "VisitsConclusions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visits_VisitsStatuses_VisitsStatusId",
                        column: x => x.VisitsStatusId,
                        principalTable: "VisitsStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirgth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    VisitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Visits_VisitsId",
                        column: x => x.VisitsId,
                        principalTable: "Visits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationsStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_DoctorsClinic_DoctorsClinicId",
                        column: x => x.DoctorsClinicId,
                        principalTable: "DoctorsClinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_VaccinationsStatuses_VaccinationsStatusId",
                        column: x => x.VaccinationsStatusId,
                        principalTable: "VaccinationsStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsSpecializationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_DoctorsClinic_DoctorsClinicId",
                        column: x => x.DoctorsClinicId,
                        principalTable: "DoctorsClinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_DoctorsSpecializations_DoctorsSpecializationsId",
                        column: x => x.DoctorsSpecializationsId,
                        principalTable: "DoctorsSpecializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Vaccinations_VaccinationsId",
                        column: x => x.VaccinationsId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfEndVaccine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrenciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccines_Vaccinations_VaccinationsId",
                        column: x => x.VaccinationsId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorsClinicId",
                table: "Doctors",
                column: "DoctorsClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorsSpecializationsId",
                table: "Doctors",
                column: "DoctorsSpecializationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VaccinationsId",
                table: "Doctors",
                column: "VaccinationsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsClinicsPhone_DoctorsClinicId",
                table: "DoctorsClinicsPhone",
                column: "DoctorsClinicId");

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
                name: "IX_MedicinesPrescriptons_MedicinesPrescriptionsStatusesId",
                table: "MedicinesPrescriptons",
                column: "MedicinesPrescriptionsStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisitsId",
                table: "Users",
                column: "VisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DoctorsClinicId",
                table: "Vaccinations",
                column: "DoctorsClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_UserId",
                table: "Vaccinations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccinationsStatusId",
                table: "Vaccinations",
                column: "VaccinationsStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_CurrenciesId",
                table: "Vaccines",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_VaccinationsId",
                table: "Vaccines",
                column: "VaccinationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CurrenciesId",
                table: "Visits",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitsConclusionsId",
                table: "Visits",
                column: "VisitsConclusionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitsStatusId",
                table: "Visits",
                column: "VisitsStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitsConclusions_MedicinesPrescriptonsId",
                table: "VisitsConclusions",
                column: "MedicinesPrescriptonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorsClinicsPhone");

            migrationBuilder.DropTable(
                name: "DoctorsVisits");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "DoctorsSpecializations");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "DoctorsClinic");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VaccinationsStatuses");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "VisitsConclusions");

            migrationBuilder.DropTable(
                name: "VisitsStatuses");

            migrationBuilder.DropTable(
                name: "MedicinesPrescriptons");

            migrationBuilder.DropTable(
                name: "MedicinesPrescriptionsStatuses");
        }
    }
}
