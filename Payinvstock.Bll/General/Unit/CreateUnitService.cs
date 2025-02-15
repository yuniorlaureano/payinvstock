using AutoMapper;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Bll.General.Unit;

public class CreateUnitService : ICreateUnitService
{
    private readonly ICreateUnitRepo _createUnitRepo;
    private readonly IMapper _mapper;

    public CreateUnitService(ICreateUnitRepo createUnitRepo, IMapper mapper)
    {
        _createUnitRepo = createUnitRepo;
        _mapper = mapper;
    }

    public async Task CreateUnitAsync(CreateUnitDto model)
    {
        var entity = _mapper.Map<Entity.General.Unit>(model);
        await _createUnitRepo.CreateUnitAsync(entity);
    }
}