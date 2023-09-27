using SipWeb.Base.Infra;
using SipWeb.Base.Infra.Repositorios;
using SipWeb.Comercial.Core.Entidades;
using SipWeb.Comercial.Core.Repositorios;

namespace SipWeb.Comercial.Infra.Repositorios;
public class TamanhoRequisitoRepositorio : RepositorioBase<TamanhoRequisito>, ITamanhoRequisitoRepositorio
{
    public TamanhoRequisitoRepositorio(SipWebContext appDbContext) : base(appDbContext)
    {
    }
}
