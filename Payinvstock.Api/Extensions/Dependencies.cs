using Payinvstock.Bll.General.Unit;
using Payinvstock.Bll.Inventory.Category;
using Payinvstock.Bll.Inventory.Product;
using Payinvstock.Bll.Inventory.StockReason;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.BLL.Inventory.Category;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.BLL.Inventory.StockReason;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Contract.Dal.Inventory.Category;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.StockReason;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Dal;
using Payinvstock.Dal.General.Unit;
using Payinvstock.Dal.Inventory.Category;
using Payinvstock.Dal.Inventory.Product;
using Payinvstock.Dal.Inventory.StockReason;
using Payinvstock.Mapper.Inventory;
using Payinvstock.Util.Http;

namespace Payinvstock.Api.Extensions;

/// <summary>
/// Add dependencies to the project.
/// All dependencies are added here.
/// </summary>
public static class Dependencies
{
    /// <summary>
    /// Add all dependencies to the project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddPayinvstockDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepos(services, configuration);
        AddServices(services, configuration);
        AddConfigurations(services, configuration);
        AddMappers(services);
        AddHttpContextAccessors(services);
        
        return services;
    }

    /// <summary>
    /// Add repositories to the project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddRepos(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDapperContext, DapperContext>();

        //Product
        services.AddScoped<ICreateProductRepo, CreateProductRepo>();
        services.AddScoped<IGetProductRepo, GetProductRepo>();
        services.AddScoped<IUpdateProductRepo, UpdateProductRepo>();
        services.AddScoped<IDeleteProductRepo, DeleteProductRepo>();

        //Unit
        services.AddScoped<ICreateUnitRepo, CreateUnitRepo>();
        services.AddScoped<IGetUnitRepo, GetUnitRepo>();
        services.AddScoped<IUpdateUnitRepo, UpdateUnitRepo>();
        services.AddScoped<IDeleteUnitRepo, DeleteUnitRepo>();

        //Category 
        services.AddScoped<ICreateCategoryRepo, CreateCategoryRepo>();
        services.AddScoped<IGetCategoryRepo, GetCategoryRepo>();
        services.AddScoped<IUpdateCategoryRepo, UpdateCategoryRepo>();
        services.AddScoped<IDeleteCategoryRepo, DeleteCategoryRepo>();

        //StockReason
        services.AddScoped<ICreateStockReasonRepo, CreateStockReasonRepo>();
        services.AddScoped<IGetStockReasonRepo, GetStockReasonRepo>();
        services.AddScoped<IUpdateStockReasonRepo, UpdateStockReasonRepo>();
        services.AddScoped<IDeleteStockReasonRepo, DeleteStockReasonRepo>();

    }

    /// <summary>
    /// Add services to the project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        //Product
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<IGetProductService, GetProductService>();
        services.AddScoped<IUpdateProductService, UpdateProductService>();
        services.AddScoped<IDeleteProductService, DeleteProductService>();

        //Unit
        services.AddScoped<ICreateUnitService, CreateUnitService>();
        services.AddScoped<IGetUnitService, GetUnitService>();
        services.AddScoped<IUpdateUnitService, UpdateUnitService>();
        services.AddScoped<IDeleteUnitService, DeleteUnitService>();

        //Category
        services.AddScoped<ICreateCategoryService, CreateCategoryService>();
        services.AddScoped<IGetCategoryService, GetCategoryService>();
        services.AddScoped<IUpdateCategoryService, UpdateCategoryService>();
        services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();

        //StockReason
        services.AddScoped<ICreateStockReasonService, CreateStockReasonService>();
        services.AddScoped<IGetStockReasonService, GetStockReasonService>();
        services.AddScoped<IUpdateStockReasonService, UpdateStockReasonService>();
        services.AddScoped<IDeleteStockReasonService, DeleteStockReasonService>();

    }

    /// <summary>
    /// Add configurations to the project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddConfigurations(IServiceCollection services, IConfiguration configuration)
    {

    }

    /// <summary>
    /// Add mapper profiles
    /// </summary>
    /// <param name="services"></param>
    public static void AddMappers(IServiceCollection services)
    {
        services.AddAutoMapper(mapper =>
        {
            //General
            mapper.AddProfile(new UnitProfileMapping());

            //Inventory
            mapper.AddProfile(new ProductProfileMapping());
            mapper.AddProfile(new CategoryProfileMapping());
            mapper.AddProfile(new StockReasonProfileMapping());
        });
    }

    /// <summary>
    /// Add HttpContext accessors
    /// </summary>
    /// <param name="services"></param>
    public static void AddHttpContextAccessors(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        //Service for getting user information from HttpContext
        services.AddScoped<IUserHttpContextAccessor, UserHttpContextAccessor>();
    }
}