using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Windows.Forms;

namespace StoryTimer
{
    static class Program
    {
        public static IServiceProvider Services;
        public static IConfiguration Configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = CreateHostBuilder().Build();
            Services = host.Services;

            var o =  Services.GetService<IOptionsMonitor<AppOptions>>();
            System.Diagnostics.Debug.WriteLine($"Version: { o.CurrentValue.Version}");

            var main = Services.GetService<MainForm>();

            Application.Run(main);
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureHostConfiguration((config) =>
            {
            })
            .ConfigureAppConfiguration((hostBuilderContext, config) =>
            {
                // override the default config providers
                config.Sources.Clear();
                config.AddJsonFile(SettingsManager.AppSettingsFileName, optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                Configuration = context.Configuration;
                services.Configure<AppOptions>(Configuration.GetSection(nameof(AppOptions)));
                services.AddSingleton<IHostEnvironment>(context.HostingEnvironment);
                services.AddSingleton<MainForm>();
                services.AddTransient<SettingsUI>();
            })
            ;
    }
}
