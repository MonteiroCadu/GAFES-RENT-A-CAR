using SipWeb.Base.Dominio.Entidades;
using System.Linq.Expressions;

namespace SipWeb.Base.Infra.Queries.Usuarios;
public static partial class UsuarioQueries
{
    public static Expression<Func<Usuario, bool>> BuscarPorLogin(string login)
    {
        return x => x.Login.Equals(login);
    }
}