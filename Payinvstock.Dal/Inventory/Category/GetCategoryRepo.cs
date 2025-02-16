using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Category;

namespace Payinvstock.Dal.Inventory.Category;

public class GetCategoryRepo : IGetCategoryRepo
{
    private readonly IDapperContext _dapperContext;

    public GetCategoryRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.Inventory.Category>> GetCategoriesAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Category"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.Inventory.Category>(query);
        return result;
    }

    public async Task<Entity.Inventory.Category?> GetCategoryAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Category"" WHERE ""Id"" = @Id AND NOT ""IsDeleted""";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.Inventory.Category>(query, new { Id = id });
        return result;
    }
}