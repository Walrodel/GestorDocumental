using GestorDocumental.Core.Enumerations;
using System;

namespace GestorDocumental.Core.Request
{
    public class UsuarioRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public TipoRol Rol { get; set; }
        public Guid TerceroId { get; set; }
    }
}
