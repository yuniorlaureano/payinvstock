namespace Payinvstock.Entity.Invoice;

public class PurchaseDetail
{
    public decimal Price { get; set; }
    public Guid? StockId { get; set; }
    public Guid PurchaseId { get; set; }
}