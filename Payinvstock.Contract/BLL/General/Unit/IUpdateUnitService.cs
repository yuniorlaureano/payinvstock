using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Contract.BLL.General.Unit;

public interface IUpdateUnitService
{
    Task<GetUnitDto?> UpdateUnitAsync(Guid id, UpdateUnitDto model);
}