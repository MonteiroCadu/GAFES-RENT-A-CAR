using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.Infra.Maps;
public class VendedorMap : IEntityTypeConfiguration<Vendedor>
{
    void IEntityTypeConfiguration<Vendedor>.Configure(EntityTypeBuilder<Vendedor> builder)
    {
        builder.ToTable("vendedores")
            .HasKey(t => t.Id)
            .HasName("vendedores_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.PessoaID).HasColumnName("pessoa_id");
        builder.Property(e => e.PercentualComissao).HasColumnName("percentual_comissao");

        builder.HasOne(x => x.PessoaNavigation);

        builder.HasMany(x => x.Projetos)
               .WithOne(x => x.VendedorNavigation);
    }
}