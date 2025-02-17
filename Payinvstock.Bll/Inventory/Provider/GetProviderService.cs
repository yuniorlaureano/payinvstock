using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Provider;
using Payinvstock.Contract.Dal.Inventory.Provider;
using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Bll.Inventory.Provider;

public class GetProviderService : IGetProviderService
{
    private readonly IGetProviderRepo _getProviderRepo;
    private readonly IMapper _mapper;

    public GetProviderService(IGetProviderRepo getProviderRepo, IMapper mapper)
    {
        _getProviderRepo = getProviderRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProviderDto>> GetProvidersAsync()
    {
        var result = await _getProviderRepo.GetProvidersAsync();
        return _mapper.Map<IEnumerable<GetProviderDto>>(result);
    }

    public async Task<GetProviderDto?> GetProviderAsync(Guid id)
    {
        var result = await _getProviderRepo.GetProviderAsync(id);
        return _mapper.Map<GetProviderDto?>(result);
    }
}