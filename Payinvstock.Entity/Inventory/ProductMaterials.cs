using Payinvstock.Enums.Inventory;

namespace Payinvstock.Entity.Inventory;

/// <summary>
/// This class is used to store the materials that are used in a product
/// The purpose is to automate the inventory management
/// When a product is sold the materials that are used in the product will be deducted from the inventory
/// </summary>
public class ProductMaterials
{
    public Guid Id { get; set; }

    /// <summary>
    /// Id of the product that is using the material
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Id of the product that is being used as material
    /// </summary>
    public Guid MaterialId { get; set; }

    /// <summary>
    /// This is the quantity of the material that is needed to produce the product
    /// This double because the quantity can be by unit or weight
    /// </summary>
    /// <see cref="QuantityType"/>"/>
    public double QuantityNeeded { get; set; }

    /// <summary>
    /// The unit of the product
    /// e.g. gr, ml, kg
    /// </summary>
    public Guid UnitId { get; set; }


    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}