using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MqttComm.Serializers;

namespace MqttComm
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithMqttServices(
            this IServiceCollection services,
            ILogger<IMqttService> logger,
            string brokerAddress,
            string userName,
            string password)
        {
            return services
                .AddSingleton<IMqttService>(x =>
                    new MqttService(
                        logger: logger,
                        brokerAddress: brokerAddress,
                        userName: userName,
                        password: password))
                .AddSingleton<IJsonConverterService, JsonConverterService>();
        }
    }
}
