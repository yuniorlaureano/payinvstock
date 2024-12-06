namespace Payinvstock.Enums.Inventory;

/// <summary>
/// Indicate the type of the quantity
/// This will allow the system to know how to handle the quantity
/// Like if the product will be sold by unit or by weight
/// </summary>
public enum QuantityType
{
    ByUnit,
    ByWeight,
}