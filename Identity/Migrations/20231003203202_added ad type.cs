using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class addedadtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdType",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdType", "DatePublication" },
                values: new object[] { "Rent", new DateTime(2023, 10, 3, 21, 32, 1, 716, DateTimeKind.Local).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8cb66b7-d2e9-4296-8059-91d572ecd173", "AQAAAAIAAYagAAAAEAgS5aN7cA2iYNJ1bX2fZ7HN6mKHMnyzSw1QNU+8Lm1l4xH1nUwnrjEJvc2Pc/PMCQ==", "422d6720-2883-4529-b905-771ce1b906df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "478aba9f-2032-4193-a23c-4c537a216f35", "AQAAAAIAAYagAAAAEA4LnsI7JGz67zPzlPceR1uzdAtm6yUCsq9IVeoxgS/EHVOBxqyrZrSwadUh6dDlhQ==", "c4c88187-7b5b-46b1-b51b-e24839c08d99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdType",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2023, 9, 16, 12, 1, 46, 955, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "897075ac-070e-4cd6-ba5d-0ae70e7311ff", "AQAAAAIAAYagAAAAEG9m85b3Wv6qdyEKIXCNIfReWM+Z/JmTRdvMgmn8WVQ78r3JQDvsspyrs0EjE9f0bg==", "8d7da8e3-dcc3-4c02-9a99-8ff2f794f9fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78bbf73a-7ff9-4ffd-b61a-347abff9d069", "AQAAAAIAAYagAAAAEGJIY4sUx7GHT7LXEqYAojDlID6au5bVLt9I1acwDGbt0MZleInr7T0fKAXIPPZ26w==", "a3ea0a4e-d14e-41f3-91d3-f89167101da2" });
        }
    }
}
