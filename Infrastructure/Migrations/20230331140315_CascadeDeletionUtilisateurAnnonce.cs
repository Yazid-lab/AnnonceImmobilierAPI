using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeletionUtilisateurAnnonce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
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
                value: new DateTime(2023, 3, 31, 15, 3, 15, 463, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Utilisateurs_UtilisateurId",
                table: "Annonces",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }
    }
}
