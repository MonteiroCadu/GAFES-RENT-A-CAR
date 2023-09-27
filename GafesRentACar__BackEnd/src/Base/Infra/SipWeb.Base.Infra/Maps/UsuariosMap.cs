using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SipWeb.Base.Dominio.Entidades;

namespace SipWeb.Base.Infra.Maps;
public class UsuariosMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios")
            .HasKey(t => t.Id)
            .HasName("usuarios_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(t => t.Login).HasColumnName("email_acesso");
        builder.Property(t => t.Senha).HasColumnName("senha");
        builder.Property(t => t.Cpf).HasColumnName("cpf");
        builder.Property(t => t.Ativo).HasColumnName("ativo");
        builder.Property(t => t.NomeCompleto).HasColumnName("nome_completo");
       
    }
}