using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace StoryTimer
{
    static class Program
    {
        static IServiceCollection _services;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IHostEnvironment env;
            var hostBuilder = CreateHostBuilder();
            hostBuilder.ConfigureAppConfiguration((hostContext, config) =>
            {
                env = hostContext.HostingEnvironment;
            });
            
            Application.Run(new MainForm());
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureHostConfiguration((config) =>
            {
                // override the default config providers
                config.Sources.Clear();
                config.AddJsonFile(SettingsManager.AppSettingsFileName, optional:false, reloadOnChange: true);
                IConfigurationRoot configRoot = config.Build();
               
                // Bind options
                var appOptions = new AppOptions();
                configRoot.GetSection(nameof(AppOptions)).Bind(appOptions);
                
            })
            .ConfigureServices((hostContext, services) =>
            {
                //services.AddHostedService<Worker>();
                services.Configure<AppOptions>(
                    )
            })
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                
            })
            
            ;
    }
}
