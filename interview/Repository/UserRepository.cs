using System.Text;
using Dapper;
using interview.Context;
using interview.Repository.Interface;

namespace interview.Repository;

public class UserRepository(DapperContext dapper) : IUserRepository
{
    private readonly DapperContext _dapper = dapper;

    public async Task<object> GetUserById(int id)
    {
        var conn = _dapper.CreateTutorial();
        DynamicParameters param = new();
        StringBuilder strSQL = new();
        strSQL.Append("SELECT * FROM [User] WHERE Id = @Id");
        param.Add("Id", id);
        var result = await conn.QueryAsync(strSQL.ToString(), param);
        return result;
    }
}
