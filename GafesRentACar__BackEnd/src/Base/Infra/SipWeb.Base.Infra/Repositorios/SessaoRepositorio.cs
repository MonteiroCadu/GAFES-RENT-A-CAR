using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SipWeb.Base.Dominio.Entidades;
using SipWeb.Base.Dominio.Repositorios;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SipWeb.Base.Infra.Repositorios;
public class SessaoRepositorio : ISessaoRepositorio
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IDatabase redisDB;

    public JsonSerializerOptions SerializerOptions
    {
        get
        {
            return new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
        }
    }

    public SessaoRepositorio(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        var redisConnectionString = configuration.GetConnectionString("Redis");
        var _redisConnection = ConnectionMultiplexer.Connect(redisConnectionString!);

        redisDB = _redisConnection.GetDatabase();
        this._httpContextAccessor = httpContextAccessor;
    }

    public async Task<Sessao?> ObterPeloIDAsync(string login)
    {
        var json = await redisDB.StringGetAsync(login);


        Sessao? sessao = JsonSerializer.Deserialize<Sessao>(json!, SerializerOptions);
        return sessao;
    }

    public async Task<Sessao?> ObterSessaoAsync()
    {
        string? login = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
        return string.IsNullOrEmpty(login) ? null : await ObterPeloIDAsync(login);
    }

    public async Task Salvar(Sessao sessao)
    {
        var json = JsonSerializer.Serialize(sessao, SerializerOptions);
        await redisDB.StringSetAsync(sessao.Login, json);
    }
}
