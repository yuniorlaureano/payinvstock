namespace Payinvstock.Dto.General.Unit;

public class UpdateUnitDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}