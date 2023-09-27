using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Flunt.Notifications;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio;

namespace SipWeb.Base.CasosDeUso;

public class ReservarCarroHandler : Notifiable, IRequestHandler<ReservarCarroComando, ComandoRetornoGenerico<Reserva>>
{
    private readonly IReservaRepositorio reservaRepositorio;
    private readonly IMapper mapper;

    public ReservarCarroHandler(
        IReservaRepositorio reservaRepositorio,
        IMapper mapper)
    {
        this.reservaRepositorio = reservaRepositorio;
        this.mapper = mapper;
    }

    public async Task<ComandoRetornoGenerico<Reserva>> Handle(ReservarCarroComando request, CancellationToken cancellationToken)
    {
        var reservaAtivaExistenteParaOMesmoCarro = 
        (await reservaRepositorio.ObterPorQueryAsync(x => x.CarroId == request.CarroId && x.Ativa))?.FirstOrDefault();
        var comandoRetorno = new ComandoRetornoGenerico<Reserva>();

        if(reservaAtivaExistenteParaOMesmoCarro is not null) 
        {
            comandoRetorno.AddNotification("Erro ao reservar", "Existe uma reserva ativa para este carro!");
        } 
        else
        {
            var novaReserva = mapper.Map<Reserva>(request);
            novaReserva.Ativa = true;
            await reservaRepositorio.InserirAsync(novaReserva);
            await reservaRepositorio.SalvarMudancasAsync();
            comandoRetorno.Dados = novaReserva;
        } 
        return comandoRetorno;
    }
}
