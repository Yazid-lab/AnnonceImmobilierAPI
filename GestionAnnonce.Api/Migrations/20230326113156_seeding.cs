using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAnnonce.Api.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adresse_CodePostal", "Adresse_Latitude", "Adresse_Longitude", "Adresse_Pays", "Adresse_Rue", "Adresse_Ville", "DatePublication" },
                values: new object[] { "code", 11.0, 22.0, "tunisia", "rue", "tunis", new DateTime(2023, 3, 26, 12, 31, 56, 96, DateTimeKind.Local).AddTicks(1859) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 3, 26, 12, 29, 20, 742, DateTimeKind.Local).AddTicks(1981));
        }
    }
}
