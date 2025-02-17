namespace Payinvstock.Contract.Dal.Inventory.Provider;

public interface IDeleteProviderRepo
{
    Task DeleteProviderAsync(Guid id);
}