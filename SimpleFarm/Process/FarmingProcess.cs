using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleFarm.Config;

namespace SimpleFarm.Process
{
    public class FarmingProcess : IFarmingProcess
    {
        private readonly FarmConfig config;
        private readonly ILogger<FarmingProcess> logger;

        public FarmingProcess(IOptions<FarmConfig> config, ILogger<FarmingProcess> logger)
        {
            this.config = config.Value;
            this.logger = logger;
        }

        public async Task TillTheLand()
        {
            logger.LogInformation($"Tilling {config.FertileLandInMetersSquared} m^2 for {config.Crop} crop!!!");
            await Task.Delay(TimeSpan.FromMinutes(config.TillTimeInMinutes));
        }

        public async Task PlantTheCrop()
        {
            logger.LogInformation($"Planting {config.FertileLandInMetersSquared} m^2 for {config.Crop} crop!!!");
            await Task.Delay(TimeSpan.FromMinutes(config.PlantTimeInMinutes));
        }

        public async Task HarvestTheCrop()
        {
            logger.LogInformation($"Harvesting {config.FertileLandInMetersSquared} m^2 for {config.Crop} crop!!!");
            await Task.Delay(TimeSpan.FromMinutes(config.HarvestTimeInMinutes));
        }
    }
}
