using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LBGeoBackend.Migrations
{
    /// <inheritdoc />
    public partial class deleteDescrpcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descripciones");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Repuestos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "imagen_url",
                table: "Repuestos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "texto",
                table: "Repuestos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "RegistrosVentas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Registros",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Proveedores",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Equivalencias",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Clientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 1,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 2,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Equivalencias",
                keyColumn: "id_equivalencia",
                keyValue: 1,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Equivalencias",
                keyColumn: "id_equivalencia",
                keyValue: 2,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "id_proveedor",
                keyValue: 1,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "id_proveedor",
                keyValue: 2,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Registros",
                keyColumn: "id_registro",
                keyValue: 1,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Registros",
                keyColumn: "id_registro",
                keyValue: 2,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 1,
                columns: new[] { "Eliminado", "fecha_venta" },
                values: new object[] { false, new DateTime(2025, 8, 12, 16, 47, 38, 245, DateTimeKind.Local).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 2,
                columns: new[] { "Eliminado", "fecha_venta" },
                values: new object[] { false, new DateTime(2025, 8, 12, 16, 47, 38, 245, DateTimeKind.Local).AddTicks(7017) });

            migrationBuilder.UpdateData(
                table: "Repuestos",
                keyColumn: "id_repuesto",
                keyValue: 1,
                columns: new[] { "Eliminado", "imagen_url", "texto" },
                values: new object[] { false, "https://http2.mlstatic.com/D_NQ_NP_616775-MLA76602933995_052024-O.webp", "Filtro de aire original para Toyota Corolla" });

            migrationBuilder.UpdateData(
                table: "Repuestos",
                keyColumn: "id_repuesto",
                keyValue: 2,
                columns: new[] { "Eliminado", "imagen_url", "texto" },
                values: new object[] { false, "https://http2.mlstatic.com/D_NQ_NP_836797-MLA80954735198_122024-O.webp", "Pastillas de freno originales para Ford Fiesta" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "Eliminado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 2,
                column: "Eliminado",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Repuestos");

            migrationBuilder.DropColumn(
                name: "imagen_url",
                table: "Repuestos");

            migrationBuilder.DropColumn(
                name: "texto",
                table: "Repuestos");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "RegistrosVentas");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Equivalencias");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Clientes");

            migrationBuilder.CreateTable(
                name: "Descripciones",
                columns: table => new
                {
                    id_descripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    imagen_url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    texto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descripciones", x => x.id_descripcion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Descripciones",
                columns: new[] { "id_descripcion", "imagen_url", "texto" },
                values: new object[,]
                {
                    { 1, "https://http2.mlstatic.com/D_NQ_NP_616775-MLA76602933995_052024-O.webp", "Filtro de aire original para Toyota Corolla" },
                    { 2, "https://http2.mlstatic.com/D_NQ_NP_836797-MLA80954735198_122024-O.webp", "Pastillas de freno originales para Ford Fiesta" }
                });

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 1,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 9, 0, 9, 8, 224, DateTimeKind.Local).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 2,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 9, 0, 9, 8, 224, DateTimeKind.Local).AddTicks(8811));
        }
    }
}
