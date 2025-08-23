using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBGeoBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarColumnaDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dirreccion",
                table: "Proveedores");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "Proveedores",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "id_proveedor",
                keyValue: 1,
                column: "direccion",
                value: "San Martín 234");

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "id_proveedor",
                keyValue: 2,
                column: "direccion",
                value: "Bv. Oroño 789");

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 1,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 23, 17, 14, 3, 965, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 2,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 23, 17, 14, 3, 965, DateTimeKind.Local).AddTicks(4067));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "direccion",
                table: "Proveedores");

            migrationBuilder.AddColumn<string>(
                name: "dirreccion",
                table: "Proveedores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "id_proveedor",
                keyValue: 1,
                column: "dirreccion",
                value: "San Martín 234");

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "id_proveedor",
                keyValue: 2,
                column: "dirreccion",
                value: "Bv. Oroño 789");

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 1,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 12, 16, 47, 38, 245, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 2,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 12, 16, 47, 38, 245, DateTimeKind.Local).AddTicks(7017));
        }
    }
}
