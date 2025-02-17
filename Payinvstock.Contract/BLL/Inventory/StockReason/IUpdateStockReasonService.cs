using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Contract.BLL.Inventory.StockReason;

public interface IUpdateStockReasonService
{
    Task<GetStockReasonDto?> UpdateStockReasonAsync(Guid id, UpdateStockReasonDto model);
}