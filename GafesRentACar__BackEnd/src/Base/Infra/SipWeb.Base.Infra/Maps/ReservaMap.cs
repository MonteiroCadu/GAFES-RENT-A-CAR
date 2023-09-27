using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SipWeb.Base.Dominio;

namespace SipWeb.Base.Infra.Maps;

public class ReservaMap : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("reservas")
            .HasKey(t => t.Id)
            .HasName("reservas_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(t => t.CarroId).HasColumnName("id_carro");
        builder.Property(t => t.UserId).HasColumnName("id_usuario");       
        builder.Property(t => t.Ativa).HasColumnName("ativa");
    }
}