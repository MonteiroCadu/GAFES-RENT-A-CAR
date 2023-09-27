using System.Text.Json.Serialization;

namespace SipWeb.Base.Dominio;
public class Paginacao
{
    private int skip;
    private int take;

    private int _TamanhoDaPagina;
    public int TamanhoDaPagina 
    {
        get 
        {
            
            return _TamanhoDaPagina;
        }
        init 
        {
            _TamanhoDaPagina = value;
            take = _TamanhoDaPagina;
        } 
    }
    private int _Pagina;
    public int PaginaCorrente
    {
        get
        {
            return _Pagina;
        }
        init
        {
            _Pagina = value;
            skip = _Pagina == 1 ? 0 : (_TamanhoDaPagina * _Pagina);
        }
    }

    public Paginacao() { }
    public Paginacao(int paginaCorrente, int tamanhoPagina)
    {
        TamanhoDaPagina = tamanhoPagina;
        PaginaCorrente = paginaCorrente;
    }

    public int GetSkip()
    {
        return skip;
    }

    public int GetTake()
    {
        return take;
    }
}
