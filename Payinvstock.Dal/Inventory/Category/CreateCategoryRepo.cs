using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Category;

namespace Payinvstock.Dal.Inventory.Category;

public class CreateCategoryRepo : ICreateCategoryRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateCategoryRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateCategoryAsync(Entity.Inventory.Category model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""Inventory"".""Category"" (""Name"", ""Description"", ""CreatedAt"", ""CreatedBy"") 
                                        VALUES  (@Name, @Description, @CreatedAt, @CreatedBy)",
            model
        );
    }
}