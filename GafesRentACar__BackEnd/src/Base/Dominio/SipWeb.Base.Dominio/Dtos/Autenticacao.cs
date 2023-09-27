namespace SipWeb.Base.Dominio.Dtos;
public class AutenticacaoUsuario
{

    public string HastToken { get; private set; }
    public DateTime DataExpiracao { get; private set; }
    public long UserId { get; set; }

    public AutenticacaoUsuario(string HastToken, DateTime DataExpiracao,long userId)
    {
        this.HastToken = HastToken;
        this.DataExpiracao = DataExpiracao;
        UserId = userId;
    }
}
