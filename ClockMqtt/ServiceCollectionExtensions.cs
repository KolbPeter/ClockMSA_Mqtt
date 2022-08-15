using ClockMqtt.BinaryClock;
using ClockMqtt.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace ClockMqtt
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithClockServices(this IServiceCollection services)
        {
            return services
                        .AddHostedService<BinaryClockRunner>()
                        .AddSingleton<ILedStripBuilder, LedStripBuilder>()
                        .AddSingleton<IPartialLedStripBuilder, PartialLedStripBuilder>()
                        .AddSingleton<IClockBuilder, ClockBuilder>()
                        .AddSingleton<IBinaryClockBuilder, BinaryClockBuilder>()
                        .AddSingleton<IBinaryClockService, BinaryClockService>()
                        .AddLogging();
        }
    }
}
