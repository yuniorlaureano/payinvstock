using Payinvstock.Enums;

namespace Payinvstock.Entity.Inventory;

public class StockReason
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    
    /// <summary>
    /// If the transaction is input or output
    /// </summary>
    public TransactionType InputOrOutput { get; set; }

    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}