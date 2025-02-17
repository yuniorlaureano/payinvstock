using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.StockReason;
using Payinvstock.Contract.Dal.Inventory.StockReason;
using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Bll.Inventory.StockReason;

public class GetStockReasonService : IGetStockReasonService
{
    private readonly IGetStockReasonRepo _getStockReasonRepo;
    private readonly IMapper _mapper;

    public GetStockReasonService(IGetStockReasonRepo getStockReasonRepo, IMapper mapper)
    {
        _getStockReasonRepo = getStockReasonRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetStockReasonDto>> GetStockReasonsAsync()
    {
        var result = await _getStockReasonRepo.GetStockReasonsAsync();
        return _mapper.Map<IEnumerable<GetStockReasonDto>>(result);
    }

    public async Task<GetStockReasonDto?> GetStockReasonAsync(Guid id)
    {
        var result = await _getStockReasonRepo.GetStockReasonAsync(id);
        return _mapper.Map<GetStockReasonDto?>(result);
    }
}