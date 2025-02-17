using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Provider;

namespace Payinvstock.Dal.Inventory.Provider;

public class GetProviderRepo : IGetProviderRepo
{
    private readonly IDapperContext _dapperContext;

    public GetProviderRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.Inventory.Provider>> GetProvidersAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Provider"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.Inventory.Provider>(query);
        return result;
    }

    public async Task<Entity.Inventory.Provider?> GetProviderAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Provider"" WHERE ""Id"" = @Id AND NOT ""IsDeleted""";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.Inventory.Provider>(query, new { Id = id });
        return result;
    }
}