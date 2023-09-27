using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;

namespace SipWeb.Base.Infra.Repositorios;
public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(SipWebContext appDbContext) : base(appDbContext)
    {
    }
}
