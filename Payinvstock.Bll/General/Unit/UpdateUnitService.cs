using AutoMapper;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Bll.General.Unit;

public class UpdateUnitService : IUpdateUnitService
{
    private readonly IUpdateUnitRepo _updateUnitRepo;
    private readonly IMapper _mapper;

    public UpdateUnitService(IUpdateUnitRepo updateUnitRepo, IMapper mapper)
    {
        _updateUnitRepo = updateUnitRepo;
        _mapper = mapper;
    }

    public async Task UpdateUnitAsync(UpdateUnitDto model)
    {
        var entity = _mapper.Map<Entity.General.Unit>(model);
        await _updateUnitRepo.UpdateUnitAsync(entity);
    }
}