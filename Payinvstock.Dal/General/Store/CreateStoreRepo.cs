using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Store;

namespace Payinvstock.Dal.General.Store;

public class CreateStoreRepo : ICreateStoreRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateStoreRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateStoreAsync(Entity.General.Store model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""General"".""Store"" (""Code"", ""Name"", ""Photo"", ""Description"", ""Address"", ""Latitude"", ""Longitude"" ) 
                                        VALUES  (@Code, @Name, @Photo, @Description, @Address, @Latitude, @Longitude)",
            model
        );
    }
}