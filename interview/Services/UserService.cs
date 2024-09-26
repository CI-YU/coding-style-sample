using interview.Repository.Interface;
using interview.Services.Interface;

namespace interview.Services;

public class UserService(IUserRepository userRepository) : IUser
{
    private readonly IUserRepository _user = userRepository;

    public async Task<object> GetUserById(int id)
    {
        return await _user.GetUserById(id);
    }
}
