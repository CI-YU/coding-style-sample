using interview.Services.Interface;

namespace interview.Services;

public class UserService : IUser
{
    public UserService()
    {
    }
    public async Task<object> GetUserById(int id)
    {
        return id;
    }
}
