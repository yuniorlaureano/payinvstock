namespace Payinvstock.Contract.Dal.Inventory.Provider;

public interface IUpdateProviderRepo
{
    Task UpdateProviderAsync(Entity.Inventory.Provider model);
}