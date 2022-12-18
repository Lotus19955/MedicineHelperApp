using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameOfAnalysis",
                table: "Conclusions",
                newName: "NameOfConclusion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameOfConclusion",
                table: "Conclusions",
                newName: "NameOfAnalysis");
        }
    }
}
