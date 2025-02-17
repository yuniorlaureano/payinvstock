namespace Payinvstock.Contract.Dal.General.Store;

public interface IUpdateStoreRepo
{
    Task UpdateStoreAsync(Entity.General.Store model);
}