namespace LBGeoBackend.Models
{
    public partial class Clientes
    {
        public int id_cliente { get; set; } 
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? telefono { get; set; }
        public string? email { get; set; }
        public string? direccion { get; set; }
        public int ? nro_documento { get; set; }
        public bool Eliminado { get; set; }

        // Relación: Un cliente puede tener muchas ventas
        public ICollection<RegistrosVentas> Ventas { get; set; } = new List<RegistrosVentas>();

    }
}
