using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleFarm.Process;

namespace SimpleFarm.Worker
{
    public class FarmWorker : BackgroundService
    {
        private readonly IFarmingProcess farmingProcess;
        private readonly ILogger<FarmWorker> logger;

        public FarmWorker(IFarmingProcess farmingProcess, ILogger<FarmWorker> logger)
        {
            this.farmingProcess = farmingProcess;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // This is how we keep the app running (in the background)
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("FarmWorker running at: {time}", DateTimeOffset.Now);

                await farmingProcess.TillTheLand();
                await farmingProcess.PlantTheCrop();
                await farmingProcess.HarvestTheCrop();
            }
        }
    }
}
