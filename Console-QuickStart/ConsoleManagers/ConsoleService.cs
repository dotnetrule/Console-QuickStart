using Microsoft.Extensions.Hosting;

namespace ConsoleQuickStart.ConsoleManagers
{
    public class ConsoleService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IConsoleManager ConsoleManager;

        public ConsoleService(IHostApplicationLifetime appLifetime, IConsoleManager consoleManager)
        {
            _appLifetime = appLifetime;
            ConsoleManager = consoleManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        ConsoleManager.WriteLine("hello...");
                    }
                    catch (Exception ex)
                    {
                        ConsoleManager.WriteLine(ex.ToString());
                    }
                    finally
                    {

                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}