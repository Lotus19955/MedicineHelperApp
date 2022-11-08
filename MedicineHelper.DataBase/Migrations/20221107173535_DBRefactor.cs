using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class DBRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicPhones_Clinics_ClinicId",
                table: "ClinicPhones");

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
                name: "FK_PrescriptionDrugCosts_Currencies_CurrencyId",
                table: "PrescriptionDrugCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDrugCosts_PrescriptionDrugs_PrescriptionDrugId",
                table: "PrescriptionDrugCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDrugs_Drugs_DrugId",
                table: "PrescriptionDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                table: "PrescriptionDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Visits_VisitId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationCosts_Currencies_CurrencyId",
                table: "VaccinationCosts");

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

            migrationBuilder.DropForeignKey(
                name: "FK_VisitCosts_Currencies_CurrencyId",
                table: "VisitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitCosts_Visits_VisitId",
                table: "VisitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitResults_Visits_VisitId",
                table: "VisitResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Visits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PharmName",
                table: "Vaccines",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VaccinationStatuses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Specializations",
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

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Drugs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Producer",
                table: "Drugs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drugs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Currencies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Clinics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "ClinicPhones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitDate_DoctorId_UserId",
                table: "Visits",
                columns: new[] { "VisitDate", "DoctorId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_PharmName",
                table: "Vaccines",
                column: "PharmName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationStatuses_Name",
                table: "VaccinationStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DateOfVaccination_ClinicId_VaccineId_UserId",
                table: "Vaccinations",
                columns: new[] { "DateOfVaccination", "ClinicId", "VaccineId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Name",
                table: "Specializations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_Name_Unit_Producer_UserId",
                table: "Drugs",
                columns: new[] { "Name", "Unit", "Producer", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId_DoctorPersonalDataId_ClinicId_UserId",
                table: "Doctors",
                columns: new[] { "SpecializationId", "DoctorPersonalDataId", "ClinicId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Name",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Name_Address_UserId",
                table: "Clinics",
                columns: new[] { "Name", "Address", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPhones_Number_ClinicId",
                table: "ClinicPhones",
                columns: new[] { "Number", "ClinicId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicPhones_Clinics_ClinicId",
                table: "ClinicPhones",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugCosts_Currencies_CurrencyId",
                table: "PrescriptionDrugCosts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugCosts_PrescriptionDrugs_PrescriptionDrugId",
                table: "PrescriptionDrugCosts",
                column: "PrescriptionDrugId",
                principalTable: "PrescriptionDrugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugs_Drugs_DrugId",
                table: "PrescriptionDrugs",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                table: "PrescriptionDrugs",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Visits_VisitId",
                table: "Prescriptions",
                column: "VisitId",
                principalTable: "Visits",
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
                name: "FK_VaccinationCosts_Currencies_CurrencyId",
                table: "VaccinationCosts",
                column: "CurrencyId",
                principalTable: "Currencies",
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

            migrationBuilder.AddForeignKey(
                name: "FK_VisitCosts_Currencies_CurrencyId",
                table: "VisitCosts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitCosts_Visits_VisitId",
                table: "VisitCosts",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitResults_Visits_VisitId",
                table: "VisitResults",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicPhones_Clinics_ClinicId",
                table: "ClinicPhones");

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
                name: "FK_PrescriptionDrugCosts_Currencies_CurrencyId",
                table: "PrescriptionDrugCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDrugCosts_PrescriptionDrugs_PrescriptionDrugId",
                table: "PrescriptionDrugCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDrugs_Drugs_DrugId",
                table: "PrescriptionDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                table: "PrescriptionDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Visits_VisitId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationCosts_Currencies_CurrencyId",
                table: "VaccinationCosts");

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

            migrationBuilder.DropForeignKey(
                name: "FK_VisitCosts_Currencies_CurrencyId",
                table: "VisitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitCosts_Visits_VisitId",
                table: "VisitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitResults_Visits_VisitId",
                table: "VisitResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitDate_DoctorId_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_PharmName",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationStatuses_Name",
                table: "VaccinationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_DateOfVaccination_ClinicId_VaccineId_UserId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_Name",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_Name_Unit_Producer_UserId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecializationId_DoctorPersonalDataId_ClinicId_UserId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_Name",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_Name_Address_UserId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_ClinicPhones_Number_ClinicId",
                table: "ClinicPhones");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "PharmName",
                table: "Vaccines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VaccinationStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Specializations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Producer",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "ClinicPhones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicPhones_Clinics_ClinicId",
                table: "ClinicPhones",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_PrescriptionDrugCosts_Currencies_CurrencyId",
                table: "PrescriptionDrugCosts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugCosts_PrescriptionDrugs_PrescriptionDrugId",
                table: "PrescriptionDrugCosts",
                column: "PrescriptionDrugId",
                principalTable: "PrescriptionDrugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugs_Drugs_DrugId",
                table: "PrescriptionDrugs",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                table: "PrescriptionDrugs",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Visits_VisitId",
                table: "Prescriptions",
                column: "VisitId",
                principalTable: "Visits",
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
                name: "FK_VaccinationCosts_Currencies_CurrencyId",
                table: "VaccinationCosts",
                column: "CurrencyId",
                principalTable: "Currencies",
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
                name: "FK_VisitCosts_Currencies_CurrencyId",
                table: "VisitCosts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitCosts_Visits_VisitId",
                table: "VisitCosts",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitResults_Visits_VisitId",
                table: "VisitResults",
                column: "VisitId",
                principalTable: "Visits",
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
    }
}
