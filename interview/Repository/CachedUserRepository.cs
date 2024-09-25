using interview.Services.Interface;
using StackExchange.Redis;

namespace interview.Repository.Interface;

public class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDatabase _client;
    public CachedUserRepository(IConnectionMultiplexer multiplexer, IUserRepository decorated)
    {
        _client = multiplexer.GetDatabase(0);
        _decorated = decorated;
    }
    public async Task<object> GetUserById(int id)
    {
        //call cache
        var cacheKey = $"user_{id}";
        var tokenInRedis = await _client.StringGetAsync(cacheKey);
        if (!tokenInRedis.HasValue)
        {
            var data = await _decorated.GetUserById(id);
            await _client.StringSetAsync(cacheKey, data.ToString(), TimeSpan.FromMinutes(10));
            return data;
        }
        return tokenInRedis.ToString();
    }
}
