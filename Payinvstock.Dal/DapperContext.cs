using Microsoft.Extensions.Configuration;
using Npgsql;
using Payinvstock.Contract.Dal;
using System.Data;

namespace Payinvstock.Dal;

/// <summary>
/// Handle connection creation and connectionString retrieval
/// </summary>
public class DapperContext : IDapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException($"Class '{nameof(DapperContext)}', Method '{nameof(DapperContext)}', service '{nameof(IConfiguration)}' required");
        _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException($"Class '{nameof(DapperContext)}', Method '{nameof(DapperContext)}', connection string 'DefaultConnection' required"); ;
    }

    /// <summary>
    /// Create a connection to the database
    /// </summary>
    /// <returns></returns>
    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}
