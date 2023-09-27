using Flunt.Validations;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace SipWeb.Base.CasosDeUso.Comandos;
public class FecharSessaoComando : ComandoBase, IRequest
{

    
    public required string Login { get; init ; }

    [SetsRequiredMembers]
    public FecharSessaoComando(string login)
    {
        Login = login;
        AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(login, "Login", "Informe um email de acesso válido")
            );
    }
}
