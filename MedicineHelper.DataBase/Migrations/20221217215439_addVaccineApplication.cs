using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class addVaccineApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteOfVaccine",
                table: "Vaccinations");

            migrationBuilder.AlterColumn<string>(
                name: "VaccineProducingCountry",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameOfVaccine",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationOfVaccine",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationOfVaccine",
                table: "Vaccinations");

            migrationBuilder.AlterColumn<string>(
                name: "VaccineProducingCountry",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfVaccine",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteOfVaccine",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
