namespace Payinvstock.Entity.Invoice;

public class AccountsReceivableDetail
{
    public Guid Id { get; set; }
    public Guid AccountsReceivableId { get; set; }
    public decimal PendingPayment { get; set; }
    public decimal Payment { get; set; }
}