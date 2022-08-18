using DisplayMqtt.DisplayServices;
using Microsoft.Extensions.DependencyInjection;

namespace DisplayMqtt
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithClockServices(this IServiceCollection services)
        {
            return services
                        .AddHostedService<DisplayRunner>()
                        .AddSingleton<IDisplayService, Ws2812bDisplay>()
                        .AddLogging();
        }
    }
}
