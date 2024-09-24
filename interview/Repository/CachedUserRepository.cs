using interview.Services.Interface;

namespace interview.Repository.Interface;

public class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decorated;
    public CachedUserRepository(IUserRepository decorated)
    {
        _decorated = decorated;
    }
    public async Task<object> GetUserById(int id)
    {
        //call cache
        var cacheKey = $"user_{id}";
        var json = "sample";//await GetDataInRedisAsync(cacheKey);
        if (json == null)
        {
          await  _decorated.GetUserById(id);
        }
        return json;
    }
}
