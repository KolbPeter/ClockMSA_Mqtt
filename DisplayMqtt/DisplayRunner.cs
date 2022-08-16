using DisplayMqtt.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttComm;
using MqttComm.Serializers;

namespace DisplayMqtt;

/// <summary>
/// Default implementation of <see cref="BackgroundService"/>.
/// </summary>
public class DisplayRunner : BackgroundService
{
    private readonly ILogger<DisplayRunner> logger;
    private readonly IMqttService mqttService;
    private readonly IJsonConverterService jsonConverterService;

    /// <summary>
    /// Constructor for this implementation of <see cref="BackgroundService"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    public DisplayRunner(
        ILogger<DisplayRunner> logger,
        IMqttService mqttService,
        IJsonConverterService jsonConverterService)
    {
        this.logger = logger;
        this.mqttService = mqttService;
        this.jsonConverterService = jsonConverterService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        mqttService.Subscribe(topic: "Clock.DisplayData", onReceive: ReceivedDisplayData);
    }

    private void ReceivedDisplayData(string jsonMessage)
    {
        var conversionResult = jsonConverterService
            .Deserialize<DisplayDataEntities>(message: jsonMessage);
        
        if (conversionResult.IsSuccessfull)
        {
            logger.LogDebug($"Message received and deserialized: {jsonMessage}");
        }
        else
        {
            logger.LogError(conversionResult.ThrownException, conversionResult.ThrownException!.Message);
        }
    }
}
