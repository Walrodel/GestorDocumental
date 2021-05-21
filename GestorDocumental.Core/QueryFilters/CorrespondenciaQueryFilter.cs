using GestorDocumental.Core.Enumerations;
using System;

namespace GestorDocumental.Core.QueryFilters
{
    public class CorrespondenciaQueryFilter
    {
        public string Consecutivo { get; set; }
        public TipoCorrespondencia? Tipo { get; set; }
        public Guid? RemitenteId { get; set; }
        public Guid? DestinatarioId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
