using CD.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CD.Core.Configuration
{
    public class AppSettings : IAppSettings
    {
        private IConfiguration configuration;
        private IConfigurationSection appSettings;

        public AppSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.appSettings = configuration.GetSection("AppSettings");
        }
    }
}
