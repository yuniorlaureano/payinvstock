using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.StockDetail;

namespace Payinvstock.Dal.Inventory.Stock;

public class GetStockDetailRepo : IGetStockDetailRepo
{
    private readonly IDapperContext _dapperContext;

    public GetStockDetailRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.Inventory.StockDetail>> GetStockDetailByStockIdAsync(Guid stockId)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""StockDetail"" WHERE ""StockId"" = @StockId;";
        var result = await connection.QueryAsync<Entity.Inventory.StockDetail>(query, new { StockId = stockId });
        return result;
    }
}