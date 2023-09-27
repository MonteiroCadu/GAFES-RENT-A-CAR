using Microsoft.EntityFrameworkCore;

namespace SipWeb.Base.Infra;
public class SipWebContext : DbContext
{

    public SipWebContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach(var assembly in GestorDeMapeamentoDeEntidades.Assemblies)
            modelBuilder.ApplyConfigurationsFromAssembly(
                                assembly, t => t.GetInterfaces()
                                                .Any(i => i.IsGenericType
                                                    && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }

}
