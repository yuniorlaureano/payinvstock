namespace Payinvstock.Contract.Dal.General.Unit;

public interface IUpdateUnitRepo
{
    Task UpdateUnitAsync(Entity.General.Unit model);
}