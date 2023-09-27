using System.Linq.Expressions;
using SipWeb.Base.Dominio.Entidades;

namespace SipWeb.Base.Dominio.Repositorios;
public interface IRepositorioBase<T> where T : EntidadeBase
{
    Task<T> InserirAsync(T entidade);
    T Alterar(T entidade);
    void Deletar(T entidade);
    Task<int> SalvarMudancasAsync();
    Task<T?> ObterPeloIDAsync(long id, string[]? includes = null);
    Task<RetornoPaginado<IList<T>>> ObterTodosAsync(Paginacao? paginaDeBusca = default);
    Task<IList<T>?> ObterPorQueryAsync(Expression<Func<T, bool>> expressao, Paginacao? paginaDeBusca = null, string[]? includes = null);
}
