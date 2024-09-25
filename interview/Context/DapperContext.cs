
using Microsoft.Data.SqlClient;

namespace interview.Context;

public class DapperContext
{
    private readonly ConnectionConfig _connectionConfig;

    public DapperContext(ConnectionConfig connectionConfig)
    {
        _connectionConfig = connectionConfig;
    }
    public virtual SqlConnection CreateTutorial()
    {
        using var connection = new SqlConnection(_connectionConfig.Tutorial);
        connection.Open();
        return connection;
    }
    public virtual SqlConnection CreateInterview()
    {
        using var connection = new SqlConnection(_connectionConfig.Interview);
        connection.Open();
        return connection;
    }
    public class ConnectionConfig
    {
        public string Tutorial { get; set; }
        public string Interview { get; set; }
    }
}
