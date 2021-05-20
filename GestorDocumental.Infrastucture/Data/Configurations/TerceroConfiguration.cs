using GestorDocumental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDocumental.Infrastucture.Data.Configurations
{
    public class TerceroConfiguration : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.Identificaion)
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Apellidos)
                .HasMaxLength(100);

            builder.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.FechaCrea)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
