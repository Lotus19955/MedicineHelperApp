using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class Currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Currencies_CurrenciesId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_CurrenciesId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "CurrenciesId",
                table: "Visits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrenciesId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CurrenciesId",
                table: "Visits",
                column: "CurrenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Currencies_CurrenciesId",
                table: "Visits",
                column: "CurrenciesId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
