using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBGeoBackend.Migrations
{
    /// <inheritdoc />
    public partial class MakeIdEquivalenciaNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
