using System.ComponentModel.DataAnnotations.Schema;

namespace LBGeoBackend.Models
{
    public partial class Repuestos
    {
        public int id_repuesto { get; set; }
        public string? texto { get; set; }
        public string marca_auto { get; set; }
        public string modelo_auto { get; set; }
        public string codigo_OEM_original { get; set; }
        public string marca_OEM { get; set; }
        public int anio { get; set; }
        public string motor { get; set; }
        public string? imagen_url { get; set; }

        [ForeignKey("Proveedor")]
        public int id_proveedor { get; set; }

        [ForeignKey("Equivalencia")]
        public int ? id_equivalencia { get; set; }

        public int precio { get; set; }

        public bool Eliminado { get; set; }

        // Navegación
        public Proveedores Proveedor { get; set; }
        public Equivalencias Equivalencia { get; set; }
        public ICollection<RegistrosVentas> Ventas { get; set; } = new List<RegistrosVentas>();
        public ICollection<Registros> Registros { get; set; } = new List<Registros>();


    }
}
