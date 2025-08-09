using System.ComponentModel.DataAnnotations.Schema;

namespace LBGeoBackend.Models
{
    public partial class RegistrosVentas
    {
        public int id_registro_venta { get; set; }

        [ForeignKey("Repuesto")]
        public int id_repuesto { get; set; }

        [ForeignKey("Cliente")]
        public int id_cliente { get; set; }

        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal precio_total { get; set; }
        public DateTime fecha_venta { get; set; } = DateTime.Now;

        // Navegación
        public Clientes Cliente { get; set; }
        public Repuestos Repuesto { get; set; }
        public ICollection<Registros> Registros { get; set; } = new List<Registros>();

    }
}
