using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Contract.BLL.Inventory.StockReason;

public interface ICreateStockReasonService
{
    Task CreateStockReasonAsync(CreateStockReasonDto model);
}