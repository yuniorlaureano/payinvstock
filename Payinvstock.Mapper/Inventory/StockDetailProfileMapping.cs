using AutoMapper;
using Payinvstock.Dto.Inventory.StockDetail;

namespace Payinvstock.Mapper.Inventory;

public class StockDetailProfileMapping : Profile
{
    public StockDetailProfileMapping()
    {
        CreateMap<Entity.Inventory.StockDetail, CreateStockDetailDto>().ReverseMap();
    }
}