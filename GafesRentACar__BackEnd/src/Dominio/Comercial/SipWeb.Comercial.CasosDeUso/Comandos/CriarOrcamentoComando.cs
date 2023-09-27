using Flunt.Validations;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Comercial.Core.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace SipWeb.Comercial.CasosDeUso.Comandos;
public class CriarOrcamentoComando : ComandoBase, IRequest<ComandoRetornoGenerico<Projeto>>
{
    [SetsRequiredMembers]
    public CriarOrcamentoComando(long clienteID, long vendedorID, string titulo, string descricao)
    {
        ClienteID = clienteID;
        VendedorID = vendedorID;
        Titulo = titulo;
        Descricao = descricao;

        AddNotifications(
            new Contract()
            .Requires()
            .AreNotEquals(clienteID,0,"Id do Cliente","Informe um id valido para cliente")
            .AreNotEquals(VendedorID,0,"Id do Vendedor","Informe um id valido para Vendedor")
            .HasMinLen(Titulo, 10, "Titulo", "Informe um titulo com no minimo 10 caracteres")
            .HasMaxLen(Titulo,300,"Titulo","O Titulo deve possuir no maximo 300 caracteres")
            .HasMinLen(Descricao,10,"Descrição","A descrição deve possuir no minimo 10 caracteres")
            .HasMaxLen(Descricao,2000,"Descrição","A descrição deve possuir no maximo 2000 caracteres")
            );
    }

    public required long ClienteID { get; init; }
    public required long VendedorID { get; init; }
    public required string Titulo { get; init; }
    public required string Descricao { get; set; }
}
