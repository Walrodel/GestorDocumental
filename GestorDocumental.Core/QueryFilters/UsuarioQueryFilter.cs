using GestorDocumental.Core.Enumerations;

namespace GestorDocumental.Core.QueryFilters
{
    public class UsuarioQueryFilter
    {
        public string UserName { get; set; }
        public TipoRol? Rol { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
