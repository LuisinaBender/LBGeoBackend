namespace LBGeoBackend.Models
{
    public partial class Usuarios
    {
        public int id_usuario { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }

        public string? Rol { get; set; } // Puede ser "Administrador", "Cliente", etc.

    }
}
