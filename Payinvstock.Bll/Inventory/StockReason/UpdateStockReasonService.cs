using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.StockReason;
using Payinvstock.Contract.Dal.Inventory.StockReason;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Bll.Inventory.StockReason;

public class UpdateStockReasonService : IUpdateStockReasonService
{
    private readonly IUpdateStockReasonRepo _updateStockReasonRepo;
    private readonly IGetStockReasonRepo _getStockReasonRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateStockReasonService(
        IUpdateStockReasonRepo updateStockReasonRepo,
        IGetStockReasonRepo getStockReasonRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateStockReasonRepo = updateStockReasonRepo;
        _getStockReasonRepo = getStockReasonRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task<GetStockReasonDto?> UpdateStockReasonAsync(Guid id, UpdateStockReasonDto model)
    {
        var entity = await _getStockReasonRepo.GetStockReasonAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.InputOrOutput = model.InputOrOutput;
        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        entity.UpdatedAt = DateTime.UtcNow;

        await _updateStockReasonRepo.UpdateStockReasonAsync(entity);
        return _mapper.Map<GetStockReasonDto>(entity);
    }
}