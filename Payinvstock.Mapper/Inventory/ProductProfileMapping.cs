using AutoMapper;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Mapper.Inventory;

public class ProductProfileMapping : Profile
{
    public ProductProfileMapping()
    {
        CreateMap<Entity.Inventory.Product, CreateProductDto>().ReverseMap();
        CreateMap<Entity.Inventory.Product, UpdateProductDto>().ReverseMap();
        CreateMap<Entity.Inventory.Product, GetProductDto>().ReverseMap();
    }
}