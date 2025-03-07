﻿using AutoMapper;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Bll.Inventory.Product;

public class CreateProductService : ICreateProductService
{
    private readonly ICreateProductRepo _createProductRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;
    private readonly IMapper _mapper;

    public CreateProductService(
        ICreateProductRepo createProductRepo,
        IUserHttpContextAccessor userContextAccessor,
        IMapper mapper)
    {
        _createProductRepo = createProductRepo;
        _userContextAccessor = userContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateProductAsync(CreateProductDto model)
    {
        var entity = _mapper.Map<Entity.Inventory.Product>(model);

        entity.CreatedBy = _userContextAccessor.GetCurrentUserId();
        entity.CreatedAt = DateTime.UtcNow;

        await _createProductRepo.CreateProductAsync(entity);
    }
}