namespace Payinvstock.Contract.Dal.General.Store;

public interface IGetStoreRepo
{
    Task<IEnumerable<Entity.General.Store>> GetStoresAsync();
    Task<Entity.General.Store?> GetStoreAsync(Guid id);
}