using ClockMqtt.BinaryClock;
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
        mqttService.Subscribe("bakfitty", (s) => logger.LogDebug(s));

        while (true)
        {
            logger.LogDebug(DateTime.Now.ToString("yyyy/MM/dd dddd --- hh:mm:ss"));
            await Task.Delay(5000);
            await mqttService.Publish("bakfitty", "Hello");
        }
    }
}
