namespace Payinvstock.Dto.Inventory.StockDetail;

public class GetStockDetailDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public decimal? PurchasePrice { get; set; }
}