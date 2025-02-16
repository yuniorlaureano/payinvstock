using AutoMapper;
using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Mapper.Inventory;

public class CategoryProfileMapping : Profile
{
    public CategoryProfileMapping()
    {
        CreateMap<Entity.Inventory.Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Entity.Inventory.Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Entity.Inventory.Category, GetCategoryDto>().ReverseMap();
    }
}