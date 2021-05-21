using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDocumental.Infrastucture.Repositories
{
    public class CorrespondenciaRepository : BaseRepository<Correspondencia>, ICorrespondenciaRepository
    {
        public CorrespondenciaRepository(GestorDocumentalContext context) : base(context) { }

        public async Task<Correspondencia> GetByIdAndRelation(Guid Id)
        {
            return await _entities.Include(x => x.Remitente).Include(x => x.Destinatario).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Correspondencia>> GetAllRelation()
        {
            return await _entities.Include(x => x.Remitente).Include(x => x.Destinatario).ToListAsync();
        }

        public async Task<int> GetMaxNumero()
        {
            var result = await _entities.MaxAsync(x => (int?)x.Numero);
            return result is null ? 0 : (int)result;
        }
    }
}
