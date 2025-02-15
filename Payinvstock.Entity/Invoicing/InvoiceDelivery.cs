namespace Payinvstock.Enums.Invoicing;

public class InvoiceDelivery
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid DeliveryId { get; set; }
    public bool IsDeleted { get; set; }
}