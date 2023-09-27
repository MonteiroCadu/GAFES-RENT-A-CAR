using Flunt.Notifications;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;

namespace SipWeb.Base.CasosDeUso;

public class DeletarUsuarioHandler : Notifiable, IRequestHandler<DeletarUsuarioComando, ComandoRetornoGenerico<Unit>>
{
    private readonly IUsuarioRepositorio usuarioRepositorio;

    public DeletarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
    {
        this.usuarioRepositorio = usuarioRepositorio;
    }
    public async Task<ComandoRetornoGenerico<Unit>> Handle(DeletarUsuarioComando request, CancellationToken cancellationToken)
    {
        var comandoRetorno = new ComandoRetornoGenerico<Unit>();
        var usuario = await usuarioRepositorio.ObterPeloIDAsync(request.UserId);
        if(usuario is null) 
            comandoRetorno.AddNotification("Erro","Usuário não existe no banco de dados");
        else 
        {
            usuarioRepositorio.Deletar(usuario);
            await usuarioRepositorio.SalvarMudancasAsync();
        }

        return comandoRetorno;
    }
}
