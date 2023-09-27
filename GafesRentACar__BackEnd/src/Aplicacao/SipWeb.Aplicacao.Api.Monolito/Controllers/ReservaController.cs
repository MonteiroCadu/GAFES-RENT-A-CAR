using MediatR;
using Microsoft.AspNetCore.Mvc;
using SipWeb.Aplicacao.Api.Monolito.Controllers;
using SipWeb.Base.CasosDeUso;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio;

namespace SipWeb.Aplicacao.Api.Monolito;

public class ReservaController : BaseController
{
    private readonly IReservaRepositorio reservaRepositorio;

    public ReservaController(
        IMediator mediator,
        ILogger<BaseController> logger,
        IReservaRepositorio reservaRepositorio ) : base(mediator, logger)
    {
        this.reservaRepositorio = reservaRepositorio;
    }

    [HttpGet("userId/{userId}")]
    public async Task<ActionResult> GetAll(long userId)
    {

        try
        {
            var resultado = await reservaRepositorio.ObterPorQueryAsync(x => x.UserId == userId && x.Ativa);
            return resultado is not null
                        ? Ok(resultado)
                        : NotFound(new { message = "Nenhuma reserva" });
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, mensagemDeErroParaApi);
        }
    }

    [HttpGet("ativa/{carroID}")]
    public async Task<ActionResult> GetAtiva(string carroID)
    {

        try
        {
            var resultado = (await reservaRepositorio.ObterPorQueryAsync(x => x.CarroId == carroID && x.Ativa))?.FirstOrDefault();
            return resultado is not null
                        ? Ok(resultado)
                        : NoContent();
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, mensagemDeErroParaApi);
        }
    }

    [HttpGet("ativa/{carroID}/userID/{userID}")]
    public async Task<ActionResult> GetAtivaByUser(string carroID,long userID)
    {

        try
        {
            var resultado = (await reservaRepositorio.ObterPorQueryAsync(x => x.CarroId == carroID && x.Ativa && x.UserId == userID))?.FirstOrDefault();
            return resultado is not null
                        ? Ok(resultado)
                        : NoContent();
        }
        catch (Exception e)
        {
            LogErro(e);
            return StatusCode(500, mensagemDeErroParaApi);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ComandoRetornoGenerico<Reserva>>> reservar(ReservarCarroComando comando)
    {            
        return await EnviarComando<Reserva>(comando);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ComandoRetornoGenerico<Reserva>>> liberar(long id)
    {            
        var comando = new LiberarReservaComando(id);
        return await EnviarComando<Reserva>(comando);
    }

}
