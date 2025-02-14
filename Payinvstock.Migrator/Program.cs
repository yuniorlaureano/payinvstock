using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Payinvstock.Migrator;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("-----------------------------");
        Console.WriteLine("1 - Create database");
        Console.WriteLine("2 - Rollback database");
        Console.WriteLine("-----------------------------");

        var option = Console.ReadLine();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();


        var service = CreateService(configuration);
        using var scope = service.CreateScope();

        switch (option)
        {
            case "1":
                UpdateDatabase(scope.ServiceProvider);
                break;
            case "2":
                Console.WriteLine("Please provide a valid target version to rollback to.");
                var targetVersion = Console.ReadLine();
                if (long.TryParse(targetVersion, out long version))
                {
                    RollbackDatabase(scope.ServiceProvider, version);
                }
                else
                {
                    Console.WriteLine("Please provide a valid target version to rollback to.");
                }
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }

    private static IServiceProvider CreateService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return new ServiceCollection()
            .AddSingleton(configuration)
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    private static void UpdateDatabase(IServiceProvider service)
    {
        var runner = service.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }

    private static void RollbackDatabase(IServiceProvider service, long targetVersion)
    {
        var runner = service.GetRequiredService<IMigrationRunner>();
        runner.MigrateDown(targetVersion);

    }
}