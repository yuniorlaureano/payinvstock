using AutoMapper;
using Payinvstock.Contract.BLL.General.Store;
using Payinvstock.Contract.Dal.General.Store;
using Payinvstock.Dto.General.Store;

namespace Payinvstock.Bll.General.Store;

public class GetStoreService : IGetStoreService
{
    private readonly IGetStoreRepo _getStoreRepo;
    private readonly IMapper _mapper;

    public GetStoreService(IGetStoreRepo getStoreRepo, IMapper mapper)
    {
        _getStoreRepo = getStoreRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetStoreDto>> GetStoresAsync()
    {
        var result = await _getStoreRepo.GetStoresAsync();
        return _mapper.Map<IEnumerable<GetStoreDto>>(result);
    }

    public async Task<GetStoreDto?> GetStoreAsync(Guid id)
    {
        var result = await _getStoreRepo.GetStoreAsync(id);
        return _mapper.Map<GetStoreDto?>(result);
    }
}