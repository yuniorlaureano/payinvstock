using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;

namespace Payinvstock.Dal.General.Unit;

public class GetUnitRepo : IGetUnitRepo
{
    private readonly IDapperContext _dapperContext;

    public GetUnitRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(GetUnitRepo)}', Method '{nameof(GetUnitRepo)}', service '{nameof(IDapperContext)}' required");
    }

    public async Task<IEnumerable<Entity.General.Unit>> GetUnitsAsync()
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""General"".""Unit"" WHERE NOT ""IsDeleted""";
        var result = await connection.QueryAsync<Entity.General.Unit>(query);
        return result;
    }

    public async Task<Entity.General.Unit?> GetUnitAsync(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = @"SELECT * FROM ""General"".""Unit"" WHERE ""Id"" = @Id";
        var result = await connection.QuerySingleOrDefaultAsync<Entity.General.Unit>(query, new { Id = id });
        return result;
    }
}