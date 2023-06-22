using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newAdEntityAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Ads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatePublication", "IsPublished" },
                values: new object[] { new DateTime(2023, 5, 26, 13, 22, 43, 957, DateTimeKind.Local).AddTicks(8218), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 5, 16, 11, 35, 1, 290, DateTimeKind.Local).AddTicks(8196));
        }
    }
}
