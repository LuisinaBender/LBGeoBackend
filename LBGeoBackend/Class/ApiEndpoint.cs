namespace LBGeoBackend.Class
{
    public static class ApiEndpoint
    {
        public static string Cliente { get; set; } = "clientes";
        public static string Descripcion { get; set; } = "descripciones";
        public static string Equivalencia { get; set; } = "equivalencias";
        public static string Proveedor { get; set; } = "proveedores";
        public static string Registro { get; set; } = "registros";
        public static string RegistroVenta { get; set; } = "registrosventas";
        public static string Repuesto { get; set; } = "repuestos";
        public static string Usuario { get; set; } = "usuarios";

        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Cliente) => Cliente,
                nameof(Descripcion) => Descripcion,
                nameof(Equivalencia) => Equivalencia,
                nameof(Proveedor) => Proveedor,
                nameof(Registro) => Registro,
                nameof(RegistroVenta) => RegistroVenta,
                nameof(Repuesto) => Repuesto,
                nameof(Usuario) => Usuario,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}
