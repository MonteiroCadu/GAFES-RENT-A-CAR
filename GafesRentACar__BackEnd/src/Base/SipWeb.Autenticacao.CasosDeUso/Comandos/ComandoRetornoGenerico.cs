using System.Text.Json.Serialization;

namespace SipWeb.Base.CasosDeUso.Comandos;
public class ComandoRetornoGenerico<T> : ComandoBase
{
    public T? Dados { get; set; }
    
    [JsonIgnore]
    public int? StatusCodeDoErro { get; set; }
}
