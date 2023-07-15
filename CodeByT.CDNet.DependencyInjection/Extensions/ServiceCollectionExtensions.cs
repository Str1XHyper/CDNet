using CodeByT.CDNet.DataAccess.Contexts;
using CodeByT.CDNet.Interfaces.DataAccessInterfaces.Contexts;
using CodeByT.CDNet.Interfaces.RepositoryInterfaces;
using CodeByT.CDNet.Interfaces.ServiceInterfaces;
using CodeByT.CDNet.Repositories;
using CodeByT.CDNet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeByT.CDNet.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterCDNetServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IImageService, ImageService>();

        services.AddTransient<IImageRepo, ImageRepo>();
        
        services.AddTransient<IDefaultContext, DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine(connectionString);
        services.AddDbContext<DefaultContext>(options =>
        {
            options.UseMySql(connectionString ?? throw new InvalidOperationException(), ServerVersion.AutoDetect(connectionString), b =>
            {
                b.EnableRetryOnFailure();
                b.MigrationsAssembly(("CodeByT.CDNet.Controller"));
            });
        });
    }
}