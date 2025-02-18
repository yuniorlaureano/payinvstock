namespace Payinvstock.Dto.Inventory.StockDetail;

public class UpdateStockDetailDto
{
    public Guid StockId { get; set; }
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public decimal? PurchasePrice { get; set; }
}