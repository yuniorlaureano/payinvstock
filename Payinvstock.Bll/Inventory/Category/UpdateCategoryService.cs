using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Category;
using Payinvstock.Contract.Dal.Inventory.Category;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Bll.Inventory.Category;

public class UpdateCategoryService : IUpdateCategoryService
{
    private readonly IUpdateCategoryRepo _updateCategoryRepo;
    private readonly IGetCategoryRepo _getCategoryRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateCategoryService(
        IUpdateCategoryRepo updateCategoryRepo,
        IGetCategoryRepo getCategoryRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateCategoryRepo = updateCategoryRepo;
        _getCategoryRepo = getCategoryRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task<GetCategoryDto?> UpdateCategoryAsync(Guid id, UpdateCategoryDto model)
    {
        var entity = await _getCategoryRepo.GetCategoryAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        entity.UpdatedAt = DateTime.UtcNow;

        await _updateCategoryRepo.UpdateCategoryAsync(entity);
        return _mapper.Map<GetCategoryDto>(entity);
    }
}