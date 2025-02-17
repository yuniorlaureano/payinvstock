using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Contract.BLL.Inventory.Provider;

public interface ICreateProviderService
{
    Task CreateProviderAsync(CreateProviderDto model);
}