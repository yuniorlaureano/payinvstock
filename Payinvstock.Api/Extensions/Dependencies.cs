using Payinvstock.Bll.General.Unit;
using Payinvstock.Bll.Inventory.Product;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.General.Unit;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Dal;
using Payinvstock.Dal.General.Unit;
using Payinvstock.Dal.Inventory.Product;
using Payinvstock.Mapper.Inventory;

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

        return services;
    }

    /// <summary>
    /// Add repositories to the project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddRepos(IServiceCollection services, IConfiguration configuration)
    {
        //Product
        services.AddSingleton<IDapperContext, DapperContext>();
        services.AddScoped<ICreateProductRepo, CreateProductRepo>();
        services.AddScoped<IGetProductRepo, GetProductRepo>();
        services.AddScoped<IUpdateProductRepo, UpdateProductRepo>();
        services.AddScoped<IDeleteProductRepo, DeleteProductRepo>();

        //Unit
        services.AddScoped<ICreateUnitRepo, CreateUnitRepo>();
        services.AddScoped<IGetUnitRepo, GetUnitRepo>();
        services.AddScoped<IUpdateUnitRepo, UpdateUnitRepo>();
        services.AddScoped<IDeleteUnitRepo, DeleteUnitRepo>();

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
        });
    }
}