using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Category;
using Payinvstock.Contract.Dal.Inventory.Category;
using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Bll.Inventory.Category;

public class GetCategoryService : IGetCategoryService
{
    private readonly IGetCategoryRepo _getCategoryRepo;
    private readonly IMapper _mapper;

    public GetCategoryService(IGetCategoryRepo getCategoryRepo, IMapper mapper)
    {
        _getCategoryRepo = getCategoryRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetCategoryDto>> GetCategoriesAsync()
    {
        var result = await _getCategoryRepo.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<GetCategoryDto>>(result);
    }

    public async Task<GetCategoryDto?> GetCategoryAsync(Guid id)
    {
        var result = await _getCategoryRepo.GetCategoryAsync(id);
        return _mapper.Map<GetCategoryDto?>(result);
    }
}