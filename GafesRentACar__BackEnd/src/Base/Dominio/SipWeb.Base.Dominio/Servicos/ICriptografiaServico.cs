namespace SipWeb.Base.Dominio.Servicos;
public interface ICriptografiaServico
{
    bool ComparaSenhaSemMd5ComSenhaMd5(string senhaSemMd5, string SenhaMD5);
    string EncriptarMD5(string Senha);

}
