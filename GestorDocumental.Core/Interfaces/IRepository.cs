using GestorDocumental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid Id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(Guid Id);

    }
}
