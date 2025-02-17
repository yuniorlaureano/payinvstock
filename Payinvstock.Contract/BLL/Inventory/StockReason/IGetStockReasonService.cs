using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Contract.BLL.Inventory.StockReason;

public interface IGetStockReasonService
{
    Task<IEnumerable<GetStockReasonDto>> GetStockReasonsAsync();
    Task<GetStockReasonDto?> GetStockReasonAsync(Guid id);
}