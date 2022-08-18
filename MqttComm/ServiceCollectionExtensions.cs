using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MqttComm.Serializers;

namespace MqttComm
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method to add MQTT communication services for the given <paramref name="services"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to use.</param>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        /// <returns>Returns an <see cref="IServiceCollection"/> with the added services.</returns>
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
