using AutoMapper;
using Payinvstock.Contract.BLL.General.Store;
using Payinvstock.Contract.Dal.General.Store;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.General.Store;

namespace Payinvstock.Bll.General.Store;

public class CreateStoreService : ICreateStoreService
{
    private readonly ICreateStoreRepo _createStoreRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateStoreService(
        ICreateStoreRepo createStoreRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createStoreRepo = createStoreRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateStoreAsync(CreateStoreDto model)
    {
        var entity = _mapper.Map<Entity.General.Store>(model);

        entity.CreatedBy = _userContextAccessor.GetCurrentUserId();
        entity.CreatedAt = DateTime.UtcNow;

        await _createStoreRepo.CreateStoreAsync(entity);
    }
}