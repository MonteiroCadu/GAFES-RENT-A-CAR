using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.Infra.Maps;
public class RequisitoProjetoMap : IEntityTypeConfiguration<RequisitoProjeto>
{
    void IEntityTypeConfiguration<RequisitoProjeto>.Configure(EntityTypeBuilder<RequisitoProjeto> builder)
    {
        builder.ToTable("requisitos_projeto")
            .HasKey(t => t.Id)
            .HasName("requisitos_projeto_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Titulo).HasColumnName("titulo");
        builder.Property(e => e.Descricao).HasColumnName("descricao");
        builder.Property(e => e.Valor).HasColumnName("valor");
        builder.Property(e => e.TamanhoID).HasColumnName("tamanho_id");
        builder.Property(e => e.PrecoHoraID).HasColumnName("preco_hora_id");
        builder.Property(e => e.ProjetoID).HasColumnName("projeto_id");

        builder.HasOne(t => t.ProjetoNavigation)
                .WithMany(t => t.Requisitos)
                .HasForeignKey(t => t.ProjetoID)
                .HasConstraintName("fk_projeto");
       
        builder.HasOne(t => t.TamanhoRequisitoNavigation)
               .WithMany()
               .HasForeignKey(t => t.TamanhoID)
               .HasConstraintName("fk_tamanho");
        
        builder.HasOne(t => t.PrecoHoraNavigation)
               .WithMany()
               .HasForeignKey(t => t.PrecoHoraID)
               .HasConstraintName("fk_preco_hora");
    }
}