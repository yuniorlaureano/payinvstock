using AutoMapper;
using Payinvstock.Contract.BLL.General.Store;
using Payinvstock.Contract.Dal.General.Store;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.General.Store;

namespace Payinvstock.Bll.General.Store;

public class UpdateStoreService : IUpdateStoreService
{
    private readonly IUpdateStoreRepo _updateStoreRepo;
    private readonly IGetStoreRepo _getStoreRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public UpdateStoreService(
        IUpdateStoreRepo updateStoreRepo,
        IGetStoreRepo getStoreRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _updateStoreRepo = updateStoreRepo;
        _getStoreRepo = getStoreRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task<GetStoreDto?> UpdateStoreAsync(Guid id, UpdateStoreDto model)
    {
        var entity = await _getStoreRepo.GetStoreAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.Code = model.Code;
        entity.Name = model.Name;
        entity.Photo = model.Photo;
        entity.Address = model.Address;
        entity.Latitude = model.Latitude;
        entity.Longitude = model.Longitude;

        entity.Description = model.Description;
        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        entity.UpdatedAt = DateTime.UtcNow;

        await _updateStoreRepo.UpdateStoreAsync(entity);
        return _mapper.Map<GetStoreDto>(entity);
    }
}