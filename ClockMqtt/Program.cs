using Common;
using Microsoft.Extensions.Hosting;
using MqttComm;
using Serilog;

namespace ClockMqtt
{
    public class Program
    {
        private static readonly IEnumerable<string> LogPath = new[] { "ClockLogs" };

        public static async Task Main(string[]? args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog(logger: ConfigureLogger.Create(LogPath))
                .ConfigureServices(services =>
                    services
                        .WithClockServices()
                        .WithMqttServices(
                            logger: ConfigureLogger.Create<IMqttService>(LogPath)))
                .Build();

            await host.RunAsync();
        }
    }
}