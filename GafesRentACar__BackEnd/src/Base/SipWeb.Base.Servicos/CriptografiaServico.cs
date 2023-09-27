using SipWeb.Base.Dominio.Servicos;
using System.Security.Cryptography;
using System.Text;

namespace SipWeb.Base.Servicos;
public class CriptografiaServico : ICriptografiaServico
{
    public string EncriptarMD5(string Senha)
    {
        MD5 md5Hash = MD5.Create();
        return CriarHashMd5(md5Hash, Senha);
    }

    public bool ComparaSenhaSemMd5ComSenhaMd5(string senhaSemMd5, string SenhaMD5)
    {
        MD5 md5Hash = MD5.Create();
        var senha = EncriptarMD5(senhaSemMd5);
        return VerificarHash(md5Hash, SenhaMD5, senha);
    }

    private string CriarHashMd5(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    private bool VerificarHash(MD5 md5Hash, string input, string hash)
    {
        StringComparer compara = StringComparer.OrdinalIgnoreCase;
        return 0 == compara.Compare(input, hash) ? true : false;
    }
}
