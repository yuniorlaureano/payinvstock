using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.StockReason;
using Payinvstock.Contract.Dal.Inventory.StockReason;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Bll.Inventory.StockReason;

public class CreateStockReasonService : ICreateStockReasonService
{
    private readonly ICreateStockReasonRepo _createStockReasonRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateStockReasonService(
        ICreateStockReasonRepo createStockReasonRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createStockReasonRepo = createStockReasonRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateStockReasonAsync(CreateStockReasonDto model)
    {
        var entity = _mapper.Map<Entity.Inventory.StockReason>(model);

        entity.CreatedBy = _userContextAccessor.GetCurrentUserId();
        entity.CreatedAt = DateTime.UtcNow;

        await _createStockReasonRepo.CreateStockReasonAsync(entity);
    }
}