using SipWeb.Base.Dominio.Entidades;

namespace SipWeb.Comercial.Core.Entidades;
public class PrecoHora : EntidadeBase
{
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public required decimal Valor { get; init; }
}
