using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SipWeb.Base.Infra;
using SipWeb.Comercial.Core.Repositorios;
using SipWeb.Comercial.Infra.Repositorios;

namespace SipWeb.Comercial.Infra;
public static class InjecaoDependencias
{
    public static void InjetarComercialInfra(this IServiceCollection services, IConfigurationRoot configuration)
    {
        GestorDeMapeamentoDeEntidades.AddEntidadeMapPorAssembly(typeof(InjecaoDependencias).Assembly);

        services.AddTransient<IVendedorRepositorio, VendedorRepositorio>();
        services.AddTransient<IPrecoHoraRepositorio, PrecoHoraRepositorio>();
        services.AddTransient<ITamanhoRequisitoRepositorio,TamanhoRequisitoRepositorio>();
        services.AddTransient<IRequisitoProjetoRepositorio, RequisitoProjetoRepositorio>();
        services.AddTransient<IProjetoRepositorio, ProjetoRepositorio>();
    }
}
