using Common;
using Microsoft.Extensions.Hosting;
using MqttComm;
using Serilog;

namespace TimerMqtt
{
    public class Program
    {
        private static readonly IEnumerable<string> LogPath = new[] { "TimerLogs" };

        public static async Task Main(string[]? args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog(logger: ConfigureLogger.Create(LogPath))
                .ConfigureServices(services =>
                    services
                        .WithTimerServices()
                        .WithMqttServices(
                            logger: ConfigureLogger.Create<IMqttService>(LogPath)))
                .Build();

            await host.RunAsync();
        }
    }
}