using GestorDocumental.Core.CustomEntities;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.QueryFilters;
using System;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Interfaces
{
    public interface ITerceroService
    {
        Task<PageList<Tercero>> GetAll(TerceroQueryFilter filters);
        Task<Tercero> GetById(Guid Id);
        Task Add(Tercero model);
        Task<bool> Update(Tercero model);
        Task<bool> DeleteById(Guid Id);
    }
}
