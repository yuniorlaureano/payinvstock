using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Contract.Util.Http;

namespace Payinvstock.Dal.General.Unit;

public class DeleteUnitRepo : IDeleteUnitRepo
{
    private readonly IDapperContext _dapperContext;
    private readonly IUserHttpContextAccessor _userContextAccessor;

    public DeleteUnitRepo(
        IDapperContext dapperContext,
        IUserHttpContextAccessor userContextAccessor)
    {
        _dapperContext = dapperContext;
        _userContextAccessor = userContextAccessor;
    }

    public async Task DeleteUnitAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""General"".""Unit""
                SET 
                    ""IsDeleted"" = true,  
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy
               WHERE ""Id"" = @Id",
            new 
            {
                Id = id,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = _userContextAccessor.GetCurrentUserId()
            }
        );
    }
}