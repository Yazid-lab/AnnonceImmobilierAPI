using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAnnonce.Api.Migrations
{
    /// <inheritdoc />
    public partial class changedConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnonceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Superficie = table.Column<int>(type: "int", nullable: false),
                    NbPieces = table.Column<int>(type: "int", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse_Rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_Pays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_Latitude = table.Column<double>(type: "float", nullable: true),
                    Adresse_Longitude = table.Column<double>(type: "float", nullable: true),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annonces_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnonceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Annonces_AnnonceId",
                        column: x => x.AnnonceId,
                        principalTable: "Annonces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Id", "AnnonceId", "Email", "Nom", "Prenom", "Telephone" },
                values: new object[] { 1, null, "email1", "nom1", "prenom1", "tel1" });

            migrationBuilder.InsertData(
                table: "Annonces",
                columns: new[] { "Id", "Adresse_CodePostal", "Adresse_Latitude", "Adresse_Longitude", "Adresse_Pays", "Adresse_Rue", "Adresse_Ville", "DatePublication", "Description", "NbPieces", "Prix", "Superficie", "Titre", "UtilisateurId" },
                values: new object[] { 1, "code", 11.0, 22.0, "tunisia", "rue", "tunis", new DateTime(2023, 3, 27, 15, 4, 25, 972, DateTimeKind.Local).AddTicks(4761), "desc1", 2, 111m, 1, "annonce 1", 1 });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AnnonceId", "Description", "Url" },
                values: new object[] { 1, 1, "description1", "url1" });

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AnnonceId",
                table: "Photos",
                column: "AnnonceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Annonces");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
