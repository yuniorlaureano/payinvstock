using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Stock;
using Payinvstock.Contract.Dal.Inventory.Stock;
using Payinvstock.Contract.Dal.Inventory.StockDetail;
using Payinvstock.Dto.Inventory.Stock;
using Payinvstock.Dto.Inventory.StockDetail;

namespace Payinvstock.Bll.Inventory.Stock;

public class GetStockService : IGetStockService
{
    private readonly IGetStockRepo _getStockRepo;
    private readonly IGetStockDetailRepo _getStockDetailRepo;
    private readonly IMapper _mapper;

    public GetStockService(
        IGetStockRepo getStockRepo, 
        IGetStockDetailRepo getStockDetailRepo,
        IMapper mapper)
    {
        _getStockRepo = getStockRepo;
        _getStockDetailRepo = getStockDetailRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetStockDto>> GetStocksAsync()
    {
        var result = await _getStockRepo.GetStocksAsync();
        return _mapper.Map<IEnumerable<GetStockDto>>(result);
    }

    public async Task<GetStockDto?> GetStockAsync(Guid id)
    {
        var stock = _mapper.Map<GetStockDto>(await _getStockRepo.GetStockAsync(id));
        if (stock == null)
        {
            return null;
        }

        stock.Detail = _mapper.Map<List<GetStockDetailDto>>(await _getStockDetailRepo.GetStockDetailByStockIdAsync(id));
        return stock;
    }
}