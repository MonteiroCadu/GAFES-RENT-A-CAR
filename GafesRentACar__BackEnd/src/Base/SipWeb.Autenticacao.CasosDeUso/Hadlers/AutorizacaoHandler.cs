using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using SipWeb.Base.Dominio.Dtos;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Enuns;
using SipWeb.Base.Dominio.Repositorios;
using SipWeb.Base.Dominio.Servicos;
using System.Net.Http;

namespace SipWeb.Base.CasosDeUso.Hadlers;
public class AutorizacaoHandler : IAuthorizationHandler
{
    private readonly ISessaoRepositorio _sessaoRepositorio;
    private Sessao? sessao;
    private HttpContext? _httpContext;

    public AutorizacaoHandler(ISessaoRepositorio sessaoRepositorio)
    {
        this._sessaoRepositorio = sessaoRepositorio;
    }
    public async Task HandleAsync(AuthorizationHandlerContext context)
    {
        _httpContext = context.Resource as HttpContext;
        var usuarioNaoAutenticado = !((context.User.Identity?.IsAuthenticated ?? false) || string.IsNullOrEmpty(context.User?.Identity?.Name));

        if (usuarioNaoAutenticado)
        {
            context.Fail();
            return;
        }

        await ObterSessao();
        if (SessaoInValida())
        {
            context.Fail();
            return;
        }
    }

    private async Task ObterSessao()
    {
        sessao = await _sessaoRepositorio.ObterSessaoAsync();
    }

    private bool SessaoInValida()
    {
        return !(sessao?.Ativa ?? false && sessao.DataExpiracao > DateTime.Now);
    }

}