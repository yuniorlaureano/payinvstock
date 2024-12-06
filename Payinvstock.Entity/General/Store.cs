namespace Payinvstock.Entity.General;

public class Store
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }


    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}