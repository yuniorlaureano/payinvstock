using Payinvstock.Dto.General.Store;

namespace Payinvstock.Contract.BLL.General.Store;

public interface ICreateStoreService
{
    Task CreateStoreAsync(CreateStoreDto model);
}