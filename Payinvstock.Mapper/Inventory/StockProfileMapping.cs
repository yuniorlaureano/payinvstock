using AutoMapper;
using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Mapper.Inventory;

public class StockProfileMapping : Profile
{
    public StockProfileMapping()
    {
        CreateMap<Entity.Inventory.Stock, CreateStockDto>().ReverseMap();
        //CreateMap<Entity.Inventory.Stock, UpdateStockDto>().ReverseMap();
        CreateMap<Entity.Inventory.Stock, GetStockDto>().ReverseMap();
    }
}