using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAnnonce.Api.Migrations
{
    /// <inheritdoc />
    public partial class addedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Adresse_AdresseId",
                table: "Annonces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse");

            migrationBuilder.RenameTable(
                name: "Adresse",
                newName: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "AdresseId",
                table: "Annonces",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "CodePostal", "Latitude", "Longitude", "Pays", "Rue", "Ville" },
                values: new object[] { 1, "codepostal1", 11.0, 11.0, "pays1", "rue1", "ville1" });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Id", "Email", "Nom", "Prenom", "Telephone" },
                values: new object[] { 1, "email1", "nom1", "prenom1", "tel1" });

            migrationBuilder.InsertData(
                table: "Annonces",
                columns: new[] { "Id", "AdresseId", "DatePublication", "Description", "NbPieces", "Prix", "Superficie", "Titre", "UtilisateurId" },
                values: new object[] { 1, 1, new DateTime(2023, 3, 24, 13, 3, 44, 369, DateTimeKind.Local).AddTicks(2245), "desc1", 2, 111m, 1, "annonce1", 1 });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AnnonceId", "Description", "Url" },
                values: new object[] { 1, 1, "description1", "url1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Adresses_AdresseId",
                table: "Annonces",
                column: "AdresseId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Adresses_AdresseId",
                table: "Annonces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Adresse");

            migrationBuilder.AlterColumn<int>(
                name: "AdresseId",
                table: "Annonces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Adresse_AdresseId",
                table: "Annonces",
                column: "AdresseId",
                principalTable: "Adresse",
                principalColumn: "Id");
        }
    }
}
