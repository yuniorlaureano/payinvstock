using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;

namespace Payinvstock.Dal.General.Unit;

public class CreateUnitRepo : ICreateUnitRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateUnitRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateUnitAsync(Entity.General.Unit model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""General"".""Unit"" (""Id"", ""Code"", ""Name"", ""Description"", ""CreatedAt"", ""CreatedBy"") 
                                        VALUES  ('{Guid.CreateVersion7()}', @Code, @Name, @Description, @CreatedAt, @CreatedBy)",
            model
        );
    }
}