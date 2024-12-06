using Payinvstock.Enums.Invoice;

namespace Payinvstock.Entity.Invoice;

public class Invoice
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public SaleType Type { get; set; }
    public InvoiceStatus Status { get; set; }
    public decimal Payment { get; set; }
    public decimal ToPay { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public bool Paid { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public Guid ClientId { get; set; }
}