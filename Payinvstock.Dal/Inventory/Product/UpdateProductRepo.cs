using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class UpdateProductRepo : IUpdateProductRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateProductAsync(Entity.Inventory.Product model)
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
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}