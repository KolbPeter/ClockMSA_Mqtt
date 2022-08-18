using DisplayMqtt.DisplayServices;
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
    private readonly IDisplayService displayService;

    /// <summary>
    /// Constructor for this implementation of <see cref="BackgroundService"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    /// <param name="mqttService">The <see cref="IMqttService"/> implementation to use.</param>
    /// <param name="jsonConverterService">The <see cref="IJsonConverterService"/> implementation to use.</param>
    /// <param name="displayService">The <see cref="IDisplayService"/> implementation to use.</param>
    public DisplayRunner(
        ILogger<DisplayRunner> logger,
        IMqttService mqttService,
        IJsonConverterService jsonConverterService,
        IDisplayService displayService)
    {
        this.logger = logger;
        this.mqttService = mqttService;
        this.jsonConverterService = jsonConverterService;
        this.displayService = displayService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        mqttService.Subscribe(topic: "Clock.DisplayData", onReceive: ReceivedDisplayData);
    }

    private void ReceivedDisplayData(string jsonMessage)
    {
        try
        {
            var conversionResult = jsonConverterService
                .Deserialize<DisplayDataEntities>(message: jsonMessage);

            if (conversionResult.IsSuccessfull)
            {
                displayService.Display(conversionResult.Data!);
            }
            else
            {
                logger.LogError(conversionResult.ThrownException, conversionResult.ThrownException!.Message);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
    }
}
