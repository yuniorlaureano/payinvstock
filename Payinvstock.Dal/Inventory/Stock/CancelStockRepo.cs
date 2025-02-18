using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Stock;

namespace Payinvstock.Dal.Inventory.Stock;

public class CancelStockRepo : ICancelStockRepo
{
    private readonly IDapperContext _dapperContext;

    public CancelStockRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateStockAsync(Entity.Inventory.Stock model)
    {
        using var connection = _dapperContext.CreateConnection();
        var query =
        $"""
            UPDATE "Inventory"."Stock" 
                SET 
                    "Status"     = @Status,
                    "UpdatedAt"  = CURRENT_DATE, 
        		    "UpdatedBy"  = @UpdatedBy
            WHERE "Id" = @Id;
        """;

        await connection.ExecuteAsync(query, new
        {
            model.Id,
            model.UpdatedBy,
            Status = (byte)Enums.Inventory.StockStatus.Canceled
        });
    }
}