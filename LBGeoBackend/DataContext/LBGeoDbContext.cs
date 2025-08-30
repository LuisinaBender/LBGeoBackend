using LBGeoBackend.Enums;
using LBGeoBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LBGeoBackend.DataContext
{
    public class LBGeoDbContext : DbContext
    {
        public LBGeoDbContext(DbContextOptions<LBGeoDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Equivalencias> Equivalencias { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Registros> Registros { get; set; }
        public DbSet<RegistrosVentas> RegistrosVentas { get; set; }
        public DbSet<Repuestos> Repuestos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Guardar el enum TipoActEnum como string en la base de datos
            modelBuilder.Entity<Registros>()
                .Property(r => r.TipoAct)
                .HasConversion<string>();

            // RELACIONES ------------------------------------

            // Clientes → RegistrosVentas
            modelBuilder.Entity<Clientes>()
                .HasKey(c => c.id_cliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(c => c.Ventas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.id_cliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Proveedores → Repuestos
            modelBuilder.Entity<Proveedores>()
                .HasKey(p => p.id_proveedor);

            modelBuilder.Entity<Proveedores>()
                .HasMany(p => p.Repuestos)
                .WithOne(r => r.Proveedor)
                .HasForeignKey(r => r.id_proveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // Equivalencias → Repuestos
            modelBuilder.Entity<Equivalencias>()
                .HasKey(e => e.id_equivalencia);

            modelBuilder.Entity<Equivalencias>()
                .HasMany(e => e.Repuestos)
                .WithOne(r => r.Equivalencia)
                .HasForeignKey(r => r.id_equivalencia)
                .OnDelete(DeleteBehavior.Restrict);

            // Repuestos → RegistrosVentas / Registros
            modelBuilder.Entity<Repuestos>()
                .HasKey(r => r.id_repuesto);

            modelBuilder.Entity<Repuestos>()
                .HasMany(r => r.Ventas)
                .WithOne(v => v.Repuesto)
                .HasForeignKey(v => v.id_repuesto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Repuestos>()
                .HasMany(r => r.Registros)
                .WithOne(reg => reg.Repuesto)
                .HasForeignKey(reg => reg.id_repuesto)
                .OnDelete(DeleteBehavior.Restrict);

            // RegistrosVentas → Registros
            modelBuilder.Entity<RegistrosVentas>()
                .HasKey(v => v.id_registro_venta);

            modelBuilder.Entity<RegistrosVentas>()
                .HasMany(v => v.Registros)
                .WithOne(reg => reg.RegistroVenta)
                .HasForeignKey(reg => reg.id_registro_venta)
                .OnDelete(DeleteBehavior.Restrict);

            // Registros
            modelBuilder.Entity<Registros>()
                .HasKey(reg => reg.id_registro);

            // Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasKey(u => u.id_usuario);

            // DATOS SEMILLAS ------------------------------------

            modelBuilder.Entity<Clientes>().HasData(
                new Clientes { id_cliente = 1, nombre = "Juan", apellido = "Pérez", telefono = "3415551234", email = "juan@example.com", direccion = "Calle Falsa 123", nro_documento = 12345678 },
                new Clientes { id_cliente = 2, nombre = "María", apellido = "Gómez", telefono = "3415555678", email = "maria@example.com", direccion = "Av. Libertad 456", nro_documento = 87654321 },
                new Clientes { id_cliente = 3, nombre = "Carlos", apellido = "López", telefono = "3415551111", email = "carlos@example.com", direccion = "San Juan 789", nro_documento = 11223344 },
                new Clientes { id_cliente = 4, nombre = "Ana", apellido = "Martínez", telefono = "3415552222", email = "ana@example.com", direccion = "Mitre 321", nro_documento = 22334455 },
                new Clientes { id_cliente = 5, nombre = "Pedro", apellido = "Sosa", telefono = "3415553333", email = "pedro@example.com", direccion = "Urquiza 654", nro_documento = 33445566 },
                new Clientes { id_cliente = 6, nombre = "Lucía", apellido = "Fernández", telefono = "3415554444", email = "lucia@example.com", direccion = "Belgrano 987", nro_documento = 44556677 },
                new Clientes { id_cliente = 7, nombre = "Miguel", apellido = "Ramírez", telefono = "3415555555", email = "miguel@example.com", direccion = "Italia 159", nro_documento = 55667788 },
                new Clientes { id_cliente = 8, nombre = "Sofía", apellido = "Díaz", telefono = "3415556666", email = "sofia@example.com", direccion = "España 753", nro_documento = 66778899 },
                new Clientes { id_cliente = 9, nombre = "Diego", apellido = "Torres", telefono = "3415557777", email = "diego@example.com", direccion = "Francia 852", nro_documento = 77889900 },
                new Clientes { id_cliente = 10, nombre = "Valeria", apellido = "Molina", telefono = "3415558888", email = "valeria@example.com", direccion = "Brasil 951", nro_documento = 88990011 }
            );

            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { id_proveedor = 1, nombre = "Repuestos Rosario", direccion = "San Martín 234", telefono = "3414440000", email = "ventas@rosario.com" },
                new Proveedores { id_proveedor = 2, nombre = "AutoPartes Santa Fe", direccion = "Bv. Oroño 789", telefono = "3414441111", email = "contacto@santafe.com" },
                new Proveedores { id_proveedor = 3, nombre = "Central Repuestos", direccion = "Córdoba 1234", telefono = "3414442222", email = "info@central.com" },
                new Proveedores { id_proveedor = 4, nombre = "Todo Motor", direccion = "Mendoza 567", telefono = "3414443333", email = "ventas@todomotor.com" },
                new Proveedores { id_proveedor = 5, nombre = "Distribuidora Sur", direccion = "San Luis 890", telefono = "3414444444", email = "contacto@distsur.com" },
                new Proveedores { id_proveedor = 6, nombre = "Repuestos Express", direccion = "Catamarca 321", telefono = "3414445555", email = "express@repuestos.com" },
                new Proveedores { id_proveedor = 7, nombre = "Partes y Más", direccion = "Entre Ríos 654", telefono = "3414446666", email = "info@partesymas.com" },
                new Proveedores { id_proveedor = 8, nombre = "Mundo Auto", direccion = "Salta 987", telefono = "3414447777", email = "ventas@mundoauto.com" },
                new Proveedores { id_proveedor = 9, nombre = "Repuestos Norte", direccion = "Santa Fe 159", telefono = "3414448888", email = "norte@repuestos.com" },
                new Proveedores { id_proveedor = 10, nombre = "La Casa del Repuesto", direccion = "Buenos Aires 753", telefono = "3414449999", email = "info@casarepuesto.com" }
            );

            modelBuilder.Entity<Equivalencias>().HasData(
                new Equivalencias { id_equivalencia = 1, codigo_OEM_equivalente = "EQ-001", codigo_OEM_original = "OR-100", Eliminado = false },
                new Equivalencias { id_equivalencia = 2, codigo_OEM_equivalente = "EQ-002", codigo_OEM_original = "OR-200", Eliminado = false },
                new Equivalencias { id_equivalencia = 3, codigo_OEM_equivalente = "EQ-003", codigo_OEM_original = "OR-300", Eliminado = false },
                new Equivalencias { id_equivalencia = 4, codigo_OEM_equivalente = "EQ-004", codigo_OEM_original = "OR-400", Eliminado = false },
                new Equivalencias { id_equivalencia = 5, codigo_OEM_equivalente = "EQ-005", codigo_OEM_original = "OR-500", Eliminado = false },
                new Equivalencias { id_equivalencia = 6, codigo_OEM_equivalente = "EQ-006", codigo_OEM_original = "OR-600", Eliminado = false },
                new Equivalencias { id_equivalencia = 7, codigo_OEM_equivalente = "EQ-007", codigo_OEM_original = "OR-700", Eliminado = false },
                new Equivalencias { id_equivalencia = 8, codigo_OEM_equivalente = "EQ-008", codigo_OEM_original = "OR-800", Eliminado = false },
                new Equivalencias { id_equivalencia = 9, codigo_OEM_equivalente = "EQ-009", codigo_OEM_original = "OR-900", Eliminado = false },
                new Equivalencias { id_equivalencia = 10, codigo_OEM_equivalente = "EQ-010", codigo_OEM_original = "OR-1000", Eliminado = false }
            );

            modelBuilder.Entity<Repuestos>().HasData(
             new Repuestos { id_repuesto = 1, texto = "Filtro de aire original para Toyota Corolla", marca_auto = "Toyota", modelo_auto = "Corolla", codigo_OEM_original = "OR-100", marca_OEM = "Toyota", anio = 2020, motor = "1.8L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_616775-MLA76602933995_052024-O.webp", id_proveedor = 1, id_equivalencia = 1, precio = 15000, stock = 15, Eliminado = false },
             new Repuestos { id_repuesto = 2, texto = "Pastillas de freno originales para Ford Fiesta", marca_auto = "Ford", modelo_auto = "Fiesta", codigo_OEM_original = "OR-200", marca_OEM = "Ford", anio = 2019, motor = "1.6L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_836797-MLA80954735198_122024-O.webp", id_proveedor = 2, id_equivalencia = 2, precio = 12000, stock = 10, Eliminado = false },
             new Repuestos { id_repuesto = 3, texto = "Bujía para Chevrolet Onix", marca_auto = "Chevrolet", modelo_auto = "Onix", codigo_OEM_original = "OR-300", marca_OEM = "Chevrolet", anio = 2021, motor = "1.4L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_644123-MLA81012345678_052024-O.webp", id_proveedor = 3, id_equivalencia = 3, precio = 8000, stock = 20, Eliminado = false },
             new Repuestos { id_repuesto = 4, texto = "Aceite sintético 5W30", marca_auto = "Universal", modelo_auto = "Todos", codigo_OEM_original = "OR-400", marca_OEM = "Shell", anio = 2022, motor = "Todos", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_123456-MLA81234567890_052024-O.webp", id_proveedor = 4, id_equivalencia = 4, precio = 5000, stock = 50, Eliminado = false },
             new Repuestos { id_repuesto = 5, texto = "Filtro de aceite para VW Gol", marca_auto = "Volkswagen", modelo_auto = "Gol", codigo_OEM_original = "OR-500", marca_OEM = "Volkswagen", anio = 2018, motor = "1.6L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_987654-MLA81234567891_052024-O.webp", id_proveedor = 5, id_equivalencia = 5, precio = 6000, stock = 18, Eliminado = false },
             new Repuestos { id_repuesto = 6, texto = "Amortiguador delantero Renault Clio", marca_auto = "Renault", modelo_auto = "Clio", codigo_OEM_original = "OR-600", marca_OEM = "Renault", anio = 2017, motor = "1.2L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_456789-MLA81234567892_052024-O.webp", id_proveedor = 6, id_equivalencia = 6, precio = 20000, stock = 8, Eliminado = false },
             new Repuestos { id_repuesto = 7, texto = "Kit de embrague Peugeot 208", marca_auto = "Peugeot", modelo_auto = "208", codigo_OEM_original = "OR-700", marca_OEM = "Peugeot", anio = 2020, motor = "1.6L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_567890-MLA81234567893_052024-O.webp", id_proveedor = 7, id_equivalencia = 7, precio = 35000, stock = 5, Eliminado = false },
             new Repuestos { id_repuesto = 8, texto = "Correa de distribución Fiat Uno", marca_auto = "Fiat", modelo_auto = "Uno", codigo_OEM_original = "OR-800", marca_OEM = "Fiat", anio = 2016, motor = "1.3L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_678901-MLA81234567894_052024-O.webp", id_proveedor = 8, id_equivalencia = 8, precio = 7000, stock = 12, Eliminado = false },
             new Repuestos { id_repuesto = 9, texto = "Radiador Honda Civic", marca_auto = "Honda", modelo_auto = "Civic", codigo_OEM_original = "OR-900", marca_OEM = "Honda", anio = 2019, motor = "2.0L", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_789012-MLA81234567895_052024-O.webp", id_proveedor = 9, id_equivalencia = 9, precio = 25000, stock = 7, Eliminado = false },
             new Repuestos { id_repuesto = 10, texto = "Batería 12V 60Ah", marca_auto = "Universal", modelo_auto = "Todos", codigo_OEM_original = "OR-1000", marca_OEM = "Willard", anio = 2023, motor = "Todos", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_890123-MLA81234567896_052024-O.webp", id_proveedor = 10, id_equivalencia = 10, precio = 30000, stock = 25, Eliminado = false }
         
            );

            modelBuilder.Entity<RegistrosVentas>().HasData(
                new RegistrosVentas { id_registro_venta = 1, id_repuesto = 1, id_cliente = 1, cantidad = 2, precio_unitario = 15000, precio_total = 30000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 2, id_repuesto = 2, id_cliente = 2, cantidad = 1, precio_unitario = 12000, precio_total = 12000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 3, id_repuesto = 3, id_cliente = 3, cantidad = 3, precio_unitario = 8000, precio_total = 24000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 4, id_repuesto = 4, id_cliente = 4, cantidad = 1, precio_unitario = 5000, precio_total = 5000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 5, id_repuesto = 5, id_cliente = 5, cantidad = 2, precio_unitario = 6000, precio_total = 12000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 6, id_repuesto = 6, id_cliente = 6, cantidad = 1, precio_unitario = 20000, precio_total = 20000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 7, id_repuesto = 7, id_cliente = 7, cantidad = 1, precio_unitario = 35000, precio_total = 35000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 8, id_repuesto = 8, id_cliente = 8, cantidad = 2, precio_unitario = 7000, precio_total = 14000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 9, id_repuesto = 9, id_cliente = 9, cantidad = 1, precio_unitario = 25000, precio_total = 25000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 10, id_repuesto = 10, id_cliente = 10, cantidad = 1, precio_unitario = 30000, precio_total = 30000, fecha_venta = DateTime.Now }
            );

            modelBuilder.Entity<Registros>().HasData(
                new Registros { id_registro = 1, id_registro_venta = 1, id_repuesto = 1, cantidad = 2, precio_unitario = 15000, precio_total = 30000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 2, id_registro_venta = 2, id_repuesto = 2, cantidad = 1, precio_unitario = 12000, precio_total = 12000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 3, id_registro_venta = 3, id_repuesto = 3, cantidad = 3, precio_unitario = 8000, precio_total = 24000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 4, id_registro_venta = 4, id_repuesto = 4, cantidad = 1, precio_unitario = 5000, precio_total = 5000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 5, id_registro_venta = 5, id_repuesto = 5, cantidad = 2, precio_unitario = 6000, precio_total = 12000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 6, id_registro_venta = 6, id_repuesto = 6, cantidad = 1, precio_unitario = 20000, precio_total = 20000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 7, id_registro_venta = 7, id_repuesto = 7, cantidad = 1, precio_unitario = 35000, precio_total = 35000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 8, id_registro_venta = 8, id_repuesto = 8, cantidad = 2, precio_unitario = 7000, precio_total = 14000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 9, id_registro_venta = 9, id_repuesto = 9, cantidad = 1, precio_unitario = 25000, precio_total = 25000, TipoAct = TipoActEnum.Salida },
                new Registros { id_registro = 10, id_registro_venta = 10, id_repuesto = 10, cantidad = 1, precio_unitario = 30000, precio_total = 30000, TipoAct = TipoActEnum.Salida }
            );

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios { id_usuario = 1, nombre = "Admin", apellido = "Principal", email = "admin@lbgeo.com", Rol = "Administrador" },
                new Usuarios { id_usuario = 2, nombre = "Empleado", apellido = "Ventas", email = "ventas@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 3, nombre = "Sergio", apellido = "García", email = "sergio@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 4, nombre = "Paula", apellido = "Ruiz", email = "paula@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 5, nombre = "Lucas", apellido = "Mendez", email = "lucas@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 6, nombre = "Florencia", apellido = "Sosa", email = "florencia@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 7, nombre = "Martín", apellido = "Paz", email = "martin@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 8, nombre = "Gabriela", apellido = "Vega", email = "gabriela@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 9, nombre = "Javier", apellido = "Silva", email = "javier@lbgeo.com", Rol = "Vendedor" },
                new Usuarios { id_usuario = 10, nombre = "Rocío", apellido = "Luna", email = "rocio@lbgeo.com", Rol = "Vendedor" }
            );
        }
    }
}