using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    public partial class JobStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JobStatusId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "JobStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_JobStatusId",
                table: "Doctors",
                column: "JobStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_JobStatus_JobStatusId",
                table: "Doctors",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_JobStatus_JobStatusId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_JobStatusId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "JobStatusId",
                table: "Doctors");
        }
    }
}
