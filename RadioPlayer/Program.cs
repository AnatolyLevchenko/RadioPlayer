using System.Net.NetworkInformation;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using RadioPlayer.Services;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer;

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
        services.AddHttpClient<IRadioService, RadioService>()
            .AddPolicyHandler(GetHttpRetryPolicy());

        services.AddSingleton(GetRetryPolicy());

        services.AddTransient<Ping>();
        services.AddSingleton<IDnsService, DnsService>();
        services.AddScoped<IAudioPlayer, AudioPlayer>();
        services.AddSingleton<MainForm>();
    }

    static IAsyncPolicy<HttpResponseMessage> GetHttpRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public static AsyncRetryPolicy GetRetryPolicy()
    {
        return Policy
            .Handle<Exception>()
            .RetryAsync(3, (exception, retryCount) =>
            {
                //Console.WriteLine($"Retry {retryCount} due to: {exception.Message}");
            });
    }
}