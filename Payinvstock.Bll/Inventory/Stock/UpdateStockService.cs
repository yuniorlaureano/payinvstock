using AutoMapper;
using Payinvstock.Common.Exceptions;
using Payinvstock.Contract.BLL.Inventory.Stock;
using Payinvstock.Contract.Dal.Inventory.Stock;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Bll.Inventory.Stock;

public class UpdateStockService : IUpdateStockService
{
    private readonly IUpdateStockRepo _updateStockRepo;
    private readonly IGetStockRepo _getStockRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateStockService(
        IUpdateStockRepo updateStockRepo,
        IGetStockRepo getStockRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateStockRepo = updateStockRepo;
        _getStockRepo = getStockRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    /// <summary>
    /// Update stock
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="InvalidStatusException">Thrown when the status is Saved, and an attempt is made to change is to Draft or Cancelled</exception>
    public async Task UpdateStockAsync(Guid id, UpdateStockDto model)
    {
        var entity = await _getStockRepo.GetStockAsync(id);
        if (entity is null)
        {
            return;
        }

        ThrowIfStatusIsSavedAndIsAboutToChange(entity, model);
        ThrowIfNewStatusIsCancelled(model);

        var stock = _mapper.Map<Entity.Inventory.Stock>(model);
        var detail = _mapper.Map<List<Entity.Inventory.StockDetail>>(model.Detail);
        stock.Id = id;
        stock.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        await _updateStockRepo.UpdateStockAsync(stock, detail);
    }

    /// <summary>
    /// Throw when an attempt is made to change a saved stock to draft or cancelled
    /// </summary>
    /// <param name="existing"></param>
    /// <param name="model"></param>
    /// <exception cref="InvalidStatusException"></exception>
    private static void ThrowIfStatusIsSavedAndIsAboutToChange(Entity.Inventory.Stock existing, UpdateStockDto newOne)
    {
        var isExistingSavedStatus = existing.Status == Enums.Inventory.StockStatus.Saved;
        var isNewNotSavedStatus = newOne.Status != Enums.Inventory.StockStatus.Saved;
        if (isExistingSavedStatus && isNewNotSavedStatus)
        {
            throw new InvalidStatusException("It is not allowed to change Saved stock to Draft or Cancelled Stock");
        }
    }

    /// <summary>
    /// Throw when new status is Cancelled
    /// </summary>
    /// <param name="model"></param>
    /// <exception cref="InvalidStatusException"></exception>
    private static void ThrowIfNewStatusIsCancelled(UpdateStockDto newOne)
    {
        if (newOne.Status == Enums.Inventory.StockStatus.Canceled)
        {
            throw new InvalidStatusException("Can not save a Stock with Cancelled status");
        }
    }
}