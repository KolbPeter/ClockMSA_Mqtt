using Microsoft.Extensions.DependencyInjection;

namespace DisplayMqtt
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithClockServices(this IServiceCollection services)
        {
            return services
                        .AddHostedService<DisplayRunner>()
                        .AddLogging();
        }
    }
}
