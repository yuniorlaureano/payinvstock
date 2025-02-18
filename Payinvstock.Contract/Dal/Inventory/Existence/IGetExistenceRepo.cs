using Payinvstock.Dto.Inventory.Existence;

namespace Payinvstock.Contract.Dal.Inventory.Existence;

public interface IGetExistenceService
{
    Task<IEnumerable<GetExistenceDto>> GetExistenceAsync();
}