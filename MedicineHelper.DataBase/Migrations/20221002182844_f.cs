using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_DoctorsClinic_DoctorsClinicId",
                table: "Vaccinations");

            migrationBuilder.DropTable(
                name: "DoctorsClinicsPhone");

            migrationBuilder.DropTable(
                name: "DoctorsClinic");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_DoctorsClinicId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "DoctorsClinicId",
                table: "Vaccinations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorsClinicId",
                table: "Vaccinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DoctorsClinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsClinic", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DoctorsClinicId",
                table: "Vaccinations",
                column: "DoctorsClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsClinicsPhone_DoctorsClinicId",
                table: "DoctorsClinicsPhone",
                column: "DoctorsClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_DoctorsClinic_DoctorsClinicId",
                table: "Vaccinations",
                column: "DoctorsClinicId",
                principalTable: "DoctorsClinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
