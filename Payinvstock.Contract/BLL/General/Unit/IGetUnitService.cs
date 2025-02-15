using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Contract.BLL.General.Unit;

public interface IGetUnitService
{
    Task<IEnumerable<GetUnitDto>> GetUnitsAsync();
    Task<GetUnitDto?> GetUnitAsync(Guid id);
}