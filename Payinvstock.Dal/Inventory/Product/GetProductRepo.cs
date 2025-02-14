using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class GetProductRepo : IGetProductRepo
{
    private readonly IDapperContext _dapperContext;

    public GetProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(GetProductRepo)}', Method '{nameof(GetProductRepo)}', service '{nameof(IDapperContext)}' required");
    }

    
    /// <summary>
    /// Get products from db
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Entity.Inventory.Product>> GetProductsAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Product"" WHERE NOT ""IsDeleted""";
        var products = await connection.QueryAsync<Entity.Inventory.Product>(query);
        return products;
    }

    /// <summary>
    /// Get product by Id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<Entity.Inventory.Product?> GetProductAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""Inventory"".""Product"" WHERE ""Id"" = @Id";
        var product = await connection.QuerySingleOrDefaultAsync<Entity.Inventory.Product>(query, new { Id = id });
        return product;
    }
}