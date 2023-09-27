using SipWeb.Base.Dominio.Entidades;

namespace SipWeb.Comercial.Core.Entidades;
public class TamanhoRequisito : EntidadeBase
{
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public required string QuantidadeHoras { get; init; }
}
