using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;

namespace SipWeb.Base.CasosDeUso;

public class DeletarUsuarioComando : ComandoBase, IRequest<ComandoRetornoGenerico<Unit>>
{
    public long UserId { get; set; }

    public DeletarUsuarioComando(long userId)
    {
        UserId = userId;
    }
}
