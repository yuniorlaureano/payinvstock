namespace Payinvstock.Contract.Dal.Inventory.Provider;

public interface ICreateProviderRepo
{
    Task CreateProviderAsync(Entity.Inventory.Provider model);
}