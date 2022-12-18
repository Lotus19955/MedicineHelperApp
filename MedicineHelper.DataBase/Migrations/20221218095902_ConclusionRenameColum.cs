using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class ConclusionRenameColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScanOfAnalysisDocument",
                table: "Conclusions",
                newName: "ScanOfConclusionDocument");

            migrationBuilder.RenameColumn(
                name: "DateOfAnalysis",
                table: "Conclusions",
                newName: "DateOfConclusion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScanOfConclusionDocument",
                table: "Conclusions",
                newName: "ScanOfAnalysisDocument");

            migrationBuilder.RenameColumn(
                name: "DateOfConclusion",
                table: "Conclusions",
                newName: "DateOfAnalysis");
        }
    }
}
