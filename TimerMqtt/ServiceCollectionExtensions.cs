using Microsoft.Extensions.DependencyInjection;
using TimerMqtt.Timers;

namespace TimerMqtt
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
        public static IServiceCollection WithTimerServices(this IServiceCollection services)
        {
            return services
                        .AddHostedService<TimerRunner>()
                        .AddSingleton<IClockTimer, ClockTimer>()
                        .AddLogging();
        }
    }
}
