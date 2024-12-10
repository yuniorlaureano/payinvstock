namespace Payinvstock.Entity.Invoicing;

public class AdjustmentType
{
    public const string PERCENTAGE = "PERCENTAGE";
    public const string AMOUNT = "AMOUNT";
}

/// <summary>
/// This will store the adjustments that are made to the product in term of bonus or taxes
/// e.g 10% discount, 5% tax, 10$ bonus, ITBIS
/// </summary>
public class Adjustment
{
    public Guid Id { get; set; }
    public string Concept { get; set; }
    public decimal Value { get; set; }


    public bool IsDiscount { get; set; }
    public string Type { get; set; }

    /// <summary>
    /// The start date of the adjustment
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// The end date of the adjustment
    /// </summary>
    public DateTime? EndDate { get; set; }
}