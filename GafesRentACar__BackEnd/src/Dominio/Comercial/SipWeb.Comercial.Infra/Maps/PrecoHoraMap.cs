using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.Infra.Maps;
public class PrecoHoraMap : IEntityTypeConfiguration<PrecoHora>
{
    void IEntityTypeConfiguration<PrecoHora>.Configure(EntityTypeBuilder<PrecoHora> builder)
    {
        builder.ToTable("precos_horas")
            .HasKey(t => t.Id)
            .HasName("grupos_autorizacoes_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Nome).HasColumnName("nome");
        builder.Property(e => e.Descricao).HasColumnName("descricao");
        builder.Property(e => e.Valor).HasColumnName("valor");
    }
}