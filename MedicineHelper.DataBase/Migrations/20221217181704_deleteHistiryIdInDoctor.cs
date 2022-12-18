using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class deleteHistiryIdInDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisits_DiseaseHistores_DiseaseHistoryId",
                table: "DoctorVisits");

            migrationBuilder.DropIndex(
                name: "IX_DoctorVisits_DiseaseHistoryId",
                table: "DoctorVisits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
