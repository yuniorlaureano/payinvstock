namespace Payinvstock.Entity.Inventory;

public class StockDetail
{
    public Guid Id { get; set; }

    /// <summary>
    /// This is the master table of the stock
    /// There will be one record for one or a group of products in here <see cref="StockDetail"/>"/>
    /// </summary>
    public Guid StockId { get; set; }
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public decimal? PurchasePrice { get; set; }
}