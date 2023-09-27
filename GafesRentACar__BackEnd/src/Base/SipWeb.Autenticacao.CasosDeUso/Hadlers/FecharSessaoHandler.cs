using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Repositorios;

namespace SipWeb.Base.CasosDeUso.Hadlers;
public class FecharSessaoHandler :  IRequestHandler<FecharSessaoComando>
{
    private readonly ISessaoRepositorio _sessaoRepositorio;

    public FecharSessaoHandler(ISessaoRepositorio sessaoRepositorio)
    {
        this._sessaoRepositorio = sessaoRepositorio;
    }
    public async Task Handle(FecharSessaoComando request, CancellationToken cancellationToken)
    {
        var sessao = await _sessaoRepositorio.ObterPeloIDAsync(request.Login);
        if (sessao != null)
        {
            sessao.Ativa = false;
            await _sessaoRepositorio.Salvar(sessao);
        }
    }
}
