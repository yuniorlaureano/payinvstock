using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Store;

namespace Payinvstock.Dal.General.Store;

public class GetStoreRepo : IGetStoreRepo
{
    private readonly IDapperContext _dapperContext;

    public GetStoreRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.General.Store>> GetStoresAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""General"".""Store"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.General.Store>(query);
        return result;
    }

    public async Task<Entity.General.Store?> GetStoreAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""General"".""Store"" WHERE ""Id"" = @Id AND NOT ""IsDeleted""";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.General.Store>(query, new { Id = id });
        return result;
    }
}