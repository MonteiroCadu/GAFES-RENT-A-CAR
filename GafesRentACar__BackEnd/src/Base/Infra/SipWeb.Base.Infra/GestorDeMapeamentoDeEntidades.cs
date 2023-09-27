using System.Collections.ObjectModel;
using System.Reflection;

namespace SipWeb.Base.Infra;
public static class GestorDeMapeamentoDeEntidades
{
    private static List<Assembly> _assemblies = new List<Assembly>();
    public static IReadOnlyCollection<Assembly> Assemblies => new ReadOnlyCollection<Assembly>(_assemblies);
    public static void AddEntidadeMapPorAssembly(Assembly assembly)
    {
        if(!_assemblies.Contains(assembly))
            _assemblies.Add(assembly);
    }
}
