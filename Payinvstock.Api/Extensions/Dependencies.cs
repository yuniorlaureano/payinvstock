using Payinvstock.Bll.Inventory.Product;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Product;
using Payinvstock.Dal;
using Payinvstock.Dal.Inventory.Product;

namespace Payinvstock.Api.Extensions;

public static class Dependencies
{
    public static IServiceCollection AddPayinvstockDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepos(services, configuration);
        AddServices(services, configuration);
        AddConfigurations(services, configuration);

        services.AddAutoMapper(typeof(Dependencies));
        
        return services;
    }

    public static void AddRepos(IServiceCollection services, IConfiguration configuration)
    {
        //Product
        services.AddSingleton<IDapperContext, DapperContext>();
        services.AddScoped<ICreateProductRepo, CreateProductRepo>();
        services.AddScoped<IGetProductRepo, GetProductRepo>();
        services.AddScoped<IUpdateProductRepo, UpdateProductRepo>();
        services.AddScoped<IDeleteProductRepo, DeleteProductRepo>();
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        //Product
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<IGetProductService, GetProductService>();
        services.AddScoped<IUpdateProductService, UpdateProductService>();
        services.AddScoped<IDeleteProductService, DeleteProductService>();
    }

    public static void AddConfigurations(IServiceCollection services, IConfiguration configuration)
    {

    }
}