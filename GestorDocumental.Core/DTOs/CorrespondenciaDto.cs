using System;

namespace GestorDocumental.Core.DTOs
{
    public class CorrespondenciaDto
    {
        public Guid Id { get; set; }
        public string Consecutivo { get; set; }
        public string Tipo { get; set; }
        public string UrlArvhivo { get; set; }

        public TerceroDto Remitente { get; set; }
        public TerceroDto Destinatario { get; set; }

        public DateTime FechaCrea { get; set; }
        public DateTime? FechaActualiza { get; set; }
    }
}
