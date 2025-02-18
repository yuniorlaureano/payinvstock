using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Stock;

namespace Payinvstock.Dal.Inventory.Stock;

public class UpdateStockRepo : IUpdateStockRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateStockRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateStockAsync(Entity.Inventory.Stock model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Stock""
                SET 
                    ""Date"" = @Date,
                    ""StockStatus"" = @StockStatus,
                    ""Note"" = @Note,
                    ""ProviderId"" = @ProviderId,
                    ""StoreId"" = @StoreId,
                    ""ReasonId"" = @ReasonId,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}