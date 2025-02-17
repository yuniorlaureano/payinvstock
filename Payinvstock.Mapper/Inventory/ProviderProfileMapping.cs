using AutoMapper;
using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Mapper.Inventory;

public class ProviderProfileMapping : Profile
{
    public ProviderProfileMapping()
    {
        CreateMap<Entity.Inventory.Provider, CreateProviderDto>().ReverseMap();
        CreateMap<Entity.Inventory.Provider, UpdateProviderDto>().ReverseMap();
        CreateMap<Entity.Inventory.Provider, GetProviderDto>().ReverseMap();
    }
}