namespace Payinvstock.Contract.Dal.General.Unit;

public interface ICreateUnitRepo
{
    Task CreateUnitAsync(Entity.General.Unit model);
}