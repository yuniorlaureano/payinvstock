using Payinvstock.Dto.Inventory.Existence;

namespace Payinvstock.Contract.BLL.Inventory.Existence;

public interface IGetExistenceRepo
{
    Task<IEnumerable<GetExistenceDto>> GetExistenceAsync();
}