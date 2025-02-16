using AutoMapper;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Bll.General.Unit;

public class UpdateUnitService : IUpdateUnitService
{
    private readonly IUpdateUnitRepo _updateUnitRepo;
    private readonly IGetUnitRepo _getUnitRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateUnitService(
        IUpdateUnitRepo updateUnitRepo,
        IGetUnitRepo getUnitRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateUnitRepo = updateUnitRepo;
        _getUnitRepo = getUnitRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task<GetUnitDto?> UpdateUnitAsync(Guid id, UpdateUnitDto model)
    {
        var entity = await _getUnitRepo.GetUnitAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.Code = model.Code;
        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        entity.UpdatedAt = DateTime.UtcNow;

        await _updateUnitRepo.UpdateUnitAsync(entity);
        return _mapper.Map<GetUnitDto>(entity);
    }
}