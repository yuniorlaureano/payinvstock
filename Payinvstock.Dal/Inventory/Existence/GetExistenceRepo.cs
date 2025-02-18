using Dapper;
using Payinvstock.Contract.BLL.Inventory.Existence;
using Payinvstock.Contract.Dal;
using Payinvstock.Dto.Inventory.Existence;

namespace Payinvstock.Dal.Inventory.Existence;

public class GetExistenceRepo : IGetExistenceRepo
{
    private readonly IDapperContext _dapperContext;

    public GetExistenceRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<GetExistenceDto>> GetExistenceAsync()
    {
        using var connection = _dapperContext.CreateConnection();
		var query = ExistenceQuery();
        var result = await connection.QueryAsync<GetExistenceDto>(query);
        return result;
    }

    private string ExistenceQuery()
    {
        return """
			SELECT 
			 P."Id"
			,P."Code"
			,p."Name"
			,p."Description"
			,CONCAT(P."UnitValue", ' ', U."Code" ) AS "Unit"
			,SUM(CASE STDR."InputOrOutput"  
				WHEN 1 THEN STD."Quantity" * -1
				WHEN 2 THEN STD."Quantity"
				ELSE STD."Quantity"
			  END) AS "InStock"
			 ,SUM(CASE STDR."InputOrOutput"  
				WHEN 2 THEN STD."Quantity"
				ELSE 0
			  END) AS "Input"
			 ,SUM(CASE STDR."InputOrOutput"  
				WHEN 1 THEN STD."Quantity" * -1
				ELSE 0
			  END) AS "Output"
		FROM "Inventory"."Product" P
			JOIN "Inventory"."StockDetail" STD
				ON P."Id" = STD."ProductId"
			JOIN "Inventory"."Stock" ST
				ON STD."StockId" = ST."Id"
			JOIN "Inventory"."StockReason" STDR
				ON STDR."Id" = ST."ReasonId"
			JOIN "General"."Unit" U
				ON P."UnitId" = U."Id"
		WHERE 
				NOT P."IsDeleted"
			AND ST."Status" = 1 --Saved, not allowe Draft, or Canceled 
		GROUP BY 
			 P."Id"
			,P."Code"
			,p."Name"
			,p."Description"
			,CONCAT(P."UnitValue", ' ', U."Code" )
		""";
    }
}