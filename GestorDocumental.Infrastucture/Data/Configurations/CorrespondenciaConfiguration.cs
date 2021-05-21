using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GestorDocumental.Infrastucture.Data.Configurations
{
    public class CorrespondenciaConfiguration : IEntityTypeConfiguration<Correspondencia>
    {
        public void Configure(EntityTypeBuilder<Correspondencia> builder)
        {
            builder.HasOne(e => e.Remitente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Destinatario)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.Numero)
                .IsRequired();

            builder.Property(e => e.Consecutivo)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(2)
                .HasConversion(
                    x => x.ToString(),
                    x => (TipoCorrespondencia)Enum.Parse(typeof(TipoCorrespondencia), x)
                    );

            builder.Property(e => e.UrlArvhivo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.RemitenteId)
               .IsRequired();

            builder.Property(e => e.DestinatarioId)
               .IsRequired();

            builder.Property(e => e.FechaCrea)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
