using LBGeoBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace LBGeoBackend.DataContext
{
    public class LBGeoDbContext : DbContext
    {
        public LBGeoDbContext(DbContextOptions<LBGeoDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Descripciones> Descripciones { get; set; }
        public DbSet<Equivalencias> Equivalencias { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Registros> Registros { get; set; }
        public DbSet<RegistrosVentas> RegistrosVentas { get; set; }
        public DbSet<Repuestos> Repuestos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            // Descripciones
            modelBuilder.Entity<Descripciones>()
                .HasKey(d => d.id_descripcion);

            // Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasKey(u => u.id_usuario);

            // DATOS SEMILLAS ------------------------------------

            modelBuilder.Entity<Clientes>().HasData(
                new Clientes { id_cliente = 1, nombre = "Juan", apellido = "Pérez", telefono = "3415551234", email = "juan@example.com", direccion = "Calle Falsa 123", nro_documento = 12345678 },
                new Clientes { id_cliente = 2, nombre = "María", apellido = "Gómez", telefono = "3415555678", email = "maria@example.com", direccion = "Av. Libertad 456", nro_documento = 87654321 }
            );

            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { id_proveedor = 1, nombre = "Repuestos Rosario", dirreccion = "San Martín 234", telefono = "3414440000", email = "ventas@rosario.com" },
                new Proveedores { id_proveedor = 2, nombre = "AutoPartes Santa Fe", dirreccion = "Bv. Oroño 789", telefono = "3414441111", email = "contacto@santafe.com" }
            );

            modelBuilder.Entity<Equivalencias>().HasData(
                new Equivalencias { id_equivalencia = 1, codigo_OEM_equivalente = "EQ-001", codigo_OEM_original = "OR-100" },
                new Equivalencias { id_equivalencia = 2, codigo_OEM_equivalente = "EQ-002", codigo_OEM_original = "OR-200" }
            );

            modelBuilder.Entity<Repuestos>().HasData(
                new Repuestos { id_repuesto = 1, marca_auto = "Toyota", modelo_auto = "Corolla", codigo_OEM_original = "OR-100", marca_OEM = "Toyota", anio = 2020, motor = "1.8L", id_proveedor = 1, id_equivalencia = 1, precio = 15000 },
                new Repuestos { id_repuesto = 2, marca_auto = "Ford", modelo_auto = "Fiesta", codigo_OEM_original = "OR-200", marca_OEM = "Ford", anio = 2019, motor = "1.6L", id_proveedor = 2, id_equivalencia = 2, precio = 12000 }
            );

            modelBuilder.Entity<Descripciones>().HasData(
                new Descripciones { id_descripcion = 1, texto = "Filtro de aire original para Toyota Corolla", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_616775-MLA76602933995_052024-O.webp" },
                new Descripciones { id_descripcion = 2, texto = "Pastillas de freno originales para Ford Fiesta", imagen_url = "https://http2.mlstatic.com/D_NQ_NP_836797-MLA80954735198_122024-O.webp" +
                "" }
            );

            modelBuilder.Entity<RegistrosVentas>().HasData(
                new RegistrosVentas { id_registro_venta = 1, id_repuesto = 1, id_cliente = 1, cantidad = 2, precio_unitario = 15000, precio_total = 30000, fecha_venta = DateTime.Now },
                new RegistrosVentas { id_registro_venta = 2, id_repuesto = 2, id_cliente = 2, cantidad = 1, precio_unitario = 12000, precio_total = 12000, fecha_venta = DateTime.Now }
            );

            modelBuilder.Entity<Registros>().HasData(
                new Registros { id_registro = 1, id_registro_venta = 1, id_repuesto = 1, cantidad = 2, precio_unitario = 15000, precio_total = 30000 },
                new Registros { id_registro = 2, id_registro_venta = 2, id_repuesto = 2, cantidad = 1, precio_unitario = 12000, precio_total = 12000 }
            );

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios { id_usuario = 1, nombre = "Admin", apellido = "Principal", email = "admin@lbgeo.com", Rol = "Administrador" },
                new Usuarios { id_usuario = 2, nombre = "Empleado", apellido = "Ventas", email = "ventas@lbgeo.com", Rol = "Vendedor" }
            );
        }
    }
}
