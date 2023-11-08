using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fteam.Article.Services.Implementation.Injection;

public static class Injector
{
    public static IServiceCollection AddCoffeeBaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region -- Data Base SQL --

        string connection = configuration.GetConnectionString("ArticleDb") ?? "";
        ArticleContext.ConnectionString = connection;
        services.AddDbContext<ArticleContext>(options => options.UseSqlServer(connection));

        #endregion

        #region -- Data Base No SQL --

        //services.AddSingleton<IMongoClient>((service) =>
        //{
        //    string? connectionString = configuration.GetConnectionString("CoffeeNoSQL");
        //    return new MongoClient(connectionString);
        //});

        #endregion

        services.AddBaseServices();

        services.AddBusinessServices();
        services.AddExtranalServices();

        return services;
    }

    static void AddBaseServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseCud<>), typeof(BaseCud<>));
        services.AddScoped(typeof(IBaseQuery<>), typeof(BaseQuery<>));

    }

    static void AddBusinessServices(this IServiceCollection services)
    {
        #region -- File --

        services.AddTransient<IFileGet, FileGet>();
        services.AddTransient<IFileAction, FileAction>();
        services.AddTransient<IFileViewModel, FileViewModelService>();

        #endregion

    }

    static void AddExtranalServices(this IServiceCollection services)
    {
        //services.AddFteamIdentityService();
        //services.AddFteamLiveConnectionService();
        //services.AddFteamNotificationService();
    }
}