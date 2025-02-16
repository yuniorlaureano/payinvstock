using AutoMapper;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Bll.General.Unit;

public class CreateUnitService : ICreateUnitService
{
    private readonly ICreateUnitRepo _createUnitRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateUnitService(
        ICreateUnitRepo createUnitRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createUnitRepo = createUnitRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateUnitAsync(CreateUnitDto model)
    {
        var entity = _mapper.Map<Entity.General.Unit>(model);

        entity.CreatedBy = _userContextAccessor.GetCurrentUserId();
        entity.CreatedAt = DateTime.UtcNow;

        await _createUnitRepo.CreateUnitAsync(entity);
    }
}