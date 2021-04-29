using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Polly.Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var profileService = serviceProvider.GetRequiredService<ProfileService>();
            await profileService.GetProfileAsync("johnw86");
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            // Configure a client named as "GitHub", with various default properties.
            services.AddHttpClient("GitHub", client =>
                {
                    client.BaseAddress = new Uri("https://api.github.com/");
                    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                    client.DefaultRequestHeaders.Add("User-Agent", "request");
                })
                // Add a backoff retry policy that attempts 30 times
                .AddTransientHttpErrorPolicy(builder => 
                    builder.WaitAndRetryAsync(30, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

            services.AddTransient<ProfileService>();
        }
    }
}
