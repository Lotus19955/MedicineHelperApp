using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorsClinic_DoctorsClinicId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorsSpecializations_DoctorsSpecializationsId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorsClinicId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorsSpecializationsId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorsClinicId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorsSpecializationsId",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorsClinicId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorsSpecializationsId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorsClinicId",
                table: "Doctors",
                column: "DoctorsClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorsSpecializationsId",
                table: "Doctors",
                column: "DoctorsSpecializationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorsClinic_DoctorsClinicId",
                table: "Doctors",
                column: "DoctorsClinicId",
                principalTable: "DoctorsClinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorsSpecializations_DoctorsSpecializationsId",
                table: "Doctors",
                column: "DoctorsSpecializationsId",
                principalTable: "DoctorsSpecializations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
