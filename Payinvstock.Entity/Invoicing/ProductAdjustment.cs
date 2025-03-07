﻿namespace Payinvstock.Entity.Invoicing;

public class ProductAdjustment
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid AdjustmentId { get; set; }
    public bool IsDeleted { get; set; }


    //Who create or update and when it is done
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}