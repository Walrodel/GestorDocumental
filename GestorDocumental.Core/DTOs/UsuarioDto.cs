using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDocumental.Core.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public Guid TerceroId { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime? FechaActualiza { get; set; }
    }
}
