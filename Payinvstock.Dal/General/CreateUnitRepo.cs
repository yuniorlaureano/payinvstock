using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;
using System.Reflection;

namespace Payinvstock.Dal.General.Unit;

public class CreateUnitRepo : ICreateUnitRepo
{
    private readonly IDapperContext _dapperContext;
    private static readonly string _columnNames = string.Empty;
    private static readonly string _parameterNames = string.Empty;

    static CreateUnitRepo()
    {
        var properties = typeof(Entity.General.Unit).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var exclude = new Dictionary<string, byte> { { "Id", 1 } };

        foreach (var item in properties)
        {
            if (exclude.ContainsKey(item.Name))
            {
                continue;
            }

            _columnNames += $"\"{item.Name}\", ";
            _parameterNames += $"@{item.Name}, ";
        }
        _columnNames = _columnNames.Remove(_columnNames.Length - 2);
        _parameterNames = _parameterNames.Remove(_parameterNames.Length - 2);
    }

    public CreateUnitRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(CreateUnitRepo)}', Method '{nameof(CreateUnitRepo)}', service '{nameof(IDapperContext)}' required");
    }

    public async Task CreateUnitAsync(Entity.General.Unit model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""General"".""Unit"" ({_columnNames}) 
                          VALUES  ({_parameterNames})",
            model
        );
    }
}