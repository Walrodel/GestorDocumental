using GestorDocumental.Core.CustomEntities;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.QueryFilters;
using System;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Interfaces
{
    public interface ICorrespondenciaService
    {
        Task Add(Correspondencia model);
        Task<Correspondencia> GetById(Guid Id);
        Task<PageList<Correspondencia>> GetAll(CorrespondenciaQueryFilter filters);
    }
}
