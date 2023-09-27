using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.Infra.Maps;
public class ProjetoMap : IEntityTypeConfiguration<Projeto>
{
    void IEntityTypeConfiguration<Projeto>.Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.ToTable("projetos")
            .HasKey(t => t.Id)
            .HasName("projetos_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.ClienteID).HasColumnName("cliente_id");
        builder.Property(e => e.Status).HasColumnName("status_id");
        builder.Property(e => e.DataAbertura).HasColumnName("data_abertura");
        builder.Property(e => e.DataAprovacao).HasColumnName("data_aprovacao");
        builder.Property(e => e.ValorOriginal).HasColumnName("valor_original");
        builder.Property(e => e.ValorAprovado).HasColumnName("valor_aprovado");
        builder.Property(e => e.EsforsoEstimado).HasColumnName("esforso_estimado");
        builder.Property(e => e.PrazoEstimado).HasColumnName("prazo_estimado");
        builder.Property(e => e.DataEntrega).HasColumnName("data_entrega");
        builder.Property(e => e.VendedorID).HasColumnName("vendedor_id");
        builder.Property(e => e.Titulo).HasColumnName("titulo");
        builder.Property(e => e.Descricao).HasColumnName("descricao");

        builder.HasOne(t => t.VendedorNavigation)
               .WithMany(x => x.Projetos)
               .HasForeignKey(t => t.VendedorID)
               .HasConstraintName("fk_vendedor");

        builder.HasOne(t => t.ClienteNavigation)
               .WithMany()
               .HasForeignKey(t => t.ClienteID)
               .HasConstraintName("fk_cliente");
        
        builder.HasMany(t => t.Requisitos)
               .WithOne(t => t.ProjetoNavigation);
    }
}
