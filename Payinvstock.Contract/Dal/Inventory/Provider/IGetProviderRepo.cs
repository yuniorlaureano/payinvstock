namespace Payinvstock.Contract.Dal.Inventory.Provider;

public interface IGetProviderRepo
{
    Task<IEnumerable<Entity.Inventory.Provider>> GetProvidersAsync();

    Task<Entity.Inventory.Provider?> GetProviderAsync(Guid id);
}