using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Bll.Inventory.Product;

public class UpdateProductService : IUpdateProductService
{
    private readonly IUpdateProductRepo _updateProductRepo;
    private readonly IGetProductRepo _getProductRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateProductService(
        IUpdateProductRepo updateProductRepo,
        IGetProductRepo getProductRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateProductRepo = updateProductRepo;
        _getProductRepo = getProductRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task<GetProductDto?> UpdateProductAsync(Guid id, UpdateProductDto model)
    {
        var entity = await _getProductRepo.GetProductAsync(id);
        if (entity is null)
        {
            return null;
        }
        entity.Code = model.Code;
        entity.Name = model.Name;
        entity.Description = model.Description; 
        entity.Photo = model.Photo;
        entity.Price = model.Price;
        entity.ByUnitOrWeight = model.ByUnitOrWeight;
        entity.UnitValue = model.UnitValue;
        entity.UnitId = model.UnitId;
        entity.CategoryId = model.CategoryId;
        entity.Type = model.Type;
        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        entity.UpdatedAt = DateTime.UtcNow;

        await _updateProductRepo.UpdateProductAsync(entity);
        return _mapper.Map<GetProductDto>(entity);
    }
}