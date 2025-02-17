namespace Payinvstock.Contract.Dal.General.Store;

public interface ICreateStoreRepo
{
    Task CreateStoreAsync(Entity.General.Store model);
}