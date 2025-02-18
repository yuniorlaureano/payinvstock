namespace Payinvstock.Dto.Inventory.Existence;

public class GetExistenceDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public double InStock { get; set; }
    public double Input { get; set; }
    public double Output { get; set; }
}