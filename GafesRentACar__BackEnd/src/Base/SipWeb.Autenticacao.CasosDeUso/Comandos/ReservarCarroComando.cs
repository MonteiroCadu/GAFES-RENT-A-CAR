using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Flunt.Validations;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio;

namespace SipWeb.Base.CasosDeUso;

[AutoMap (typeof(Reserva), ReverseMap = true )]
public class ReservarCarroComando : ComandoBase, IRequest<ComandoRetornoGenerico<Reserva>>
{
    [SetsRequiredMembers]
    public ReservarCarroComando(long userId, string carroId)
    {
        UserId = userId;
        CarroId = carroId;

        AddNotifications(
            new Contract()
            .Requires()
            );
    }

    public long UserId { get; set; }
    public string CarroId { get; set; } = null!;
}

public class LiberarReservaComando : ComandoBase, IRequest<ComandoRetornoGenerico<Reserva>> {
    public long Id { get; set; }

    public LiberarReservaComando(long id)
    {
        Id = id;
    }
}
