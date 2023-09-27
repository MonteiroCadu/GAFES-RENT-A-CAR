namespace SipWeb.Base.Dominio;
public class RetornoPaginado<T> : Paginacao
{
    public int QuantidadeDeRegistrosDaConsulta { get; private set; }

    public RetornoPaginado() : base() { }

    public RetornoPaginado(int total, int paginaCorrente, int tamanhoPagina, T dados) 
        : base(paginaCorrente, tamanhoPagina)
    {
        Dados = dados;
        QuantidadeDeRegistrosDaConsulta = total;
    }

    public T? Dados { get; init; }
}
