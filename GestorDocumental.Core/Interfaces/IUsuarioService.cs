using GestorDocumental.Core.CustomEntities;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.QueryFilters;
using System;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<PageList<Usuario>> GetAll(UsuarioQueryFilter filters);
        Task<Usuario> GetById(Guid Id);
        Task Add(Usuario model);
        Task<bool> Update(Usuario model);
        Task<bool> DeleteById(Guid Id);
    }
}
