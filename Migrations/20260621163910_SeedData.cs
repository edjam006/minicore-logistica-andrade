using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinicoreLogisticaAndrade.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "repartidor",
                columns: new[] { "id_repartidor", "email", "nombre" },
                values: new object[,]
                {
                    { 1, "andres@logistica.com", "Andrés" },
                    { 2, "camila@logistica.com", "Camila" },
                    { 3, "luis@logistica.com", "Luis" }
                });

            migrationBuilder.InsertData(
                table: "zonas",
                columns: new[] { "id_zona", "nombre_zona", "tarifa_por_kg" },
                values: new object[,]
                {
                    { 1, "Norte", 1.50m },
                    { 2, "Sur", 2.00m },
                    { 3, "Centro", 1.25m }
                });

            migrationBuilder.InsertData(
                table: "envios",
                columns: new[] { "id_envio", "fecha_envio", "id_repartidor", "id_zona", "peso_kg" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 10m },
                    { 2, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 22m },
                    { 3, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 18m },
                    { 4, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 15m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "envios",
                keyColumn: "id_envio",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "envios",
                keyColumn: "id_envio",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "envios",
                keyColumn: "id_envio",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "envios",
                keyColumn: "id_envio",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "repartidor",
                keyColumn: "id_repartidor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "repartidor",
                keyColumn: "id_repartidor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "repartidor",
                keyColumn: "id_repartidor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "zonas",
                keyColumn: "id_zona",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "zonas",
                keyColumn: "id_zona",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "zonas",
                keyColumn: "id_zona",
                keyValue: 3);
        }
    }
}
