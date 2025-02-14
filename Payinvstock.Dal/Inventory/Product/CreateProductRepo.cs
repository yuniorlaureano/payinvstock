using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class CreateProductRepo : ICreateProductRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(CreateProductRepo)}', Method '{nameof(CreateProductRepo)}', service '{nameof(IDapperContext)}' required");
    }

    /// <summary>
    /// Create a product in the database
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task CreateProductAsync(Entity.Inventory.Product product)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"INSERT INTO ""Inventory"".""Product"" (""Code"",   ""Name"",  ""Description"",  ""Photo"",  ""Price"",  ""ByUnitOrWeight"",  ""UnitValue"",  ""UnitId"",  ""CategoryId,  ""Type"",  ""CreatedAt"",  ""CreatedBy"",  ""UpdatedAt"",  ""UpdatedBy"") 
                          VALUES  (@Code, @Name, @Description, @Photo, @Price, @ByUnitOrWeight, @UnitValue, @UnitId, @CategoryId, @Type, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy)",
            product
        );
    }
}