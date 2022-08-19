using Common;
using Microsoft.Extensions.Hosting;
using MqttComm;
using Serilog;

namespace DisplayMqtt
{
    public class Program
    {
        private static readonly IEnumerable<string> LogPath = new[] { "DisplayLogs" };

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