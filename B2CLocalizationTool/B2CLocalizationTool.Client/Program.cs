using B2CLocalizationTool.Infrastructure;
using B2CLocalizationTool.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace B2CLocalizationTool.Client
{
    static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // This is needed for reading from excel without errors in .net core.
            // https://github.com/ExcelDataReader/ExcelDataReader
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            RegisterServices.ConfigureServices(services);
            services.AddScoped<BaseForm>();

            var toJsonOptions = Configuration.GetSection("ToJson");
            services.Configure<ToJsonSettings>(toJsonOptions);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var baseForm = serviceProvider.GetRequiredService<BaseForm>();
                Application.Run(baseForm);
            }
        }
    }
}
