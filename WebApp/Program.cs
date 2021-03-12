using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                        {
                    //overiding Microsoft.Extensions.Hosting.Internal.ConsoleLifetime
                    //services.AddSingleton<IHostLifetime, ExampleHostLifetime>();
                    services.AddHostedService<ApplicationServices.HostedService>();
                    services.AddHostedService<ApplicationServices.BackgroundService>();
                });
    }
}
