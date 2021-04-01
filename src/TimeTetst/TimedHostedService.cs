using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimeTetst
{
    public class TimedHostedService : IHostedService
    {
        private readonly ILogger<TimedHostedService> _logger;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");
            return Task.CompletedTask;
        }
    }
}
