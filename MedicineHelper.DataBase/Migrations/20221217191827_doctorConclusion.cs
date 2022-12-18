using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class doctorConclusion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_DiseaseHistores_DiseaseHistoryId",
                table: "DoctorVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits");

            migrationBuilder.DropIndex(
                name: "IX_DoctorVisits_DiseaseHistoryId",
                table: "DoctorVisits");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "DoctorVisits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConclusionId",
                table: "DoctorVisits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_ConclusionId",
                table: "DoctorVisits",
                column: "ConclusionId",
                unique: true,
                filter: "[ConclusionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisits_Conclusions_ConclusionId",
                table: "DoctorVisits",
                column: "ConclusionId",
                principalTable: "Conclusions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_Conclusions_ConclusionId",
                table: "DoctorVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits");

            migrationBuilder.DropIndex(
                name: "IX_DoctorVisits_ConclusionId",
                table: "DoctorVisits");

            migrationBuilder.DropColumn(
                name: "ConclusionId",
                table: "DoctorVisits");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "DoctorVisits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_DiseaseHistoryId",
                table: "DoctorVisits",
                column: "DiseaseHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisits_DiseaseHistores_DiseaseHistoryId",
                table: "DoctorVisits",
                column: "DiseaseHistoryId",
                principalTable: "DiseaseHistores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
