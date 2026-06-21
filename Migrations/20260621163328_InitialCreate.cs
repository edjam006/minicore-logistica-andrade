using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinicoreLogisticaAndrade.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "repartidor",
                columns: table => new
                {
                    id_repartidor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repartidor", x => x.id_repartidor);
                });

            migrationBuilder.CreateTable(
                name: "zonas",
                columns: table => new
                {
                    id_zona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_zona = table.Column<string>(type: "text", nullable: false),
                    tarifa_por_kg = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonas", x => x.id_zona);
                });

            migrationBuilder.CreateTable(
                name: "envios",
                columns: table => new
                {
                    id_envio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_repartidor = table.Column<int>(type: "integer", nullable: false),
                    id_zona = table.Column<int>(type: "integer", nullable: false),
                    peso_kg = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    fecha_envio = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_envios", x => x.id_envio);
                    table.ForeignKey(
                        name: "FK_envios_repartidor_id_repartidor",
                        column: x => x.id_repartidor,
                        principalTable: "repartidor",
                        principalColumn: "id_repartidor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_envios_zonas_id_zona",
                        column: x => x.id_zona,
                        principalTable: "zonas",
                        principalColumn: "id_zona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_envios_id_repartidor",
                table: "envios",
                column: "id_repartidor");

            migrationBuilder.CreateIndex(
                name: "IX_envios_id_zona",
                table: "envios",
                column: "id_zona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "envios");

            migrationBuilder.DropTable(
                name: "repartidor");

            migrationBuilder.DropTable(
                name: "zonas");
        }
    }
}
