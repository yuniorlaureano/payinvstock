using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Store;

namespace Payinvstock.Dal.General.Store;

public class UpdateStoreRepo : IUpdateStoreRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateStoreRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task UpdateStoreAsync(Entity.General.Store model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""General"".""Store""
                SET 
                    ""Code"" = @Code,
                    ""Name"" = @Name,
                    ""Photo"" = @Photo,
                    ""Description"" = @Description,
                    ""Address"" = @Address,
                    ""Latitude"" = @Latitude,
                    ""Longitude"" = @Longitude,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}