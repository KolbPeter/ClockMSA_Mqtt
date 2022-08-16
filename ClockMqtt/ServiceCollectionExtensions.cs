using ClockMqtt.BinaryClock;
using ClockMqtt.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace ClockMqtt
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method to add needed services for the given <paramref name="services"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to use.</param>
        /// <returns>Returns an <see cref="IServiceCollection"/> with the added services.</returns>
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
