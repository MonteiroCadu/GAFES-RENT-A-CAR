using SipWeb.Base.Dominio.Entidades;
using System.Text.Json.Serialization;

namespace SipWeb.Comercial.Core.Entidades;
public class RequisitoProjeto : EntidadeBase
{
    public required long ProjetoID { get; set; }
    public  required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public  long? TamanhoID { get; set; }
    public  long? PrecoHoraID { get; set; }
    public decimal? Valor { get; set; }
    
    [JsonIgnore]
    public Projeto? ProjetoNavigation { get; set; }
    public TamanhoRequisito? TamanhoRequisitoNavigation { get; set; }
    public PrecoHora? PrecoHoraNavigation { get; set; }
}
