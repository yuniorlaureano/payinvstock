namespace Payinvstock.Contract.Dal.General.Store;

public interface IDeleteStoreRepo
{
    Task DeleteStoreAsync(Guid id);
}