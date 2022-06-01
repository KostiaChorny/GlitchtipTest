using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SentryTest
{
    public class Service : BackgroundService
    {
        private readonly ILogger<Service> logger;

        public Service(ILogger<Service> logger, IOptions<MySettings> options)
        {
            this.logger = logger;
            var set = options.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
