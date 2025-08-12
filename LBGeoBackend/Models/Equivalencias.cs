namespace LBGeoBackend.Models
{
    public partial class Equivalencias
    {
        public int id_equivalencia { get; set; }
        public string codigo_OEM_equivalente{ get; set; } = string.Empty;
        public string codigo_OEM_original { get; set; } = string.Empty;

        public bool Eliminado { get; set; }

        // Relación: Una equivalencia puede estar asociada a varios repuestos
        public ICollection<Repuestos> Repuestos { get; set; } = new List<Repuestos>();
    }
}
