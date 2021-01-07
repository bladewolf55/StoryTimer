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

            var main = host.Services.GetService<MainForm>();
            Application.Run(main);
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureHostConfiguration((config) =>
            {
            })
            .ConfigureServices((context, services) =>
            {
                IConfiguration configuration = context.Configuration;
                services.AddOptions<AppOptions>()
                    .Bind(configuration.GetSection(nameof(AppOptions)));
                services.AddSingleton(context.HostingEnvironment);
                services.AddSingleton<MainForm>();
            })
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                // override the default config providers
                config.Sources.Clear();
                config.AddJsonFile(SettingsManager.AppSettingsFileName, optional: false, reloadOnChange: true);
            })
            ;
    }
}
