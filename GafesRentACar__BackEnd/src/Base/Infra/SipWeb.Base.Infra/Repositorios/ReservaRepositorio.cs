using SipWeb.Base.Dominio;
using SipWeb.Base.Infra.Repositorios;

namespace SipWeb.Base.Infra;

public class ReservaRepositorio : RepositorioBase<Reserva>, IReservaRepositorio
{
    public ReservaRepositorio(SipWebContext appDbContext) : base(appDbContext)
    {
    }
}
