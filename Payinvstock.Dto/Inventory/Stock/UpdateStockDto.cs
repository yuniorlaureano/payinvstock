using Payinvstock.Dto.Inventory.StockDetail;
using Payinvstock.Enums.Inventory;

namespace Payinvstock.Dto.Inventory.Stock;

public class UpdateStockDto
{
    public string? Note { get; set; }
    public StockStatus Status { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid StoreId { get; set; }
    public Guid ReasonId { get; set; }
    public List<CreateStockDetailDto> Detail { get; set; } = new();
}