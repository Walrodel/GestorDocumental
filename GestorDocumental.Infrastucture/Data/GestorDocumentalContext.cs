using GestorDocumental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestorDocumental.Infrastucture.Data
{
    public class GestorDocumentalContext : DbContext
    {
        public GestorDocumentalContext()
        {
        }

        public GestorDocumentalContext(DbContextOptions<GestorDocumentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tercero> Terceros { get; set; }
        public virtual DbSet<Correspondencia> Correspondencias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
