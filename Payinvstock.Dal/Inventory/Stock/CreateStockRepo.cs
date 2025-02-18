using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Stock;
using System.Text;

namespace Payinvstock.Dal.Inventory.Stock;

public class CreateStockRepo : ICreateStockRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateStockRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateStockAsync(Entity.Inventory.Stock model, List<Entity.Inventory.StockDetail> detail)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = 
        $"""
        DO $$
        DECLARE
            InsertedStockId uuid;
        BEGIN
            --insert transaction
            {GetStockQuery(model)}

            ---insert stock details
            {GetStockDetailQuery(detail)}
        EXCEPTION
          	WHEN OTHERS THEN
           		RAISE NOTICE 'Error while creating stock: %', SQLERRM;
        END $$;
        """;

        model.Status = Enums.Inventory.StockStatus.Saved;
        await connection.ExecuteAsync(query);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string GetStockQuery(Entity.Inventory.Stock model)
    {
        var stockQuery = new StringBuilder();
        stockQuery.AppendLine(@"INSERT INTO ""Inventory"".""Stock"" ");
        stockQuery.AppendLine(@"    (""Date"", ""Status"", ""Note"", ""ProviderId"", ""StoreId"", ""ReasonId"", ""CreatedAt"", ""CreatedBy"") VALUES ");
        stockQuery.AppendLine(@$"   (CURRENT_DATE, {(byte)model.Status}, '{Sanitize(model.Note)}', '{model.ProviderId}', '{model.StoreId}', '{model.ReasonId}', CURRENT_DATE, '{model.CreatedBy}') RETURNING ""Id"" INTO InsertedStockId;");
        return stockQuery.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="detail"></param>
    /// <returns></returns>
    private string GetStockDetailQuery(List<Entity.Inventory.StockDetail> detail)
    {
        var numberOfDetail = detail.Count;
        var processedDetail = 0;
        var detailQuery = new StringBuilder();
        detailQuery.AppendLine(@"INSERT INTO ""Inventory"".""StockDetail"" (""StockId"", ""ProductId"", ""Quantity"", ""PurchasePrice"") VALUES ");

        foreach (var item in detail)
        {
            processedDetail++;
            if (processedDetail == numberOfDetail)
            {
                detailQuery.AppendLine($"(InsertedStockId, '{item.ProductId}', {item.Quantity}, {item.PurchasePrice});");
            }
            else
            {
                detailQuery.AppendLine($"(InsertedStockId, '{item.ProductId}', {item.Quantity}, {item.PurchasePrice}),");
            }
        }

        return detailQuery.ToString();
    }

    public static string? Sanitize(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        // Replace single quotes with two single quotes to escape them
        return input.Replace("'", "''");
    }
}