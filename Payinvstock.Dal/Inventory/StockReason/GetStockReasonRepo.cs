using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.StockReason;

namespace Payinvstock.Dal.Inventory.StockReason;

public class GetStockReasonRepo : IGetStockReasonRepo
{
    private readonly IDapperContext _dapperContext;

    public GetStockReasonRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.Inventory.StockReason>> GetStockReasonsAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""StockReason"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.Inventory.StockReason>(query);
        return result;
    }

    public async Task<Entity.Inventory.StockReason?> GetStockReasonAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""StockReason"" WHERE ""Id"" = @Id AND NOT ""IsDeleted""";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.Inventory.StockReason>(query, new { Id = id });
        return result;
    }
}