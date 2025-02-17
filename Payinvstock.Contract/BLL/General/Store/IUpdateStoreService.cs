using Payinvstock.Dto.General.Store;

namespace Payinvstock.Contract.BLL.General.Store;

public interface IUpdateStoreService
{
    Task<GetStoreDto?> UpdateStoreAsync(Guid id, UpdateStoreDto model);
}