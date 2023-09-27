using Microsoft.EntityFrameworkCore;
using SipWeb.Base.Dominio;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;
using System.Linq.Expressions;

namespace SipWeb.Base.Infra.Repositorios;
public class RepositorioBase<T> : IRepositorioBase<T>
    where T : EntidadeBase
{
    private readonly SipWebContext _context;
    private DbSet<T>? colecao;

    public RepositorioBase(SipWebContext appDbContext)
    {
        _context = appDbContext;
        colecao = _context.Set<T>();
    }

    
    public void Deletar(T entidade)
    {
        _context.Remove(entidade);
    }

    public async Task<T?> ObterPeloIDAsync(long id, string[]? includes = null)
    {
        IQueryable<T> query = colecao!
                .Where(x => x.Id == id);

        if (includes != null)
            Include(ref query, includes);

        var entidade = await query.AsNoTracking()
                                  .FirstOrDefaultAsync();
        return entidade;
    }

    public async Task<IList<T>?> ObterPorQueryAsync(Expression<Func<T, bool>> expressao, Paginacao? paginaDeBusca = null, string[]? includes = null)
    {
        var pagina = ObterPaginaDeBusca(paginaDeBusca);
        IQueryable<T> query = colecao!
                .Where(expressao)
                .Take(pagina!.GetTake())
                .Skip(pagina.GetSkip());

        if (includes != null)
            Include(ref query, includes);

        var entidades = await query.AsNoTracking()
                                   .ToListAsync();
        return entidades;
    }

    public async Task<RetornoPaginado<IList<T>>> ObterTodosAsync(Paginacao? paginaDeBusca = default)
    {
        var pagina = ObterPaginaDeBusca(paginaDeBusca);
        IQueryable<T> query = colecao!
                .Take(pagina!.GetTake())
                .Skip(pagina.GetSkip())
                .AsNoTracking();

        var total = await query.CountAsync();
        IList<T> entidades = await query.ToListAsync();

        return new RetornoPaginado<IList<T>>(total, pagina.PaginaCorrente, pagina.TamanhoDaPagina, entidades);
    }

    protected bool PaginacaoNula(Paginacao? paginaDeBusca)
    {
        return paginaDeBusca == null || paginaDeBusca.PaginaCorrente == 0 || paginaDeBusca.TamanhoDaPagina == 0;
    }

    protected void Include(ref IQueryable<T> query, string[] includes)
    {
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
    }

    protected Paginacao ObterPaginaDeBusca(Paginacao? paginaDeBusca)
    {
        return PaginacaoNula(paginaDeBusca) ? new Paginacao(1, 100) : paginaDeBusca!;
    }

    public async Task<T> InserirAsync(T entidade)
    {
        _ =await _context.AddAsync(entidade);
        return entidade;
    }

    public T Alterar(T entidade)
    {
        _ =_context.Update(entidade);
        return entidade;
    }

    public async Task<int> SalvarMudancasAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
