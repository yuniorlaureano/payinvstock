namespace Payinvstock.Contract.Dal.General.Unit;

public interface IDeleteUnitRepo
{
    Task DeleteUnitAsync(Guid id);
}