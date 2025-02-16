using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class CreateProductRepo : ICreateProductRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateProductAsync(Entity.Inventory.Product model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""Inventory"".""Product"" (""Code"", ""Name"", ""Description"", ""Photo"", ""Price"", ""ByUnitOrWeight"", ""UnitValue"", ""UnitId"", ""CategoryId"", ""Type"", ""CreatedAt"") 
                                        VALUES  (@Code, @Name, @Description, @Photo, @Price, @ByUnitOrWeight, @UnitValue, @UnitId, @CategoryId, @Type, @CreatedAt)",
            model
        );
    }
}