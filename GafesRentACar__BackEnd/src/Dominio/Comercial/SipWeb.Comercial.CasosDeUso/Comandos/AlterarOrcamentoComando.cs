using AutoMapper;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Comercial.Core.Entidades;

namespace SipWeb.Comercial.CasosDeUso.Comandos;

[AutoMap(typeof(Projeto), ReverseMap = true)]
public class AlterarOrcamentoComando : ComandoBase, IRequest<ComandoRetornoGenerico<Projeto>>
{
    public required string Titulo { get; init; }
    public required string Descricao { get; init; }
    public long? VendedorID { get; set; }
    public int? PrazoEstimado { get; init; }
    public int? EsforsoEstimado { get; set; }
    public decimal? ValorOriginal { get; init; }
    public ICollection<RequisitoProjeto>? Requisitos { get; set; }
}
