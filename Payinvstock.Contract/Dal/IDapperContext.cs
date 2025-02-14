using System.Data;

namespace Payinvstock.Contract.Dal;

/// <summary>
/// Handle connection creation and connectionString retrieval
/// </summary>
public interface IDapperContext
{
    /// <summary>
    /// Create a connection to the database
    /// </summary>
    /// <returns></returns>
    public IDbConnection CreateConnection();
}
