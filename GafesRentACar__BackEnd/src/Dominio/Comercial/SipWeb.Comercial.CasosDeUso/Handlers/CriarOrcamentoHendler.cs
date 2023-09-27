using Flunt.Notifications;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Comercial.CasosDeUso.Comandos;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.CasosDeUso.Handlers;
public class CriarOrcamentoHendler : Notifiable, IRequestHandler<CriarOrcamentoComando, ComandoRetornoGenerico<Projeto>>
{
    public Task<ComandoRetornoGenerico<Projeto>> Handle(CriarOrcamentoComando request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
