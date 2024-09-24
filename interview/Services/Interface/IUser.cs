namespace interview.Services.Interface;

public interface IUser
{
    public Task<object> GetUserById(int id);
}
