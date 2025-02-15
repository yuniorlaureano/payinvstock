using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;

namespace Payinvstock.Dal.General.Unit;

public class UpdateUnitRepo : IUpdateUnitRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateUnitRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(UpdateUnitRepo)}', Method '{nameof(UpdateUnitRepo)}', service '{nameof(IDapperContext)}' required");
    }

    public async Task UpdateUnitAsync(Entity.General.Unit model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""General"".""Unit""
                SET 
                    ""Name"" = @Name,
                    ""Description"" = @Description,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}