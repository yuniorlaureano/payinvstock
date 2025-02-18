using AutoMapper;
using Payinvstock.Common.Exceptions;
using Payinvstock.Contract.BLL.Inventory.Stock;
using Payinvstock.Contract.Dal.Inventory.Stock;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Bll.Inventory.Stock;

public class CreateStockService : ICreateStockService
{
    private readonly ICreateStockRepo _createStockRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateStockService(
        ICreateStockRepo createStockRepo, 
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createStockRepo = createStockRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    /// <summary>
    /// Create a new stock
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="InvalidStockException"></exception>
    public async Task CreateStockAsync(CreateStockDto model)
    {
        if (model == null)
        {
            throw new InvalidStockException("Stock to add can not be null");
        }

        if (!model.Detail.Any())
        {
            throw new InvalidStockException("No products added to the stock");
        }


        var stock = _mapper.Map<Entity.Inventory.Stock>(model);
        var detail = _mapper.Map<List<Entity.Inventory.StockDetail>>(model.Detail);

        stock.CreatedBy = _userContextAccessor.GetCurrentUserId();
        stock.CreatedAt = DateTime.UtcNow;
        stock.Date = DateTime.UtcNow;

        await _createStockRepo.CreateStockAsync(stock, detail);
    }
}