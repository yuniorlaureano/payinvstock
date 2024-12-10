using Payinvstock.Enums.Invoicing;

namespace Payinvstock.Entity.Invoicing;

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


    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}