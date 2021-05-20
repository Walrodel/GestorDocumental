using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Infrastucture.Data;
using System.Threading.Tasks;

namespace GestorDocumental.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestorDocumentalContext _context;

        private readonly IRepository<Tercero> _terceroRepositoty;

        public UnitOfWork(GestorDocumentalContext context)
        {
            _context = context;
        }

        public IRepository<Tercero> TerceroRepository => _terceroRepositoty ?? new BaseRepository<Tercero>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsyn()
        {
            await _context.SaveChangesAsync();
        }

    }
}
