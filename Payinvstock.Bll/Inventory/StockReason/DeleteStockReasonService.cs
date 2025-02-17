using Payinvstock.Contract.BLL.Inventory.StockReason;
using Payinvstock.Contract.Dal.Inventory.StockReason;

namespace Payinvstock.Bll.Inventory.StockReason;

public class DeleteStockReasonService : IDeleteStockReasonService
{
    private readonly IDeleteStockReasonRepo _deleteStockReasonRepo;

    public DeleteStockReasonService(IDeleteStockReasonRepo deleteStockReasonRepo)
    {
        _deleteStockReasonRepo = deleteStockReasonRepo;
    }

    public async Task DeleteStockReasonAsync(Guid id)
    {
        await _deleteStockReasonRepo.DeleteStockReasonAsync(id);
    }
}