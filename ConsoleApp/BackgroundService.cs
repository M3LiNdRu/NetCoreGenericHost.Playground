using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class BackgroundService : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly Guid _id;

        private readonly ILogger<BackgroundService> _logger;

        public BackgroundService(ILogger<BackgroundService> logger)
        {
            _id = Guid.NewGuid();
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Executing background task in background service id {id}", _id);
            return Task.Delay(10000);
        }
    }
}
