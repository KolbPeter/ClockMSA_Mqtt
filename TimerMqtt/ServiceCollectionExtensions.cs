using Microsoft.Extensions.DependencyInjection;
using TimerMqtt.Timers;

namespace TimerMqtt
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithTimerServices(this IServiceCollection services)
        {
            return services
                        .AddHostedService<TimerRunner>()
                        .AddSingleton<IClockTimer, ClockTimer>()
                        .AddLogging();
        }
    }
}
