namespace Payinvstock.Dto.General.Store;

public class GetStoreDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}