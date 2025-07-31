using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MDAC
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IOptions<AppConfiguration> appConfiguration;
        private readonly Scraper scraper;

        public Worker(ILogger<Worker> logger, IOptions<AppConfiguration> appConfiguration, Scraper scraper)
        {
            this.logger = logger;
            this.appConfiguration = appConfiguration;
            this.scraper = scraper;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                if (DateTime.Now == default)
                {
                    scraper.Scrape();
                }

                Thread.Sleep(2000);
                logger.LogInformation("Count: {I}", i++);
            }

            return Task.CompletedTask;
        }
    }
}
