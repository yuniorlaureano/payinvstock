using Payinvstock.Contract.Dal.Inventory.Provider;
using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Contract.BLL.Inventory.Provider;

public interface IGetProviderService
{
    Task<IEnumerable<GetProviderDto>> GetProvidersAsync();

    Task<GetProviderDto?> GetProviderAsync(Guid id);
}