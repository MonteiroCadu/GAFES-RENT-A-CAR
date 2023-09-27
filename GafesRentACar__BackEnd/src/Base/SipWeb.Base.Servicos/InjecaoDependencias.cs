using Microsoft.Extensions.DependencyInjection;
using SipWeb.Base.Dominio.Servicos;

namespace SipWeb.Base.Servicos;

public static class InjecaoDependencias
{
    public static void InjetarServicosBase(this IServiceCollection services)
    {
        services.AddTransient<ICriptografiaServico,CriptografiaServico>();
    }
}
