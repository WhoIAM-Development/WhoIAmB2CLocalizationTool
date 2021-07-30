using B2CLocalizationTool.Service;
using B2CLocalizationTool.Service.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace B2CLocalizationTool.Infrastructure
{
    public static class RegisterServices
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IExternalDataService, ExternalDataService>();
            services.AddScoped<ILocalizationService, LocalizationService>();

            services.AddLogging(configure => configure.AddConsole());
        }
    }
}
