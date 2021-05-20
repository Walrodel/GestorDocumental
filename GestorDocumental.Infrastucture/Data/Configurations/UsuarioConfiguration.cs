using GestorDocumental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDocumental.Infrastucture.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasOne(e => e.Tercero);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Rol)
                .IsRequired();

            builder.Property(e => e.TerceroId)
               .IsRequired();

            builder.Property(e => e.FechaCrea)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
