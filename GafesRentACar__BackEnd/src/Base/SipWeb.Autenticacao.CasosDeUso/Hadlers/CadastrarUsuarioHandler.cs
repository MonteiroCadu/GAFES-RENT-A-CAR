using System;
using AutoMapper;
using Flunt.Notifications;
using MediatR;
using SipWeb.Base.CasosDeUso.Comando;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Dtos;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;
using SipWeb.Base.Dominio.Servicos;
using SipWeb.Base.Dtos;

namespace SipWeb.Base.CasosDeUso.Hadlers
{
	public class CadastrarUsuarioHandler : Notifiable, IRequestHandler<CadastrarUsuarioComando, ComandoRetornoGenerico<Usuario>>
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly ICriptografiaServico criptografiaServico;
        private readonly IMapper mapper;

        public CadastrarUsuarioHandler(
            IUsuarioRepositorio usuarioRepositorio,
            ICriptografiaServico criptografiaServico,
            IMapper mapper)
		{
            this.usuarioRepositorio = usuarioRepositorio;
            this.criptografiaServico = criptografiaServico;
            this.mapper = mapper;
        }

        public async Task<ComandoRetornoGenerico<Usuario>> Handle(CadastrarUsuarioComando request, CancellationToken cancellationToken)
        {
            var comandoRetorno = new ComandoRetornoGenerico<Usuario>();
            var usuarioJaCadastrado = await usuarioRepositorio.ObterPorQueryAsync(x => x.Cpf == request.Cpf || x.Login == request.Login);
            if (usuarioJaCadastrado?.FirstOrDefault() != null)
                comandoRetorno.AddNotification("Usuario ja cadastrado","cpf ou login já cadastrado no banco de dados" );

            if(comandoRetorno.Valid)
            {
                var usuarioNovo = mapper.Map<Usuario>(request);
                usuarioNovo.Senha = criptografiaServico.EncriptarMD5(request.Senha);
                await usuarioRepositorio.InserirAsync(usuarioNovo);
                await usuarioRepositorio.SalvarMudancasAsync();
                comandoRetorno.Dados = usuarioNovo;
            }
            return comandoRetorno;
        }
    }
}

