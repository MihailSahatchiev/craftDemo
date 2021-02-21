using CD.Core.Configuration;
using CD.Core.Interfaces;
using CD.SqlLiteAdapter;
using CD.StatAdapter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CD.Services.Configuration
{
    public static class DependancyConfiguration
    {

        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            SetConfigurations(services, configuration);
            SetDataAdapters(services);
        }

        private static void SetConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(conf => configuration);
            services.AddSingleton<IAppSettings, AppSettings>();
        }

        private static void SetDataAdapters(IServiceCollection services)
        {
            services.AddScoped<IDbManager, DbManager>();
            services.AddScoped<IStatService, StatService>();
        }
    }
}
