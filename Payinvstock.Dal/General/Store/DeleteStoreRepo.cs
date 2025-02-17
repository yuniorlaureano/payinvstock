using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Store;
using Payinvstock.Contract.Util.Http;

namespace Payinvstock.Dal.General.Store;

public class DeleteStoreRepo : IDeleteStoreRepo
{
    private readonly IDapperContext _dapperContext;
    private readonly IUserHttpContextAccessor _userContextAccessor;

    public DeleteStoreRepo(
        IDapperContext dapperContext,
        IUserHttpContextAccessor userContextAccessor)
    {
        _dapperContext = dapperContext;
        _userContextAccessor = userContextAccessor;
    }

    public async Task DeleteStoreAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""General"".""Store""
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