using AutoMapper;
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

    public async Task UpdateStockAsync(Guid id, UpdateStockDto model)
    {
        var entity = await _getStockRepo.GetStockAsync(id);
        if (entity is null)
        {
            return;
        }

        var stock = _mapper.Map<Entity.Inventory.Stock>(model);
        var detail = _mapper.Map<List<Entity.Inventory.StockDetail>>(model.Detail);
        stock.Id = id;
        stock.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        await _updateStockRepo.UpdateStockAsync(stock, detail);
    }
}