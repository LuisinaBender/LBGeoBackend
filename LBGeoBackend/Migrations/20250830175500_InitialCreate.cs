using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LBGeoBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nro_documento = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equivalencias",
                columns: table => new
                {
                    id_equivalencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_OEM_equivalente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_OEM_original = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equivalencias", x => x.id_equivalencia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    id_proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.id_proveedor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Repuestos",
                columns: table => new
                {
                    id_repuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    texto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    marca_auto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modelo_auto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_OEM_original = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    marca_OEM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    anio = table.Column<int>(type: "int", nullable: false),
                    motor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imagen_url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_proveedor = table.Column<int>(type: "int", nullable: false),
                    id_equivalencia = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuestos", x => x.id_repuesto);
                    table.ForeignKey(
                        name: "FK_Repuestos_Equivalencias_id_equivalencia",
                        column: x => x.id_equivalencia,
                        principalTable: "Equivalencias",
                        principalColumn: "id_equivalencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repuestos_Proveedores_id_proveedor",
                        column: x => x.id_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "id_proveedor",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistrosVentas",
                columns: table => new
                {
                    id_registro_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_repuesto = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    precio_total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosVentas", x => x.id_registro_venta);
                    table.ForeignKey(
                        name: "FK_RegistrosVentas_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosVentas_Repuestos_id_repuesto",
                        column: x => x.id_repuesto,
                        principalTable: "Repuestos",
                        principalColumn: "id_repuesto",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    id_registro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_repuesto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    precio_total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoAct = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_registro_venta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.id_registro);
                    table.ForeignKey(
                        name: "FK_Registros_RegistrosVentas_id_registro_venta",
                        column: x => x.id_registro_venta,
                        principalTable: "RegistrosVentas",
                        principalColumn: "id_registro_venta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registros_Repuestos_id_repuesto",
                        column: x => x.id_repuesto,
                        principalTable: "Repuestos",
                        principalColumn: "id_repuesto",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id_cliente", "Eliminado", "apellido", "direccion", "email", "nombre", "nro_documento", "telefono" },
                values: new object[,]
                {
                    { 1, false, "Pérez", "Calle Falsa 123", "juan@example.com", "Juan", 12345678, "3415551234" },
                    { 2, false, "Gómez", "Av. Libertad 456", "maria@example.com", "María", 87654321, "3415555678" },
                    { 3, false, "López", "San Juan 789", "carlos@example.com", "Carlos", 11223344, "3415551111" },
                    { 4, false, "Martínez", "Mitre 321", "ana@example.com", "Ana", 22334455, "3415552222" },
                    { 5, false, "Sosa", "Urquiza 654", "pedro@example.com", "Pedro", 33445566, "3415553333" },
                    { 6, false, "Fernández", "Belgrano 987", "lucia@example.com", "Lucía", 44556677, "3415554444" },
                    { 7, false, "Ramírez", "Italia 159", "miguel@example.com", "Miguel", 55667788, "3415555555" },
                    { 8, false, "Díaz", "España 753", "sofia@example.com", "Sofía", 66778899, "3415556666" },
                    { 9, false, "Torres", "Francia 852", "diego@example.com", "Diego", 77889900, "3415557777" },
                    { 10, false, "Molina", "Brasil 951", "valeria@example.com", "Valeria", 88990011, "3415558888" }
                });

            migrationBuilder.InsertData(
                table: "Equivalencias",
                columns: new[] { "id_equivalencia", "Eliminado", "codigo_OEM_equivalente", "codigo_OEM_original" },
                values: new object[,]
                {
                    { 1, false, "EQ-001", "OR-100" },
                    { 2, false, "EQ-002", "OR-200" },
                    { 3, false, "EQ-003", "OR-300" },
                    { 4, false, "EQ-004", "OR-400" },
                    { 5, false, "EQ-005", "OR-500" },
                    { 6, false, "EQ-006", "OR-600" },
                    { 7, false, "EQ-007", "OR-700" },
                    { 8, false, "EQ-008", "OR-800" },
                    { 9, false, "EQ-009", "OR-900" },
                    { 10, false, "EQ-010", "OR-1000" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "id_proveedor", "Eliminado", "direccion", "email", "nombre", "telefono" },
                values: new object[,]
                {
                    { 1, false, "San Martín 234", "ventas@rosario.com", "Repuestos Rosario", "3414440000" },
                    { 2, false, "Bv. Oroño 789", "contacto@santafe.com", "AutoPartes Santa Fe", "3414441111" },
                    { 3, false, "Córdoba 1234", "info@central.com", "Central Repuestos", "3414442222" },
                    { 4, false, "Mendoza 567", "ventas@todomotor.com", "Todo Motor", "3414443333" },
                    { 5, false, "San Luis 890", "contacto@distsur.com", "Distribuidora Sur", "3414444444" },
                    { 6, false, "Catamarca 321", "express@repuestos.com", "Repuestos Express", "3414445555" },
                    { 7, false, "Entre Ríos 654", "info@partesymas.com", "Partes y Más", "3414446666" },
                    { 8, false, "Salta 987", "ventas@mundoauto.com", "Mundo Auto", "3414447777" },
                    { 9, false, "Santa Fe 159", "norte@repuestos.com", "Repuestos Norte", "3414448888" },
                    { 10, false, "Buenos Aires 753", "info@casarepuesto.com", "La Casa del Repuesto", "3414449999" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id_usuario", "Eliminado", "Rol", "apellido", "email", "nombre" },
                values: new object[,]
                {
                    { 1, false, "Administrador", "Principal", "admin@lbgeo.com", "Admin" },
                    { 2, false, "Vendedor", "Ventas", "ventas@lbgeo.com", "Empleado" },
                    { 3, false, "Vendedor", "García", "sergio@lbgeo.com", "Sergio" },
                    { 4, false, "Vendedor", "Ruiz", "paula@lbgeo.com", "Paula" },
                    { 5, false, "Vendedor", "Mendez", "lucas@lbgeo.com", "Lucas" },
                    { 6, false, "Vendedor", "Sosa", "florencia@lbgeo.com", "Florencia" },
                    { 7, false, "Vendedor", "Paz", "martin@lbgeo.com", "Martín" },
                    { 8, false, "Vendedor", "Vega", "gabriela@lbgeo.com", "Gabriela" },
                    { 9, false, "Vendedor", "Silva", "javier@lbgeo.com", "Javier" },
                    { 10, false, "Vendedor", "Luna", "rocio@lbgeo.com", "Rocío" }
                });

            migrationBuilder.InsertData(
                table: "Repuestos",
                columns: new[] { "id_repuesto", "Eliminado", "anio", "codigo_OEM_original", "id_equivalencia", "id_proveedor", "imagen_url", "marca_OEM", "marca_auto", "modelo_auto", "motor", "precio", "stock", "texto" },
                values: new object[,]
                {
                    { 1, false, 2020, "OR-100", 1, 1, "https://http2.mlstatic.com/D_NQ_NP_616775-MLA76602933995_052024-O.webp", "Toyota", "Toyota", "Corolla", "1.8L", 15000, 15, "Filtro de aire original para Toyota Corolla" },
                    { 2, false, 2019, "OR-200", 2, 2, "https://http2.mlstatic.com/D_NQ_NP_836797-MLA80954735198_122024-O.webp", "Ford", "Ford", "Fiesta", "1.6L", 12000, 10, "Pastillas de freno originales para Ford Fiesta" },
                    { 3, false, 2021, "OR-300", 3, 3, "https://http2.mlstatic.com/D_NQ_NP_644123-MLA81012345678_052024-O.webp", "Chevrolet", "Chevrolet", "Onix", "1.4L", 8000, 20, "Bujía para Chevrolet Onix" },
                    { 4, false, 2022, "OR-400", 4, 4, "https://http2.mlstatic.com/D_NQ_NP_123456-MLA81234567890_052024-O.webp", "Shell", "Universal", "Todos", "Todos", 5000, 50, "Aceite sintético 5W30" },
                    { 5, false, 2018, "OR-500", 5, 5, "https://http2.mlstatic.com/D_NQ_NP_987654-MLA81234567891_052024-O.webp", "Volkswagen", "Volkswagen", "Gol", "1.6L", 6000, 18, "Filtro de aceite para VW Gol" },
                    { 6, false, 2017, "OR-600", 6, 6, "https://http2.mlstatic.com/D_NQ_NP_456789-MLA81234567892_052024-O.webp", "Renault", "Renault", "Clio", "1.2L", 20000, 8, "Amortiguador delantero Renault Clio" },
                    { 7, false, 2020, "OR-700", 7, 7, "https://http2.mlstatic.com/D_NQ_NP_567890-MLA81234567893_052024-O.webp", "Peugeot", "Peugeot", "208", "1.6L", 35000, 5, "Kit de embrague Peugeot 208" },
                    { 8, false, 2016, "OR-800", 8, 8, "https://http2.mlstatic.com/D_NQ_NP_678901-MLA81234567894_052024-O.webp", "Fiat", "Fiat", "Uno", "1.3L", 7000, 12, "Correa de distribución Fiat Uno" },
                    { 9, false, 2019, "OR-900", 9, 9, "https://http2.mlstatic.com/D_NQ_NP_789012-MLA81234567895_052024-O.webp", "Honda", "Honda", "Civic", "2.0L", 25000, 7, "Radiador Honda Civic" },
                    { 10, false, 2023, "OR-1000", 10, 10, "https://http2.mlstatic.com/D_NQ_NP_890123-MLA81234567896_052024-O.webp", "Willard", "Universal", "Todos", "Todos", 30000, 25, "Batería 12V 60Ah" }
                });

            migrationBuilder.InsertData(
                table: "RegistrosVentas",
                columns: new[] { "id_registro_venta", "Eliminado", "cantidad", "fecha_venta", "id_cliente", "id_repuesto", "precio_total", "precio_unitario" },
                values: new object[,]
                {
                    { 1, false, 2, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(257), 1, 1, 30000m, 15000m },
                    { 2, false, 1, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(258), 2, 2, 12000m, 12000m },
                    { 3, false, 3, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(260), 3, 3, 24000m, 8000m },
                    { 4, false, 1, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(262), 4, 4, 5000m, 5000m },
                    { 5, false, 2, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(264), 5, 5, 12000m, 6000m },
                    { 6, false, 1, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(266), 6, 6, 20000m, 20000m },
                    { 7, false, 1, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(270), 7, 7, 35000m, 35000m },
                    { 8, false, 2, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(276), 8, 8, 14000m, 7000m },
                    { 9, false, 1, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(277), 9, 9, 25000m, 25000m },
                    { 10, false, 1, new DateTime(2025, 8, 30, 14, 54, 58, 173, DateTimeKind.Local).AddTicks(279), 10, 10, 30000m, 30000m }
                });

            migrationBuilder.InsertData(
                table: "Registros",
                columns: new[] { "id_registro", "TipoAct", "cantidad", "eliminado", "fecha", "id_registro_venta", "id_repuesto", "precio_total", "precio_unitario" },
                values: new object[,]
                {
                    { 1, "Salida", 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 30000m, 15000m },
                    { 2, "Salida", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 12000m, 12000m },
                    { 3, "Salida", 3, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 24000m, 8000m },
                    { 4, "Salida", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 5000m, 5000m },
                    { 5, "Salida", 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 12000m, 6000m },
                    { 6, "Salida", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, 20000m, 20000m },
                    { 7, "Salida", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, 35000m, 35000m },
                    { 8, "Salida", 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8, 14000m, 7000m },
                    { 9, "Salida", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9, 25000m, 25000m },
                    { 10, "Salida", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10, 30000m, 30000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_registro_venta",
                table: "Registros",
                column: "id_registro_venta");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_repuesto",
                table: "Registros",
                column: "id_repuesto");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosVentas_id_cliente",
                table: "RegistrosVentas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosVentas_id_repuesto",
                table: "RegistrosVentas",
                column: "id_repuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Repuestos_id_equivalencia",
                table: "Repuestos",
                column: "id_equivalencia");

            migrationBuilder.CreateIndex(
                name: "IX_Repuestos_id_proveedor",
                table: "Repuestos",
                column: "id_proveedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "RegistrosVentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Repuestos");

            migrationBuilder.DropTable(
                name: "Equivalencias");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
