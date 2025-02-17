using AutoMapper;
using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Mapper.Inventory;

public class StockReasonProfileMapping : Profile
{
    public StockReasonProfileMapping()
    {
        CreateMap<Entity.Inventory.StockReason, CreateStockReasonDto>().ReverseMap();
        CreateMap<Entity.Inventory.StockReason, UpdateStockReasonDto>().ReverseMap();
        CreateMap<Entity.Inventory.StockReason, GetStockReasonDto>().ReverseMap();
    }
}