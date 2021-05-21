using GestorDocumental.Core.Enumerations;
using System;

namespace GestorDocumental.Core.Request
{
    public class CorrespondenciaRequest
    {
        public TipoCorrespondencia Tipo { get; set; }
        public string UrlArvhivo { get; set; }
        public Guid RemitenteId { get; set; }
        public Guid DestinatarioId { get; set; }
    }
}
