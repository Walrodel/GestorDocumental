using GestorDocumental.Core.Enumerations;
using System;

namespace GestorDocumental.Core.Entities
{
    public class Correspondencia : BaseEntity
    {
        public int Numero { get; set; }
        public string Consecutivo { get; set; }
        public TipoCorrespondencia Tipo { get; set; }
        public string UrlArvhivo { get; set; }
        public Guid RemitenteId { get; set; }
        public Guid DestinatarioId { get; set; }

        public Tercero Remitemte { get; set; }
        public Tercero Destinatario { get; set; }
    }
}
