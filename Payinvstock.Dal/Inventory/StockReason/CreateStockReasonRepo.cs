using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.StockReason;

namespace Payinvstock.Dal.Inventory.StockReason;

public class CreateStockReasonRepo : ICreateStockReasonRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateStockReasonRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateStockReasonAsync(Entity.Inventory.StockReason model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""Inventory"".""StockReason"" (""Id"",""Name"", ""Description"", ""InputOrOutput"", ""CreatedAt"", ""CreatedBy"") 
                                        VALUES  ('{Guid.CreateVersion7()}', @Name, @Description, @InputOrOutput, @CreatedAt, @CreatedBy)",
            model
        );
    }
}