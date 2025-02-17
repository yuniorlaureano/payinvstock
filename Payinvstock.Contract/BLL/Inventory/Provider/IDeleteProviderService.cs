namespace Payinvstock.Contract.BLL.Inventory.Provider;

public interface IDeleteProviderService
{
    Task DeleteProviderAsync(Guid id);
}