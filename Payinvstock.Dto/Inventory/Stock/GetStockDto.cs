﻿using Payinvstock.Enums.Inventory;

namespace Payinvstock.Dto.Inventory.Stock;

public class GetStockDto
{
    public Guid Id { get; set; }
    public StockStatus Status { get; set; }
    public string? Note { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid StoreId { get; set; }
    public Guid ReasonId { get; set; }
}