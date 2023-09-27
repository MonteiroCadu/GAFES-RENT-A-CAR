using Flunt.Notifications;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SipWeb.Base.CasosDeUso.Comando;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Dtos;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;
using SipWeb.Base.Dominio.Servicos;
using SipWeb.Base.Dtos;
using SipWeb.Base.Infra.Queries.Usuarios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SipWeb.Base.CasosDeUso.Hadlers;
public class AutenticarHadler : Notifiable, IRequestHandler<AutenticarComando, ComandoRetornoGenerico<AutenticacaoUsuario>>
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly ISessaoRepositorio _sessaoRepositorio;
    private readonly TokenConfiguracao _tokenConfiguracao;
    private readonly ICriptografiaServico _criptografiaServico;

    public AutenticarHadler(
        IUsuarioRepositorio usuarioRepositorio,
        ISessaoRepositorio sessaoRepositorio,
        TokenConfiguracao tokenConfiguracao,
        ICriptografiaServico criptografiaServico)
    {
        this._usuarioRepositorio = usuarioRepositorio;
        this._sessaoRepositorio = sessaoRepositorio;
        this._tokenConfiguracao = tokenConfiguracao;
        this._criptografiaServico = criptografiaServico;
    }

    public async Task<ComandoRetornoGenerico<AutenticacaoUsuario>> Handle(AutenticarComando request, CancellationToken cancellationToken)
    {
        var comandoRetorno = new ComandoRetornoGenerico<AutenticacaoUsuario>();
        var usuario = await BuscaUsuarioPorLoginESenha(request);
        if (Valid)
        {
            var sessao = CriarESalvarSessao(usuario!);
            var autenticacaoUsuario = CriarAutenticacaoDoUsuario(sessao);
            comandoRetorno.Dados = autenticacaoUsuario;
        }
        comandoRetorno.AddNotifications(this.Notifications);
        return comandoRetorno;
    }

    private async Task<Usuario?> BuscaUsuarioPorLoginESenha(AutenticarComando request)
    {
       
        var usuario = (await _usuarioRepositorio.ObterPorQueryAsync(UsuarioQueries.BuscarPorLogin(request.Login)))?.FirstOrDefault();
        ValidarAcessoUsuario(usuario, request);

        return Valid ? usuario : null;
    }

    private Sessao CriarESalvarSessao(Usuario usuario)
    {

        var sessao = new Sessao(usuario.Id, _tokenConfiguracao.DataDeExpiracao,usuario.Login);
        _sessaoRepositorio.Salvar(sessao);
        return sessao;
    }


    private void ValidarAcessoUsuario(Usuario? usuario, AutenticarComando request)
    {
        if (usuario == null) AddNotification("Login incorreto", "Login ou Senha Incorretos!");
        if (!usuario?.Ativo ?? false) AddNotification("Acesso bloqueado", "Usuário inativo no sistema");

        if (Valid)
        {
            var senhaCorreta = _criptografiaServico.ComparaSenhaSemMd5ComSenhaMd5(request.Senha, usuario?.Senha ?? "");
            var usuarioLoginIncorreto = !(usuario != null && senhaCorreta);
            if (usuarioLoginIncorreto) AddNotification("Login incorreto", "Login ou Senha Incorretos!");
        }
    }

    private AutenticacaoUsuario CriarAutenticacaoDoUsuario(Sessao sessao)
    {
        var hasToken = CriarHashToken(sessao);
        var autenticacaoUsuario = new AutenticacaoUsuario(hasToken, sessao.DataExpiracao, sessao.UsuarioID);

        return autenticacaoUsuario;
    }

    private Claim[] CriarClamsDoToken(Sessao sessao)
    {
        Claim[] claims = new[] {
                new Claim(ClaimTypes.Hash, sessao.UsuarioID.ToString()),
                new Claim(ClaimTypes.Name, sessao.Login),
        };

        return claims;
    }

    private string CriarHashToken(Sessao sessao)
    {
        var claims = CriarClamsDoToken(sessao);

        var handlerToken = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = sessao.DataExpiracao,
            SigningCredentials = GetSigningCredentials()
        };
        var token = handlerToken.CreateToken(tokenDescriptor);
        return handlerToken.WriteToken(token);
    }

    private SigningCredentials GetSigningCredentials()
    {
        return new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(_tokenConfiguracao.Secret)),
                        SecurityAlgorithms.HmacSha256Signature);
    }
}
