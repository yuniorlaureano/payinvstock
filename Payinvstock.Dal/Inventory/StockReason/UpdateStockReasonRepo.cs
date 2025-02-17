using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.StockReason;

namespace Payinvstock.Dal.Inventory.StockReason;

public class UpdateStockReasonRepo : IUpdateStockReasonRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateStockReasonRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateStockReasonAsync(Entity.Inventory.StockReason model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""StockReason""
                SET 
                    ""Name"" = @Name,
                    ""Description"" = @Description,
                    ""InputOrOutput"" = @InputOrOutput,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}