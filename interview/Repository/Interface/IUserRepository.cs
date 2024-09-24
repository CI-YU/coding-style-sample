namespace interview.Repository.Interface;

public interface IUserRepository
{
    Task<object> GetUserById(int id);
}
