using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qel.Ef.DesignTimeUtils.Migrations.Main
{
    /// <inheritdoc />
    public partial class Fill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Passports",
                columns: new[] { "Id", "Number", "Serie" },
                values: new object[,]
                {
                    { 1L, "123456", "0311" },
                    { 2L, "213455", "2228" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "Period", "Summa" },
                values: new object[,]
                {
                    { 1L, 12, 100000 },
                    { 2L, 36, 1230900 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthdate", "FirstName", "LastName", "PassportId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 21, 16, 53, 57, 62, DateTimeKind.Utc).AddTicks(6161), "Иван", "Иванов", 1L },
                    { 2L, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Владимир", "Горбатый", 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Passports",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Passports",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
