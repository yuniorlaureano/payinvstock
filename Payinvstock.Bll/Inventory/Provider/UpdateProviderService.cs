using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Provider;
using Payinvstock.Contract.Dal.Inventory.Provider;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Bll.Inventory.Provider;

public class UpdateProviderService : IUpdateProviderService
{
    private readonly IUpdateProviderRepo _updateProviderRepo;
    private readonly IGetProviderRepo _getProviderRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateProviderService(
        IUpdateProviderRepo updateProviderRepo,
        IGetProviderRepo getProviderRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateProviderRepo = updateProviderRepo;
        _getProviderRepo = getProviderRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task<GetProviderDto?> UpdateProviderAsync(Guid id, UpdateProviderDto model)
    {
        var entity = await _getProviderRepo.GetProviderAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.FirstName = model.FirstName;
        entity.LastName = model.LastName;
        entity.Identification = model.Identification;
        entity.IdentificationType = model.IdentificationType;
        entity.Phone = model.Phone;
        entity.Email = model.Email;
        entity.Street = model.Street;
        entity.BuildingNumber = model.BuildingNumber;
        entity.City = model.City;
        entity.State = model.State;
        entity.Country = model.Country;
        entity.PostalCode = model.PostalCode;
        entity.FormattedAddress = model.FormattedAddress;
        entity.Latitude = model.Latitude;
        entity.Longitude = model.Longitude;
        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        entity.UpdatedAt = DateTime.UtcNow;

        await _updateProviderRepo.UpdateProviderAsync(entity);
        return _mapper.Map<GetProviderDto>(entity);
    }
}