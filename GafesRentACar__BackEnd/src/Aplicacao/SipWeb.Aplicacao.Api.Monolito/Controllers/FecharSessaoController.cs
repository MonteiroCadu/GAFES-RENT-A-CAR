using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SipWeb.Base.CasosDeUso.Comandos;

namespace SipWeb.Aplicacao.Api.Monolito.Controllers;

public class FecharSessaoController : BaseController
{
    public FecharSessaoController(IMediator mediator, ILogger<BaseController> logger) : base(mediator, logger)
    {
    }

    [Authorize]
    [HttpPut("{login}")]
    public async Task<ActionResult> Post(string login)
    {
        FecharSessaoComando fecharSessaoComando = new FecharSessaoComando (login);
        return await EnviarComando(fecharSessaoComando);
    }
}
