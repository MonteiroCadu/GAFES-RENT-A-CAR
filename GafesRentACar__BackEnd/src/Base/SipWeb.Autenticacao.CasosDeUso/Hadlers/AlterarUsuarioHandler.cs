using System;
using AutoMapper;
using Flunt.Notifications;
using MediatR;
using SipWeb.Base.CasosDeUso.Comandos;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;
using SipWeb.Base.Dominio.Servicos;

namespace SipWeb.Base.CasosDeUso.Hadlers
{
	public class AlterarUsuarioHandler : Notifiable, IRequestHandler<AlterarUsuarioComando, ComandoRetornoGenerico<Usuario>>
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly ICriptografiaServico criptografiaServico;
        private readonly IMapper mapper;

        public AlterarUsuarioHandler(
            IUsuarioRepositorio usuarioRepositorio,
            ICriptografiaServico criptografiaServico,
            IMapper mapper)
		{
            this.usuarioRepositorio = usuarioRepositorio;
            this.criptografiaServico = criptografiaServico;
            this.mapper = mapper;
        }

        public async Task<ComandoRetornoGenerico<Usuario>> Handle(AlterarUsuarioComando request, CancellationToken cancellationToken)
        {
            var comandoRetorno = new ComandoRetornoGenerico<Usuario>();
            var retornoConsulta = await usuarioRepositorio.ObterPorQueryAsync(x => x.Id == request.UserId);
            var usuarioCadastrado = retornoConsulta?.FirstOrDefault();
            if (usuarioCadastrado == null)
                comandoRetorno.AddNotification("Registro não localizado", "usuário não cadastrado no sistema");

            if (comandoRetorno.Valid)
            {
                var usuarioAlterado = mapper.Map<Usuario>(request);
                usuarioAlterado.Senha = usuarioCadastrado!.Senha;
                usuarioAlterado.Id = request.UserId;
                usuarioRepositorio.Alterar(usuarioAlterado);
                await usuarioRepositorio.SalvarMudancasAsync();
                comandoRetorno.Dados = usuarioAlterado;
            }
            return comandoRetorno;
        }
    }
}

