namespace SipWeb.Base.Dtos;
public record TokenConfiguracao
{
    public string Secret { get; init; } = string.Empty;
    public int TempoExpiracaoEmHoras { get; init; }
    public DateTime DataDeExpiracao
    {
        get
        {
            return DateTime.Now.AddHours(TempoExpiracaoEmHoras);
        }
    }

}
