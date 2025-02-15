namespace Payinvstock.Contract.BLL.General.Unit;

public interface IDeleteUnitService
{
    Task DeleteUnitAsync(Guid id);
}