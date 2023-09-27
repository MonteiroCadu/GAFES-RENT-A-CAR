using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SipWeb.Base.CasosDeUso.Hadlers;

namespace SipWeb.Base.CasosDeUso;
public static class InjecaoDependencias
{
    public static void InjetarCasosDeUsoBase(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAuthorizationCore();
        services.AddTransient<IAuthorizationHandler, AutorizacaoHandler>();
    }
}
