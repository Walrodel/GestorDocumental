using GestorDocumental.Core.Entities;
using System;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Tercero> TerceroRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }

        void SaveChanges();
        Task SaveChangesAsyn();
    }
}
