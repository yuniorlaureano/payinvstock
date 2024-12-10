namespace Payinvstock.Enums.Invoicing;

public class InvoiceDetail
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public double Quantity { get; set; }
    public Guid ProductId { get; set; }

    public Guid InvoiceId { get; set; }
}