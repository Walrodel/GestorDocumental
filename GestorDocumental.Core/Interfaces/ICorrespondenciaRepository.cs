using GestorDocumental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Interfaces
{
    public interface ICorrespondenciaRepository : IRepository<Correspondencia>
    {
        Task<Correspondencia> GetByIdAndRelation(Guid Id);
        Task<IEnumerable<Correspondencia>> GetAllRelation();
        Task<int> GetMaxNumero();
    }
}
