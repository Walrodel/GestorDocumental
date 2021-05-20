using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDocumental.Infrastucture.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly DbSet<T> _entities;

        public BaseRepository(GestorDocumentalContext context)
        {
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(Guid Id)
        {
            T entity = await GetById(Id);
            _entities.Remove(entity);
        }
    }
}
