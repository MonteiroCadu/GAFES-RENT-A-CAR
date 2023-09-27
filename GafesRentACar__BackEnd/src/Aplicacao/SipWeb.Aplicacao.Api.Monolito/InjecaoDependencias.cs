using SipWeb.Base.CasosDeUso;
using SipWeb.Base.Infra;
using SipWeb.Base.Servicos;

namespace SipWeb.Aplicacao.Api.Monolito;

public static class InjecaoDependencias
{
    public static void InjetarDependencias(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.InjetarInfraBase(configuration);
        services.InjetarCasosDeUsoBase(configuration);
        services.InjetarServicosBase();
    }
}
