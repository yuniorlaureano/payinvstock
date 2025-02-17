using Payinvstock.Dto.General.Store;

namespace Payinvstock.Contract.BLL.General.Store;

public interface IGetStoreService
{
    Task<IEnumerable<GetStoreDto>> GetStoresAsync();
    Task<GetStoreDto?> GetStoreAsync(Guid id);
}