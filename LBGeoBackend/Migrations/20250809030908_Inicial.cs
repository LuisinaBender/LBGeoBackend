using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LBGeoBackend.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
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
                    nro_documento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Descripciones",
                columns: table => new
                {
                    id_descripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    texto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imagen_url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descripciones", x => x.id_descripcion);
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    dirreccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    id_proveedor = table.Column<int>(type: "int", nullable: false),
                    id_equivalencia = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
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
                    fecha_venta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    id_registro_venta = table.Column<int>(type: "int", nullable: false),
                    id_repuesto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    precio_total = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
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
                columns: new[] { "id_cliente", "apellido", "direccion", "email", "nombre", "nro_documento", "telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Calle Falsa 123", "juan@example.com", "Juan", 12345678, "3415551234" },
                    { 2, "Gómez", "Av. Libertad 456", "maria@example.com", "María", 87654321, "3415555678" }
                });

            migrationBuilder.InsertData(
                table: "Descripciones",
                columns: new[] { "id_descripcion", "imagen_url", "texto" },
                values: new object[,]
                {
                    { 1, "https://http2.mlstatic.com/D_NQ_NP_616775-MLA76602933995_052024-O.webp", "Filtro de aire original para Toyota Corolla" },
                    { 2, "https://http2.mlstatic.com/D_NQ_NP_836797-MLA80954735198_122024-O.webp", "Pastillas de freno originales para Ford Fiesta" }
                });

            migrationBuilder.InsertData(
                table: "Equivalencias",
                columns: new[] { "id_equivalencia", "codigo_OEM_equivalente", "codigo_OEM_original" },
                values: new object[,]
                {
                    { 1, "EQ-001", "OR-100" },
                    { 2, "EQ-002", "OR-200" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "id_proveedor", "dirreccion", "email", "nombre", "telefono" },
                values: new object[,]
                {
                    { 1, "San Martín 234", "ventas@rosario.com", "Repuestos Rosario", "3414440000" },
                    { 2, "Bv. Oroño 789", "contacto@santafe.com", "AutoPartes Santa Fe", "3414441111" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id_usuario", "Rol", "apellido", "email", "nombre" },
                values: new object[,]
                {
                    { 1, "Administrador", "Principal", "admin@lbgeo.com", "Admin" },
                    { 2, "Vendedor", "Ventas", "ventas@lbgeo.com", "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "Repuestos",
                columns: new[] { "id_repuesto", "anio", "codigo_OEM_original", "id_equivalencia", "id_proveedor", "marca_OEM", "marca_auto", "modelo_auto", "motor", "precio" },
                values: new object[,]
                {
                    { 1, 2020, "OR-100", 1, 1, "Toyota", "Toyota", "Corolla", "1.8L", 15000 },
                    { 2, 2019, "OR-200", 2, 2, "Ford", "Ford", "Fiesta", "1.6L", 12000 }
                });

            migrationBuilder.InsertData(
                table: "RegistrosVentas",
                columns: new[] { "id_registro_venta", "cantidad", "fecha_venta", "id_cliente", "id_repuesto", "precio_total", "precio_unitario" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 8, 9, 0, 9, 8, 224, DateTimeKind.Local).AddTicks(8808), 1, 1, 30000m, 15000m },
                    { 2, 1, new DateTime(2025, 8, 9, 0, 9, 8, 224, DateTimeKind.Local).AddTicks(8811), 2, 2, 12000m, 12000m }
                });

            migrationBuilder.InsertData(
                table: "Registros",
                columns: new[] { "id_registro", "cantidad", "id_registro_venta", "id_repuesto", "precio_total", "precio_unitario" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, 30000m, 15000m },
                    { 2, 1, 2, 2, 12000m, 12000m }
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
                name: "Descripciones");

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
