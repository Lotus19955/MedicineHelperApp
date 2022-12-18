using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DoctorVisits_ConclusionId",
                table: "DoctorVisits");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_ConclusionId",
                table: "DoctorVisits",
                column: "ConclusionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DoctorVisits_ConclusionId",
                table: "DoctorVisits");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisits_ConclusionId",
                table: "DoctorVisits",
                column: "ConclusionId",
                unique: true,
                filter: "[ConclusionId] IS NOT NULL");
        }
    }
}
