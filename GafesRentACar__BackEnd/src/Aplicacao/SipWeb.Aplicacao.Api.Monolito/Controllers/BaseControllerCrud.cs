using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;

namespace SipWeb.Aplicacao.Api.Monolito.Controllers;

[Authorize]
public abstract class BaseControllerCrud<T> : BaseController
    where T : EntidadeBase
{
    private readonly IRepositorioBase<T> _repositorio;
    private readonly IMediator _mediator;

    public BaseControllerCrud(
        IRepositorioBase<T> repositorio,
        IMediator mediator,
        ILogger<BaseController> logger) : base(mediator, logger)
    {
        this._repositorio = repositorio;
        this._mediator = mediator;
    }

    [HttpGet]
    public virtual async Task<ActionResult<RetornoPaginado<IList<T>>>> Get([FromQuery] Paginacao paginaDeBusca)
    {
        return await ExecutarCunsulta<Paginacao, RetornoPaginado<IList<T>>>(_repositorio.ObterTodosAsync, paginaDeBusca);
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<T?>> Get(long id)
    {
        return await ExecutarCunsulta<long, string[]?, T?>(_repositorio.ObterPeloIDAsync, id);
    }

    [HttpPost]
    public virtual async Task<ActionResult<ComandoRetornoGenerico<T>>> Post(T entidade)
    {
        return await EnviarComando<T>(ComandoPost(entidade));
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<ComandoRetornoGenerico<T>>> Put(long id, T entidade)
    {
        return await EnviarComando<T>(ComandoPut(id, entidade));
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<ComandoRetornoGenerico<T>>> Delete(long id)
    {
        try
        {
            var retorno = await _mediator.Send(ComandoDelete(id)) as ComandoRetornoGenerico<T>;
            return retorno!.Valid ? NoContent() : StatusCode((retorno.StatusCodeDoErro ?? 500 ) , retorno.Notifications);
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, mensagemDeErroParaApi);
        }
    }

    protected abstract ComandoBase ComandoPost(T entidade);
    protected abstract ComandoBase ComandoPut(long id, T entidade);
    protected abstract ComandoBase ComandoDelete(long id);
}
