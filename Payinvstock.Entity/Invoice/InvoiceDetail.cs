namespace Payinvstock.Enums.Invoice;

public class InvoiceDetail
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }

    public Guid InvoiceId { get; set; }
}