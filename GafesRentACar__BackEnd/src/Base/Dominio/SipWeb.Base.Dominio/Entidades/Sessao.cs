using System.Diagnostics.CodeAnalysis;

namespace SipWeb.Base.Dominio.Entidades;
public class Sessao
{
    [SetsRequiredMembers]
    public Sessao(long usuarioID, DateTime dataExpiracao, string login
        )
    {
        UsuarioID = usuarioID;
        DataExpiracao = dataExpiracao;
        Login = login;
        Ativa = true;
    }

    public required long UsuarioID { get; init; }
    public required DateTime DataExpiracao { get; init; }
    public required string Login { get; init; }
    public bool Ativa { get; set; }
}
