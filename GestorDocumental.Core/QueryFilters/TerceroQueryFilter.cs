namespace GestorDocumental.Core.QueryFilters
{
    public class TerceroQueryFilter
    {
        public string Identificaion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
