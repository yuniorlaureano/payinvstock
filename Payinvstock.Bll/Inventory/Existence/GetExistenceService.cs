using Payinvstock.Contract.BLL.Inventory.Existence;
using Payinvstock.Contract.Dal.Inventory.Existence;
using Payinvstock.Dto.Inventory.Existence;

namespace Payinvstock.Bll.Inventory.Existence;

public class GetExistenceService : IGetExistenceService
{
    private readonly IGetExistenceRepo _getExistenceRepo;

    public GetExistenceService(IGetExistenceRepo getExistenceRepo)
    {
        _getExistenceRepo = getExistenceRepo;
    }

    public async Task<IEnumerable<GetExistenceDto>> GetExistenceAsync()
    {
        return await _getExistenceRepo.GetExistenceAsync();
    }
}