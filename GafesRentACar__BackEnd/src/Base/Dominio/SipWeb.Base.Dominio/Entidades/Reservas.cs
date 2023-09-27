using SipWeb.Base.Dominio.Entidades;

namespace SipWeb.Base.Dominio;

public class Reserva : EntidadeBase
{
    public long UserId { get; set; }
    public string CarroId { get; set; } = null!;
    public bool Ativa { get; set; }
}
