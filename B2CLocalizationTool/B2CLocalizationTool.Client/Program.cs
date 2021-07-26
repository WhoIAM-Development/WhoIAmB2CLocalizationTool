using B2CLocalizationTool.Service;
using B2CLocalizationTool.Service.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace B2CLocalizationTool.Client
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var baseForm = serviceProvider.GetRequiredService<BaseForm>();
                Application.Run(baseForm);
            }
        }


        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IExternalDataService, ExternalDataService>();
            services.AddScoped<BaseForm>();
        }
    }
}
