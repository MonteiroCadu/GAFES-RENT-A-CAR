using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SipWeb.Base.CasosDeUso;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;
using SipWeb.Base.Dominio.Servicos;
using SipWeb.Base.Infra.Repositorios;

namespace SipWeb.Aplicacao.Api.Monolito.Controllers
{
    public class UsuarioController : BaseController
    {
        private IUsuarioRepositorio usuarioRepositorio;
        private readonly ICriptografiaServico criptografiaServico;

        public UsuarioController(
            IMediator mediator,
            ILogger<BaseController> logger,
            IUsuarioRepositorio usuarioRepositorio,
            ICriptografiaServico criptografiaServico) : base(mediator, logger)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.criptografiaServico = criptografiaServico;
        }


        //[Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            try
            {
                var resultado = await usuarioRepositorio.ObterTodosAsync();
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

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {

            try
            {
                var resultado = await usuarioRepositorio.ObterPeloIDAsync(id);
                
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


        [HttpPost]
        public async Task<ActionResult<ComandoRetornoGenerico<Usuario>>> Post(CadastrarUsuarioComando comando)
        {            
            return await EnviarComando<Usuario>(comando);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ComandoRetornoGenerico<Usuario>>> Put(long id, AlterarUsuarioComando comando)
        {
            comando.UserId = id;
            return await EnviarComando<Usuario>(comando);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ComandoRetornoGenerico<Usuario>>> Delete(long id)
        {
            var comando = new DeletarUsuarioComando(id);
            return await EnviarComando<Usuario>(comando);
        }

    }


}

