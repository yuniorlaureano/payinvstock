using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Bll.Inventory.Product;

public class GetProductService : IGetProductService
{
    private readonly IGetProductRepo _getProductRepo;
    private readonly IMapper _mapper;

    public GetProductService(IGetProductRepo getProductRepo, IMapper mapper)
    {
        _getProductRepo = getProductRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductDto>> GetProductsAsync()
    {
        var result = await _getProductRepo.GetProductsAsync();
        return _mapper.Map<IEnumerable<GetProductDto>>(result);
    }

    public async Task<GetProductDto?> GetProductAsync(Guid id)
    {
        var result = await _getProductRepo.GetProductAsync(id);
        return _mapper.Map<GetProductDto?>(result);
    }
}