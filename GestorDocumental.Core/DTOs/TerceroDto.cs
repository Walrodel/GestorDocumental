using System;

namespace GestorDocumental.Core.DTOs
{
    public class TerceroDto
    {
        public Guid Id { get; set; }
        public string Identificaion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime? FechaActualiza { get; set; }
    }
}
