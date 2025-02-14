using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Dal.Inventory.Product;

public class DeleteProductRepo : IDeleteProductRepo
{
    private readonly IDapperContext _dapperContext;

    public DeleteProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(DeleteProductRepo)}', Method '{nameof(DeleteProductRepo)}', service '{nameof(IDapperContext)}' required");
    }

    /// <summary>
    /// Delete a product in the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteProductAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Product""
                SET 
                    ""IsDeleted"" = 1,  
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy
               WHERE ""Id"" = @Id",
            new { Id = id }
        );
    }
}