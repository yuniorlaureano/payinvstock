using Payinvstock.Enums.Inventory;

namespace Payinvstock.Entity.Inventory;

/// <summary>
/// This store the master data of the inventory. 
/// The products that come in and out of the inventory
/// The details is stored in the <see cref="StockDetail"/>
/// </summary>
public class Stock
{
    public Guid Id { get; set; }
    /// <summary>
    /// When the transaction took place
    /// </summary>
    public DateTime Date { get; set; }
    public StockStatus Status { get; set; }
    public string? Note { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid StoreId { get; set; }
    public bool IsDeleted { get; set; }

    /// <summary>
    /// e.g. Sale, Purchase, Return, Damage, Expired, Manufacture, Raw material, Cancelled
    /// For Cancelled it will be of type None.This way I can just exclude this transaction from existence and leave it there as an historic
    /// </summary>
    public Guid ReasonId { get; set; }



    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}