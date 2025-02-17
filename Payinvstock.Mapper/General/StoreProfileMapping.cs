using AutoMapper;
using Payinvstock.Dto.General.Store;

namespace Payinvstock.Mapper.Inventory;

public class StoreProfileMapping : Profile
{
    public StoreProfileMapping()
    {
        CreateMap<Entity.General.Store, CreateStoreDto>().ReverseMap();
        CreateMap<Entity.General.Store, UpdateStoreDto>().ReverseMap();
        CreateMap<Entity.General.Store, GetStoreDto>().ReverseMap();
    }
}