using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Category;
using Payinvstock.Contract.Util.Http;

namespace Payinvstock.Dal.Inventory.Category;

public class DeleteCategoryRepo : IDeleteCategoryRepo
{
    private readonly IDapperContext _dapperContext;
    private readonly IUserHttpContextAccessor _userContextAccessor;

    public DeleteCategoryRepo(
        IDapperContext dapperContext,
        IUserHttpContextAccessor userContextAccessor)
    {
        _dapperContext = dapperContext;
        _userContextAccessor = userContextAccessor;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Category""
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