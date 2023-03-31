using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedRelationAnnonceUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
                table: "Annonces");

            migrationBuilder.DropIndex(
                name: "IX_Annonces_UtilisateurId",
                table: "Annonces");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Annonces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 3, 31, 14, 36, 30, 81, DateTimeKind.Local).AddTicks(7318));

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
                table: "Annonces");

            migrationBuilder.DropIndex(
                name: "IX_Annonces_UtilisateurId",
                table: "Annonces");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Annonces",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Annonces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 3, 30, 16, 44, 53, 623, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
