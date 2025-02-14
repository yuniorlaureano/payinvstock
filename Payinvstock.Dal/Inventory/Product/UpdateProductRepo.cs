using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class UpdateProductRepo : IUpdateProductRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(UpdateProductRepo)}', Method '{nameof(UpdateProductRepo)}', service '{nameof(IDapperContext)}' required");
    }

    /// <summary>
    /// Update a product in the database
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task UpdateProductAsync(Entity.Inventory.Product product)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Product""
                SET 
                    ""Code"" = @Code, 
                    ""Name"" = @Name,
                    ""Description"" = @Description,
                    ""Photo"" = @Photo,
                    ""Price"" = @Price,
                    ""ByUnitOrWeight"" = @ByUnitOrWeight,
                    ""UnitValue"" = @UnitValue,
                    ""UnitId"" = @UnitId,
                    ""CategoryId"" = @CategoryId,
                    ""Type"" = @Type,
                    ""CreatedAt"" = @CreatedAt,
                    ""CreatedBy"" = @CreatedBy,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            product
        );
    }
}