using Payinvstock.Dto.Inventory.StockDetail;
using Payinvstock.Enums.Inventory;

namespace Payinvstock.Dto.Inventory.Stock;

public class CreateStockDto
{
    public string? Note { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid StoreId { get; set; }
    public Guid ReasonId { get; set; }
    public List<CreateStockDetailDto> Details { get; set; } = new();
}