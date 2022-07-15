// See https://aka.ms/new-console-template for more information
using ConsoleQuickStart;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

static class Program
{
    public static IConfigurationRoot Configuration { get; private set; }

    static async Task Main(string[] args)
    {
        using IHost host = Startup.CreateHostBuilder(args).Build();
        await host.RunAsync();
    }
}