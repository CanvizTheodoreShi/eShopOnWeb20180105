using Microsoft.Extensions.Configuration;

namespace Microsoft.eShopWeb.Services
{
    public class AppsettingsService: IAppsettingsService
    {
        public static IConfiguration Configuration { get; set; }

        public AppsettingsService()
        {
            Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        }

        public string getValue(string Key)
        {
            return Configuration[Key];
        }
    }
}
