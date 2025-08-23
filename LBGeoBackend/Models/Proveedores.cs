namespace LBGeoBackend.Models
{
    public partial class Proveedores
    {
        public int id_proveedor { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string direccion { get; set; } = "";
        public string? telefono { get; set; }
        public string? email { get; set; }

        public bool Eliminado { get; set; }
        public ICollection<Repuestos> Repuestos { get; set; } = new List<Repuestos>();

    }
}
