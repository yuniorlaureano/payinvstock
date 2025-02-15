using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Contract.BLL.General.Unit;

public interface ICreateUnitService
{
    Task CreateUnitAsync(CreateUnitDto model);
}