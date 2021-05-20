using System;

namespace GestorDocumental.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime? FechaActualiza { get; set; }
    }
}
