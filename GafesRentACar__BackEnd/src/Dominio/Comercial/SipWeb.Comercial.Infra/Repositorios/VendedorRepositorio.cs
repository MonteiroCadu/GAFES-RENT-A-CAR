using SipWeb.Base.Infra;
using SipWeb.Base.Infra.Repositorios;
using SipWeb.Comercial.Core.Entidades;
using SipWeb.Comercial.Core.Repositorios;

namespace SipWeb.Comercial.Infra.Repositorios;
public class VendedorRepositorio : RepositorioBase<Vendedor>, IVendedorRepositorio
{
    public VendedorRepositorio(SipWebContext appDbContext) : base(appDbContext)
    {
    }
}
