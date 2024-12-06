namespace Payinvstock.Entity.Invoice;

public class ClientCredit
{
    public Guid Id { get; set; }
    public decimal Credit { get; set; }
    public string Concept { get; set; }
    public Guid ClientId { get; set; }


    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}