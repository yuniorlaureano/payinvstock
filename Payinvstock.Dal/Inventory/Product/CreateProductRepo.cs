﻿using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;
using System.Reflection;

namespace Payinvstock.Dal.Inventory.Product;

public class CreateProductRepo : ICreateProductRepo
{
    private readonly IDapperContext _dapperContext;
    private static readonly string _columnNames = string.Empty;
    private static readonly string _parameterNames = string.Empty;

    static CreateProductRepo()
    {
        var properties = typeof(Entity.Inventory.Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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

    }

    public CreateProductRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext ?? throw new ArgumentNullException($"Class '{nameof(CreateProductRepo)}', Method '{nameof(CreateProductRepo)}', service '{nameof(IDapperContext)}' required");
    }

    public async Task CreateProductAsync(Entity.Inventory.Product product)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""Inventory"".""Product"" ({_columnNames}) 
                          VALUES  ({_parameterNames})",
            product
        );
    }
}