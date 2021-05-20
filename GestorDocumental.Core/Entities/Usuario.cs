using GestorDocumental.Core.Enumerations;
using System;

namespace GestorDocumental.Core.Entities
{
    public class Usuario: BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Rol  Rol { get; set; }
        public Guid TerceroId { get; set; }

        public Tercero Tercero { get; set; }
    }
}
