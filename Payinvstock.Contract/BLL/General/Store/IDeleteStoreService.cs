namespace Payinvstock.Contract.BLL.General.Store;

public interface IDeleteStoreService
{
    Task DeleteStoreAsync(Guid id);
}