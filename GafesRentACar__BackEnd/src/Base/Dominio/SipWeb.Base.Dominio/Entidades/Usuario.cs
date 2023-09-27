namespace SipWeb.Base.Dominio.Entidades;
public class Usuario : EntidadeBase
{
    public string Login { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string? Cpf { get; set; }
    public string? NomeCompleto { get; set; } 
    public bool Ativo { get; set; } = true;
}
