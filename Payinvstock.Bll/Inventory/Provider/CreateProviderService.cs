using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Provider;
using Payinvstock.Contract.Dal.Inventory.Provider;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Bll.Inventory.Provider;

public class CreateProviderService : ICreateProviderService
{
    private readonly ICreateProviderRepo _createProviderRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateProviderService(
        ICreateProviderRepo createProviderRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createProviderRepo = createProviderRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateProviderAsync(CreateProviderDto model)
    {
        var entity = _mapper.Map<Entity.Inventory.Provider>(model);

        entity.CreatedBy = _userContextAccessor.GetCurrentUserId();
        entity.CreatedAt = DateTime.UtcNow;

        await _createProviderRepo.CreateProviderAsync(entity);
    }
}