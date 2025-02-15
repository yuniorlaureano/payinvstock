using AutoMapper;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Bll.General.Unit;

public class GetUnitService : IGetUnitService
{
    private readonly IGetUnitRepo _getUnitRepo;
    private readonly IMapper _mapper;

    public GetUnitService(IGetUnitRepo getUnitRepo, IMapper mapper)
    {
        _getUnitRepo = getUnitRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUnitDto>> GetUnitsAsync()
    {
        var result = await _getUnitRepo.GetUnitsAsync();
        return _mapper.Map<IEnumerable<GetUnitDto>>(result);
    }

    public async Task<GetUnitDto?> GetUnitAsync(Guid id)
    {
        var result = await _getUnitRepo.GetUnitAsync(id);
        return _mapper.Map<GetUnitDto?>(result);
    }
}