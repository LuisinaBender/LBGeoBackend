using LBGeoBackend.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBGeoBackend.Models
{
    public partial class Registros
    {
        public int id_registro { get; set; }
        public int id_repuesto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal precio_total { get; set; }
        public DateTime fecha { get; set; }
        public TipoActEnum TipoAct { get; set; } = TipoActEnum.Entrada;
        public bool eliminado { get; set; }

        public virtual Repuestos? Repuesto { get; set; }
        public int? id_registro_venta { get; set; }
        public virtual RegistrosVentas? RegistroVenta { get; set; }
    }
}

