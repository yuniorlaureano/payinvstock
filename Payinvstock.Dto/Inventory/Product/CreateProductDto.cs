using Payinvstock.Enums.Inventory;

namespace Payinvstock.Dto.Inventory.Product;

public class CreateProductDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Indicate the type of the quantity
    /// Like if the product will be sold by unit or by weight
    /// </summary>
    public QuantityType ByUnitOrWeight { get; set; }

    /// <summary>
    /// The value of the unit.
    /// e.g. 1gr, 2ml, 3mlg
    /// </summary>
    public double UnitValue { get; set; }

    /// <summary>
    /// The unit of the product
    /// e.g. gr, ml, kg
    /// </summary>
    public Guid UnitId { get; set; }

    /// <summary>
    /// Category of the product
    /// e.g. Food, Drink, Medicine
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Indicate the type of the product
    /// e.g. Raw material, Finished product
    /// </summary>
    public ProductType Type { get; set; }
}