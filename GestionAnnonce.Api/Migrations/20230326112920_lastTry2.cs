using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAnnonce.Api.Migrations
{
    /// <inheritdoc />
    public partial class lastTry2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse_Id",
                table: "Annonces");

            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 3, 26, 12, 29, 20, 742, DateTimeKind.Local).AddTicks(1981));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adresse_Id",
                table: "Annonces",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 3, 26, 12, 27, 8, 700, DateTimeKind.Local).AddTicks(591));
        }
    }
}
