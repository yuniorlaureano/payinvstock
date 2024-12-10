namespace Payinvstock.Entity.General;

public class Unit
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}