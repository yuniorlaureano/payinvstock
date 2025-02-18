namespace Payinvstock.Dto.Inventory.StockDetail;

public class CreateStockDetailDto
{
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public decimal? PurchasePrice { get; set; }
}