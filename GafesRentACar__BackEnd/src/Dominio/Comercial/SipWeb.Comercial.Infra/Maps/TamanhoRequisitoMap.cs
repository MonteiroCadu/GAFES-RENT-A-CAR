using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.Infra.Maps;
public class TamanhoRequisitoMap : IEntityTypeConfiguration<TamanhoRequisito>
{
    void IEntityTypeConfiguration<TamanhoRequisito>.Configure(EntityTypeBuilder<TamanhoRequisito> builder)
    {
        builder.ToTable("tamanhos_requisitos")
            .HasKey(t => t.Id)
            .HasName("tamanhos_requisitos_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Nome).HasColumnName("nome");
        builder.Property(e => e.Descricao).HasColumnName("descricao");
        builder.Property(e => e.QuantidadeHoras).HasColumnName("qtd_horas");
    }
}