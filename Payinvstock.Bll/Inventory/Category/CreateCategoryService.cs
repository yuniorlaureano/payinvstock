using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Category;
using Payinvstock.Contract.Dal.Inventory.Category;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Bll.Inventory.Category;

public class CreateCategoryService : ICreateCategoryService
{
    private readonly ICreateCategoryRepo _createCategoryRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateCategoryService(
        ICreateCategoryRepo createCategoryRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createCategoryRepo = createCategoryRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto model)
    {
        var entity = _mapper.Map<Entity.Inventory.Category>(model);

        entity.CreatedBy = _userContextAccessor.GetCurrentUserId();
        entity.CreatedAt = DateTime.UtcNow;

        await _createCategoryRepo.CreateCategoryAsync(entity);
    }
}