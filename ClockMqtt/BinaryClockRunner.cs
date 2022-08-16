using ClockMqtt.BinaryClock;
using ClockMqtt.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttComm;
using MqttComm.Serializers;

namespace ClockMqtt;

/// <summary>
/// Default implementation of <see cref="BackgroundService"/>.
/// </summary>
public class BinaryClockRunner : BackgroundService
{
    private readonly ILogger<BinaryClockRunner> logger;
    private readonly IBinaryClockService binaryClockService;
    private readonly IMqttService mqttService;
    private readonly IJsonConverterService jsonConverterService;

    /// <summary>
    /// Constructor for this implementation of <see cref="BackgroundService"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    /// <param name="binaryClockService">The <see cref="IBinaryClockService"/> implementation to use.</param>
    /// <param name="mqttService">The <see cref="IMqttService"/> implementation to use.</param>
    /// <param name="jsonConverterService">The <see cref="IJsonConverterService"/> implementation to use.</param>
    public BinaryClockRunner(
        ILogger<BinaryClockRunner> logger,
        IBinaryClockService binaryClockService,
        IMqttService mqttService,
        IJsonConverterService jsonConverterService)
    {
        this.logger = logger;
        this.binaryClockService = binaryClockService;
        this.mqttService = mqttService;
        this.jsonConverterService = jsonConverterService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        mqttService.Subscribe(topic: "Timer.Tick", onReceive: ReceivedTime);
    }

    private void ReceivedTime(string jsonMessage)
    {
        var conversionResult = jsonConverterService
            .Deserialize<DateTimeEntity>(message: jsonMessage);
        
        if (conversionResult.IsSuccessfull)
        {
            var dataConversion = jsonConverterService
                .Serialize(
                    toSerialize: binaryClockService
                        .CreateDisplayData(conversionResult.Data!.DateTime));

            if (dataConversion.IsSuccessfull)
            {
                mqttService.Publish(
                    topic: "Clock.DisplayData",
                    message: dataConversion.Data!);
            }
            else
            {
                logger.LogError(dataConversion.ThrownException, dataConversion.ThrownException!.Message);
            }
        }
        else
        {
            logger.LogError(conversionResult.ThrownException, conversionResult.ThrownException!.Message);
        }
    }
}
