using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MqttComm.Serializers;

namespace MqttComm
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithMqttServices(
            this IServiceCollection services,
            ILogger<IMqttService> logger)
        {
            var mqttSettings = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build()
                .GetRequiredSection("MqttSettings")
                .Get<MqttSettings>();

            return services
                .AddSingleton<IMqttService>(x =>
                    new MqttService(
                        logger: logger,
                        brokerAddress: mqttSettings.BrokerAddress,
                        userName: mqttSettings.UserName,
                        password: mqttSettings.Password))
                .AddSingleton<IJsonConverterService, JsonConverterService>();
        }
    }
}
