using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microsoft.eShopWeb.Services
{
    public class AppSettingsService : IAppsettingsService
    {
        public static IConfiguration Configuration { get; set; }

        public AppSettingsService(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();
        }

        public string getValue(string Key)
        {
            return Configuration[Key];
        }
    }
}
