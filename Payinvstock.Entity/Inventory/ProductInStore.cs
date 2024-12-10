namespace Payinvstock.Entity.Inventory;

public class ProductInStore
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid ProductId { get; set; }
    public Guid StoreId { get; set; }
}