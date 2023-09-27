using SipWeb.Base.Dominio.Entidades;

namespace SipWeb.Base.Dominio.Repositorios;
public interface ISessaoRepositorio 
{
    Task<Sessao?> ObterSessaoAsync();
    Task Salvar(Sessao sessao);
    Task<Sessao?> ObterPeloIDAsync(string login);
}
