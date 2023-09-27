using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SipWeb.Base.Dominio;
using SipWeb.Base.Dominio.Repositorios;
using SipWeb.Base.Infra.Repositorios;

namespace SipWeb.Base.Infra;
public static class InjecaoDependencias
{
    public static void InjetarInfraBase(this IServiceCollection services, IConfiguration configuration)
    {
        GestorDeMapeamentoDeEntidades.AddEntidadeMapPorAssembly(typeof(InjecaoDependencias).Assembly);
        services.AddDbContext<SipWebContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("sipweb")));
        
        services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddTransient<ISessaoRepositorio, SessaoRepositorio>(); 
        services.AddTransient<IReservaRepositorio, ReservaRepositorio>(); 
    }
}
