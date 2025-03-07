﻿using Payinvstock.Enums;

namespace Payinvstock.Dto.Inventory.StockReason;

public class CreateStockReasonDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// If the transaction is input or output
    /// </summary>
    public TransactionType InputOrOutput { get; set; }
}