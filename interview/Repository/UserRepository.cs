using interview.Repository.Interface;

namespace interview.Repository;

public class UserRepository : IUserRepository
{
    public UserRepository()
    {
    }
    public async Task<object> GetUserById(int id)
    {
        //call db
        return id;
    }
}
