using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;

namespace Payinvstock.Dal.General.Unit;

public class DeleteUnitRepo : IDeleteUnitRepo
{
    private readonly IDapperContext _dapperContext;

    public DeleteUnitRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(DeleteUnitRepo)}', Method '{nameof(DeleteUnitRepo)}', service '{nameof(IDapperContext)}' required");
    }

    public async Task DeleteUnitAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""General"".""Unit""
                SET 
                    ""IsDeleted"" = 1,  
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy
               WHERE ""Id"" = @Id",
            new { Id = id }
        );
    }
}