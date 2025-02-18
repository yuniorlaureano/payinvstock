using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Stock;
using Payinvstock.Contract.Util.Http;

namespace Payinvstock.Dal.Inventory.Stock;

public class DeleteStockRepo : IDeleteStockRepo
{
    private readonly IDapperContext _dapperContext;
    private readonly IUserHttpContextAccessor _userContextAccessor;

    public DeleteStockRepo(
        IDapperContext dapperContext,
        IUserHttpContextAccessor userContextAccessor)
    {
        _dapperContext = dapperContext;
        _userContextAccessor = userContextAccessor;
    }

    public async Task DeleteStockAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Stock""
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