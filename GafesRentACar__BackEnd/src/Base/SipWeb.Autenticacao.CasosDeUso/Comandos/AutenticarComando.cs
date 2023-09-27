using Flunt.Validations;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace SipWeb.Base.CasosDeUso.Comando;
public class AutenticarComando : ComandoBase, IRequest<ComandoRetornoGenerico<AutenticacaoUsuario>>
{
    [SetsRequiredMembers]
    public AutenticarComando(string login, string senha)
    {
        Login = login;
        Senha = senha;

        AddNotifications(
            new Contract()
            .Requires()
            .IsEmail(login,"Login","Informe um email de acesso válido")
            .HasMinLen(senha,5,"Senha","Informe uma senha com no minimo 8 caracteres")
            );
    }

    public  required string  Login { get; init; }
    public required string Senha { get; init; }
}
