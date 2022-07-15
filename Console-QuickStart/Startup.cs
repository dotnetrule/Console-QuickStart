using ConsoleQuickStart.Configuration;
using ConsoleQuickStart.ConsoleManagers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuickStart
{
    public static class Startup
    {
        private static readonly IHostApplicationLifetime _appLifetime;
        public static Settings Settings { get; private set; }
        public static IConfigurationRoot Configuration { get; private set; }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();
                configuration
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configurationRoot = configuration.Build();
                Configuration = configurationRoot;
            }).ConfigureServices((services) =>
            {
                services.AddSingleton<IConsoleManager,ConsoleManager>();
                services.AddHostedService<ConsoleService>();
            });


    }
}
