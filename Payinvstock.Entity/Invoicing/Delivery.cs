namespace Payinvstock.Entity.Invoicing;

public class Delivery
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string VehicleDescription { get; set; }
    public bool IsDeleted { get; set; }
}