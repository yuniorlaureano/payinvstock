using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Bll.Inventory.Product;

public class CreateProductService : ICreateProductService
{
    private readonly ICreateProductRepo _createProductRepo;
    private readonly IMapper _mapper;

    public CreateProductService(ICreateProductRepo createProductRepo, IMapper mapper)
    {
        _createProductRepo = createProductRepo;
        _mapper = mapper;
    }

    public async Task CreateProductAsync(CreateProductDto model)
    {
        var product = _mapper.Map<Entity.Inventory.Product>(model); 
        await _createProductRepo.CreateProductAsync(product);
    }
}