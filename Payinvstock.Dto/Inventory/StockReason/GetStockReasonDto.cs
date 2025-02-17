using Payinvstock.Enums;

namespace Payinvstock.Dto.Inventory.StockReason;

public class GetStockReasonDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// If the transaction is input or output
    /// </summary>
    public TransactionType InputOrOutput { get; set; }
}