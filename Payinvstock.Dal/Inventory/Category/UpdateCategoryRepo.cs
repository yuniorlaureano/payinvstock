using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Category;

namespace Payinvstock.Dal.Inventory.Category;

public class UpdateCategoryRepo : IUpdateCategoryRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateCategoryRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateCategoryAsync(Entity.Inventory.Category model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Category""
                SET 
                    ""Name"" = @Name,
                    ""Description"" = @Description,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}