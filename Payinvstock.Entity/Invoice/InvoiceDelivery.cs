namespace Payinvstock.Enums.Invoice;

public class InvoiceDelivery
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid DeliveryId { get; set; }
}