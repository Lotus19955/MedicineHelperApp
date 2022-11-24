using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class refctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorPersonalDatas_DoctorPersonalDataId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_JobStatus_JobStatusId",
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
                name: "FK_Vaccinations_Users_UserId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_VaccinationStatuses_VaccinationStatusId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Vaccines_VaccineId",
                table: "Vaccinations");

            migrationBuilder.DropTable(
                name: "ClinicPhones");

            migrationBuilder.DropTable(
                name: "DoctorPersonalDatas");

            migrationBuilder.DropTable(
                name: "JobStatus");

            migrationBuilder.DropTable(
                name: "PrescriptionDrugCosts");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "VaccinationCosts");

            migrationBuilder.DropTable(
                name: "VaccinationStatuses");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "VisitCosts");

            migrationBuilder.DropTable(
                name: "VisitResults");

            migrationBuilder.DropTable(
                name: "PrescriptionDrugs");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_DateOfVaccination_ClinicId_VaccineId_UserId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_VaccinationStatusId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorPersonalDataId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_JobStatusId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecializationId_DoctorPersonalDataId_ClinicId_UserId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_Name_Address_UserId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "VaccinationStatusId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "VaccineId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorPersonalDataId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "JobStatusId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "NameOfVaccine",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoteOfVaccine",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "VaccinationExpirationDate",
                table: "Vaccinations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccineProducingCountry",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VacineSeria",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FulFirst",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Doctors",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatingMode",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluorographies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataOfFluorography = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateOfFluorography = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberFluorography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluorographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fluorographies_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fluorographies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfMedicine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseHistores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfDisease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRecovery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfTreatment = table.Column<bool>(type: "bit", nullable: false),
                    SeverityOfTheIllness = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseHistores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseHistores_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseHistores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorVisits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceVisit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorVisits_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorVisits_DiseaseHistores_DiseaseHistoryId",
                        column: x => x.DiseaseHistoryId,
                        principalTable: "DiseaseHistores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorVisits_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorVisits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescriptionOfDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiseaseHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_DiseaseHistores_DiseaseHistoryId",
                        column: x => x.DiseaseHistoryId,
                        principalTable: "DiseaseHistores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_DoctorVisits_Id",
                        column: x => x.Id,
                        principalTable: "DoctorVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conclusions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAnalysis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScanOfAnalysisDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conclusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conclusions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conclusions_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conclusions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineСheckups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfMedicineСheckup = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceOfMedicineСheckup = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FilesOfMedicineСheckup = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineСheckups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineСheckups_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicineСheckups_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicineСheckups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePrescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicineDose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineProcedures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfProcedure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartProcedure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndProcedure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineProcedures_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicineProcedures_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicineProcedures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DiseaseHistoryId",
                table: "Appointments",
                column: "DiseaseHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_AppointmentId",
                table: "Conclusions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_ClinicId",
                table: "Conclusions",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Conclusions_UserId",
                table: "Conclusions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseHistores_DiseaseId",
                table: "DiseaseHistores",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseHistores_UserId",
                table: "DiseaseHistores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_ClinicId",
                table: "DoctorVisits",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_DiseaseHistoryId",
                table: "DoctorVisits",
                column: "DiseaseHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_DoctorId",
                table: "DoctorVisits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_UserId",
                table: "DoctorVisits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fluorographies_ClinicId",
                table: "Fluorographies",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Fluorographies_UserId",
                table: "Fluorographies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineСheckups_AppointmentId",
                table: "MedicineСheckups",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineСheckups_ClinicId",
                table: "MedicineСheckups",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineСheckups_UserId",
                table: "MedicineСheckups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescriptions_AppointmentId",
                table: "MedicinePrescriptions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescriptions_ClinicId",
                table: "MedicinePrescriptions",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescriptions_MedicineId",
                table: "MedicinePrescriptions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescriptions_UserId",
                table: "MedicinePrescriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineProcedures_AppointmentId",
                table: "MedicineProcedures",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineProcedures_ClinicId",
                table: "MedicineProcedures",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineProcedures_UserId",
                table: "MedicineProcedures",
                column: "UserId");

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
                name: "FK_Vaccinations_Users_UserId",
                table: "Vaccinations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Clinics_ClinicId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Users_UserId",
                table: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Conclusions");

            migrationBuilder.DropTable(
                name: "Fluorographies");

            migrationBuilder.DropTable(
                name: "MedicineСheckups");

            migrationBuilder.DropTable(
                name: "MedicinePrescriptions");

            migrationBuilder.DropTable(
                name: "MedicineProcedures");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorVisits");

            migrationBuilder.DropTable(
                name: "DiseaseHistores");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropColumn(
                name: "NameOfVaccine",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "NoteOfVaccine",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "VaccinationExpirationDate",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "VaccineProducingCountry",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "VacineSeria",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FulFirst",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "OperatingMode",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.AddColumn<Guid>(
                name: "VaccinationStatusId",
                table: "Vaccinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VaccineId",
                table: "Vaccinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "JobStatusId",
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clinics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClinicPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicPhones_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveTermInDays = table.Column<int>(type: "int", nullable: true),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PharmName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitCosts_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitResults_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    NumberOfDosesPerDay = table.Column<int>(type: "int", nullable: false),
                    NumberOfTreatmentDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugs_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDrugCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionDrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDrugCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDrugCosts_PrescriptionDrugs_PrescriptionDrugId",
                        column: x => x.PrescriptionDrugId,
                        principalTable: "PrescriptionDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DateOfVaccination_ClinicId_VaccineId_UserId",
                table: "Vaccinations",
                columns: new[] { "DateOfVaccination", "ClinicId", "VaccineId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccinationStatusId",
                table: "Vaccinations",
                column: "VaccinationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorPersonalDataId",
                table: "Doctors",
                column: "DoctorPersonalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_JobStatusId",
                table: "Doctors",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId_DoctorPersonalDataId_ClinicId_UserId",
                table: "Doctors",
                columns: new[] { "SpecializationId", "DoctorPersonalDataId", "ClinicId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Name_Address_UserId",
                table: "Clinics",
                columns: new[] { "Name", "Address", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPhones_ClinicId",
                table: "ClinicPhones",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPhones_Number_ClinicId",
                table: "ClinicPhones",
                columns: new[] { "Number", "ClinicId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Name",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_Name_Unit_Producer_UserId",
                table: "Drugs",
                columns: new[] { "Name", "Unit", "Producer", "UserId" },
                unique: true);

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
                name: "IX_Specializations_Name",
                table: "Specializations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCosts_CurrencyId",
                table: "VaccinationCosts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationStatuses_Name",
                table: "VaccinationStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_PharmName",
                table: "Vaccines",
                column: "PharmName",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitDate_DoctorId_UserId",
                table: "Visits",
                columns: new[] { "VisitDate", "DoctorId", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorPersonalDatas_DoctorPersonalDataId",
                table: "Doctors",
                column: "DoctorPersonalDataId",
                principalTable: "DoctorPersonalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_JobStatus_JobStatusId",
                table: "Doctors",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Clinics_ClinicId",
                table: "Vaccinations",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Users_UserId",
                table: "Vaccinations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_VaccinationStatuses_VaccinationStatusId",
                table: "Vaccinations",
                column: "VaccinationStatusId",
                principalTable: "VaccinationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Vaccines_VaccineId",
                table: "Vaccinations",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
