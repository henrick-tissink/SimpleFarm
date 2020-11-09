using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using SimpleFarm.Config;
using SimpleFarm.Process;
using SimpleFarm.Worker;

namespace SimpleFarm
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddEventLog();
                })
                // Essential to run this as a window service
                .UseWindowsService()
                .ConfigureServices(configureServices);

        private static void configureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.Configure<FarmConfig>(context.Configuration.GetSection("Farm"));
            services.AddLogging();
            services.AddSingleton<IFarmingProcess, FarmingProcess>();
            services.AddHostedService<FarmWorker>();
        }
    }
}
