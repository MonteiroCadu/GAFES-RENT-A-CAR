using AutoMapper;
using Flunt.Notifications;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio;

namespace SipWeb.Base.CasosDeUso;

public class LiberarReservaHandler : Notifiable, IRequestHandler<LiberarReservaComando, ComandoRetornoGenerico<Reserva>>
{
    private readonly IReservaRepositorio reservaRepositorio;
    private readonly IMapper mapper;

    public LiberarReservaHandler(
        IReservaRepositorio reservaRepositorio,
        IMapper mapper)
    {
        this.reservaRepositorio = reservaRepositorio;
        this.mapper = mapper;
    }
    public async Task<ComandoRetornoGenerico<Reserva>> Handle(LiberarReservaComando request, CancellationToken cancellationToken)
    {
        var reserva = 
        (await reservaRepositorio.ObterPorQueryAsync(x => x.Id == request.Id))?.FirstOrDefault();
        var comandoRetorno = new ComandoRetornoGenerico<Reserva>();

        if(reserva is null) 
        {
            comandoRetorno.AddNotification("Erro ao liberar reservar", "reserva não localizada!");
        } 
        else
        {
            reserva.Ativa = false;
            reservaRepositorio.Alterar(reserva);
            await reservaRepositorio.SalvarMudancasAsync();
            comandoRetorno.Dados = reserva;
        } 
        return comandoRetorno;
    }
}
