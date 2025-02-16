using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class GetProductRepo : IGetProductRepo
{
    private readonly IDapperContext _dapperContext;

    public GetProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<Entity.Inventory.Product>> GetProductsAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Product"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.Inventory.Product>(query);
        return result;
    }

    public async Task<Entity.Inventory.Product?> GetProductAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Product"" WHERE ""Id"" = @Id AND NOT ""IsDeleted""";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.Inventory.Product>(query, new { Id = id });
        return result;
    }
}