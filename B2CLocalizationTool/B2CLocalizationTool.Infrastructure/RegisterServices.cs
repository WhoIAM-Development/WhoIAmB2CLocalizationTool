using B2CLocalizationTool.Service;
using B2CLocalizationTool.Service.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace B2CLocalizationTool.Infrastructure
{
    public static class RegisterServices
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IExternalDataService, ExternalDataService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
        }
    }
}
