using Payinvstock.Dto.Inventory.StockDetail;

namespace Payinvstock.Dto.Inventory.Stock;

public class GetStockDto
{
    public Guid Id { get; set; }
    public string? Note { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid StoreId { get; set; }
    public Guid ReasonId { get; set; }
    public List<GetStockDetailDto> Detail { get; set; } = new();
}