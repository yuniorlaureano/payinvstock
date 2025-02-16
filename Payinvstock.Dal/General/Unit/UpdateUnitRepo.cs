using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;

namespace Payinvstock.Dal.General.Unit;

public class UpdateUnitRepo : IUpdateUnitRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateUnitRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task UpdateUnitAsync(Entity.General.Unit model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""General"".""Unit""
                SET 
                    ""Name"" = @Name,
                    ""Code"" = @Code,
                    ""Description"" = @Description,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}