using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAnnonce.Api.Migrations
{
    /// <inheritdoc />
    public partial class lastTryMaybe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Adresses_AdresseId",
                table: "Annonces");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Annonces_AdresseId",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "AdresseId",
                table: "Annonces");

            migrationBuilder.AddColumn<string>(
                name: "Adresse_CodePostal",
                table: "Annonces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Adresse_Id",
                table: "Annonces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Adresse_Latitude",
                table: "Annonces",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Adresse_Longitude",
                table: "Annonces",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse_Pays",
                table: "Annonces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse_Rue",
                table: "Annonces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse_Ville",
                table: "Annonces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 3, 26, 12, 27, 8, 700, DateTimeKind.Local).AddTicks(591));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse_CodePostal",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "Adresse_Id",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "Adresse_Latitude",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "Adresse_Longitude",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "Adresse_Pays",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "Adresse_Rue",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "Adresse_Ville",
                table: "Annonces");

            migrationBuilder.AddColumn<int>(
                name: "AdresseId",
                table: "Annonces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "CodePostal", "Latitude", "Longitude", "Pays", "Rue", "Ville" },
                values: new object[] { 1, "codepostal1", 11.0, 11.0, "pays1", "rue1", "ville1" });

            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdresseId", "DatePublication" },
                values: new object[] { 1, new DateTime(2023, 3, 24, 13, 3, 44, 369, DateTimeKind.Local).AddTicks(2245) });

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_AdresseId",
                table: "Annonces",
                column: "AdresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Adresses_AdresseId",
                table: "Annonces",
                column: "AdresseId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
