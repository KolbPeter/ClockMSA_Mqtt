using Common;
using Microsoft.Extensions.Hosting;
using MqttComm;
using Serilog;

namespace ClockMqtt
{
    public class Program
    {
        public static async Task Main(string[]? args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog(logger: ConfigureLogger.Create())
                .ConfigureServices(services =>
                    services
                        .WithClockServices()
                        .WithMqttServices(
                            logger: ConfigureLogger.Create<IMqttService>()))
                .Build();

            await host.RunAsync();
        }
    }
}