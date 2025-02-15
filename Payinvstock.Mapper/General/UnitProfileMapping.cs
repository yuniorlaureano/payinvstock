using AutoMapper;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Mapper.Inventory;

public class UnitProfileMapping : Profile
{
    public UnitProfileMapping()
    {
        CreateMap<Entity.General.Unit, CreateUnitDto>().ReverseMap();
        CreateMap<Entity.General.Unit, UpdateUnitDto>().ReverseMap();
        CreateMap<Entity.General.Unit, GetUnitDto>().ReverseMap();
    }
}