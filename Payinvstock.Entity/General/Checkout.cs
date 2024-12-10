namespace Payinvstock.Entity.General;

public class Checkout
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public Guid StoreId { get; set; }
    public Guid AssignedTo { get; set; }

    public DateTime AssignedAt { get; set; }
    public Guid AssignedBy { get; set; }
}