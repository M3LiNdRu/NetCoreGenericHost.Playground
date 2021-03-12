using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //overiding Microsoft.Extensions.Hosting.Internal.ConsoleLifetime
                    services.AddSingleton<IHostLifetime, ExampleHostLifetime>();

                    services.AddHostedService<HostedService>();
                });
    }
}
