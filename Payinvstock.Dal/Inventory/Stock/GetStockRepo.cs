using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Stock;

namespace Payinvstock.Dal.Inventory.Stock;

public class GetStockRepo : IGetStockRepo
{
    private readonly IDapperContext _dapperContext;

    public GetStockRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.Inventory.Stock>> GetStocksAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Stock"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.Inventory.Stock>(query);
        return result;
    }

    public async Task<Entity.Inventory.Stock?> GetStockAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Stock"" WHERE ""Id"" = @Id AND NOT ""IsDeleted""";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.Inventory.Stock>(query, new { Id = id });
        return result;
    }
}