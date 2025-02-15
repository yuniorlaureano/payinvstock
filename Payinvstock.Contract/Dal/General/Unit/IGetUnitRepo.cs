namespace Payinvstock.Contract.Dal.General.Unit;

public interface IGetUnitRepo
{
    Task<IEnumerable<Entity.General.Unit>> GetUnitsAsync();
    Task<Entity.General.Unit?> GetUnitAsync(Guid id);
}