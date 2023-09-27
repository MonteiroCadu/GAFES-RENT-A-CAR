using MediatR;
using Microsoft.AspNetCore.Mvc;
using SipWeb.Base.CasosDeUso.Comando;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Dtos;

namespace SipWeb.Aplicacao.Api.Monolito.Controllers;

public class AutenticarController : BaseController
{
    public AutenticarController(IMediator mediator, ILogger<BaseController> logger) : base(mediator, logger)
    {

    }

    [HttpPost]
    public async Task<ActionResult<ComandoRetornoGenerico<AutenticacaoUsuario>>> Post(AutenticarComando comando)
    {
        return await EnviarComando<AutenticacaoUsuario>(comando);
    }
}
