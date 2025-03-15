using System.Net.NetworkInformation;
using Microsoft.Extensions.DependencyInjection;
using RadioPlayer.Services;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<Ping>();
            services.AddSingleton<IDnsService, DnsService>();
            services.AddScoped<IRadioService, RadioService>();
            services.AddScoped<IAudioPlayer, AudioPlayer>();
            services.AddSingleton<MainForm>();
        }
    }
}