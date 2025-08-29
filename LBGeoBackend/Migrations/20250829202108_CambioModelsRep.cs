using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBGeoBackend.Migrations
{
    /// <inheritdoc />
    public partial class CambioModelsRep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_equivalencia",
                table: "Repuestos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 1,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 29, 17, 21, 6, 618, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 2,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 29, 17, 21, 6, 618, DateTimeKind.Local).AddTicks(8238));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_equivalencia",
                table: "Repuestos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 1,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 29, 14, 57, 33, 538, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "RegistrosVentas",
                keyColumn: "id_registro_venta",
                keyValue: 2,
                column: "fecha_venta",
                value: new DateTime(2025, 8, 29, 14, 57, 33, 538, DateTimeKind.Local).AddTicks(3744));
        }
    }
}
