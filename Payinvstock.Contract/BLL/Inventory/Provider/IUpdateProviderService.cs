using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Contract.BLL.Inventory.Provider;

public interface IUpdateProviderService
{
    Task<GetProviderDto?> UpdateProviderAsync(Guid id, UpdateProviderDto model);
}