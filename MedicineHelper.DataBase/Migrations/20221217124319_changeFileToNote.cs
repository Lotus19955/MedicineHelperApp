using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class changeFileToNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilesOfMedicineСheckup",
                table: "MedicineСheckups");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "MedicineСheckups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "MedicineСheckups");

            migrationBuilder.AddColumn<byte[]>(
                name: "FilesOfMedicineСheckup",
                table: "MedicineСheckups",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
