using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class down1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "DoctorVisits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisits_Doctors_DoctorId",
                table: "DoctorVisits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
