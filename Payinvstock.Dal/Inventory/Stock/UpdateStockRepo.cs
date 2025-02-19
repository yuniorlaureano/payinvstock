using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Stock;
using System.Text;

namespace Payinvstock.Dal.Inventory.Stock;

public class UpdateStockRepo : IUpdateStockRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateStockRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateStockAsync(Entity.Inventory.Stock model, List<Entity.Inventory.StockDetail> detail)
    {
        //ToDo: when I finished ProductMaterial, come back here and add affect the inventory of the product, maybe add a stock id to the same table, to know which transaction affected productmaterial table
        using var connection = _dapperContext.CreateConnection();
        var query =
        $"""
        DO $$
        DECLARE
            InsertedStockId uuid = '{model.Id}';
        BEGIN
            --insert transaction
            UPDATE "Inventory"."Stock"
        	    SET 
        		    "Status" = {(byte)model.Status}, 
        		    "Note" = '{Sanitize(model.Note??"")}', 
        		    "ProviderId" = '{model.ProviderId}', 
        		    "StoreId" = '{model.StoreId}', 
        		    "ReasonId" = '{model.ReasonId}', 
        		    "UpdatedAt" = CURRENT_DATE, 
        		    "UpdatedBy"  = '{model.UpdatedBy}'
             WHERE "Id" = InsertedStockId;

            --delete existing details
             DELETE FROM "Inventory"."StockDetail" WHERE "StockId" = InsertedStockId;

            ---insert stock details
            {GetStockDetailQuery(detail)}
        EXCEPTION
          	WHEN OTHERS THEN
           		RAISE NOTICE 'Error while creating stock: %', SQLERRM;
        END $$;
        """;

        await connection.ExecuteAsync(query);
    }

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