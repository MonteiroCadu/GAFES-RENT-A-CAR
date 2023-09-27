using SipWeb.Base.Infra;
using SipWeb.Base.Infra.Repositorios;
using SipWeb.Comercial.Core.Entidades;
using SipWeb.Comercial.Core.Repositorios;

namespace SipWeb.Comercial.Infra.Repositorios;
public class ProjetoRepositorio : RepositorioBase<Projeto>, IProjetoRepositorio
{
    public ProjetoRepositorio(SipWebContext appDbContext) : base(appDbContext)
    {
    }
}
