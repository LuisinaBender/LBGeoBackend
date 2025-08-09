using System.ComponentModel.DataAnnotations.Schema;

namespace LBGeoBackend.Models
{
    public partial class Registros
    {
        public int id_registro { get; set; }

        [ForeignKey("RegistroVenta")]
        public int id_registro_venta { get; set; }

        [ForeignKey("Repuesto")]
        public int id_repuesto { get; set; }

        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal precio_total { get; set; }

        // Navegación
        public RegistrosVentas RegistroVenta { get; set; }
        public Repuestos Repuesto { get; set; }
    }
}
