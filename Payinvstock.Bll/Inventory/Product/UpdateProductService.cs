using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Bll.Inventory.Product;

public class UpdateProductService : IUpdateProductService
{
    private readonly IUpdateProductRepo _updateProductRepo;
    private readonly IMapper _mapper;

    public UpdateProductService(IUpdateProductRepo updateProductRepo, IMapper mapper)
    {
        _updateProductRepo = updateProductRepo;
        _mapper = mapper;
    }

    public async Task UpdateProductAsync(UpdateProductDto model)
    {
        var product = _mapper.Map<Entity.Inventory.Product>(model);
        await _updateProductRepo.UpdateProductAsync(product);
    }
}