using MediatR;
using Microsoft.AspNetCore.Mvc;
using SipWeb.Base.CasosDeUso.Comandos;

namespace SipWeb.Aplicacao.Api.Monolito.Controllers;

[Route("v1/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly ILogger<BaseController> _logger;
    private readonly IMediator _mediator;
    protected const string mensagemDeErroParaApi = "Desculpe o transtorno, houve um erro interno nao mapeado, nossa equipe estará trabalhando nisso.";
    protected const string mensagemDeErroParaLog = "Erro não mapeado no controler";
    public BaseController(IMediator mediator, ILogger<BaseController> logger)
    {
        this._mediator = mediator;
        _logger = logger;
    }

    protected virtual async Task<ActionResult<ComandoRetornoGenerico<TResult>>> EnviarComando<TResult>(ComandoBase comando)
    {
        var comandoRetorno = new ComandoRetornoGenerico<TResult> ();
        if (comando.Invalid)
        {
            comandoRetorno.AddNotifications(comando.Notifications);
            return BadRequest(comandoRetorno);
        }

        try
        {
            return comando is not null
                 ? Ok(await _mediator.Send(comando!))
                 : BadRequest(new { Message = "Solicitação invalida, informe um comando válido!" });
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, e.Message);
        }
    }

    protected virtual async Task<ActionResult> EnviarComando(ComandoBase comando)
    {
        if (comando.Invalid)
        {
            return BadRequest(comando.Notifications);
        }

        try
        {
            await _mediator.Send(comando!);
            return NoContent();
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, e.Message);
        }
    }

    protected virtual async Task<ActionResult> ExecutarCunsulta<TIn, TIncludes, TResult>(Func<TIn, TIncludes?, Task<TResult>> func, TIn dados, TIncludes? includes = default)
    {
        try
        {
            var resultado = await func(dados,includes);
            return resultado is not null
                     ? Ok(resultado)
                     : NotFound(new {message = "Registro não localizado" });
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500,mensagemDeErroParaApi);
        }
    }

    protected virtual async Task<ActionResult> ExecutarCunsulta<TIn, TResult>(Func<TIn, Task<TResult>> func, TIn dados)
    {
        try
        {
            var resultado = await func(dados );
            return resultado is not null
                     ? Ok(resultado)
                     : NotFound(new { message = "Registro não localizado" });
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, mensagemDeErroParaApi);
        }
    }

    protected virtual async Task<ActionResult> ExecutarCunsulta<TResult>(Func<Task<TResult>> func)
    {
        try
        {
            var resultado = await func();
            return resultado is not null
                     ? Ok(resultado)
                     : NotFound();
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, mensagemDeErroParaApi);
        }
    }

    protected void LogErro(Exception e)
    {
       var message = e.InnerException == null ? e.Message : e.InnerException.Message;
        var stackTrace = e.InnerException == null ? e.StackTrace : e.InnerException.StackTrace;
        _logger.LogError($"Message: {message}, stack trace: {stackTrace}");
    }
}
