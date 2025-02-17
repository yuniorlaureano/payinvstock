using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.StockReason;
using Payinvstock.Contract.Util.Http;

namespace Payinvstock.Dal.Inventory.StockReason;

public class DeleteStockReasonRepo : IDeleteStockReasonRepo
{
    private readonly IDapperContext _dapperContext;
    private readonly IUserHttpContextAccessor _userContextAccessor;

    public DeleteStockReasonRepo(
        IDapperContext dapperContext,
        IUserHttpContextAccessor userContextAccessor)
    {
        _dapperContext = dapperContext;
        _userContextAccessor = userContextAccessor;
    }

    public async Task DeleteStockReasonAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""StockReason""
                SET 
                    ""IsDeleted"" = true,  
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy
               WHERE ""Id"" = @Id",
            new
            {
                Id = id,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = _userContextAccessor.GetCurrentUserId()
            }
        );
    }
}