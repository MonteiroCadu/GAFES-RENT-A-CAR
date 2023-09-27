using System;
using MediatR;
using SipWeb.Base.Dominio.Entidades;
using AutoMapper;
using StackExchange.Redis;
using System.Diagnostics.CodeAnalysis;
using Flunt.Validations;

namespace SipWeb.Base.CasosDeUso.Comandos
{
    [AutoMap ( typeof(Usuario), ReverseMap = true) ]
    public class CadastrarUsuarioComando: ComandoBase, IRequest<ComandoRetornoGenerico<Usuario>>
	{
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string? Cpf { get; set; }
        public string? NomeCompleto { get; set; }
        public long UserId { get; set; }

        [SetsRequiredMembers]
        public CadastrarUsuarioComando(string login,string senha,string cpf,string nomeCompleto)
        {

            AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(cpf, 11, "Cpf", "Cpf Deve possuit ao menos 11 caracteres")
            .IsEmail(login, "Login", "Informe um email de acesso válido")
            .HasMinLen(senha, 5, "Senha", "Informe uma senha com no minimo 8 caracteres")
            );

            Login = login;
            Senha = senha;
            Cpf = cpf;
            NomeCompleto = nomeCompleto;
        }
    }

    public class AlterarUsuarioComando : CadastrarUsuarioComando
    {
        [SetsRequiredMembers]
        public AlterarUsuarioComando(string login, string senha, string cpf, string nomeCompleto) :
            base(login, senha, cpf, nomeCompleto)
        {
        }
    }
}

