namespace Payinvstock.Entity.Invoicing;

public class AccountsReceivable
{
    public Guid Id { get; set; }
    public decimal Payment { get; set; } //ToDo: Consider to save the total payment in Invoice and there the amount paid
    public bool Paid { get; set; }

    public Guid InvoiceId { get; set; }
    public Guid ClientId { get; set; }
}