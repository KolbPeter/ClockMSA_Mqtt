using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttComm;
using MqttComm.Serializers;
using TimerMqtt.Entities;
using TimerMqtt.Timers;

namespace TimerMqtt;

/// <summary>
/// Default implementation of <see cref="BackgroundService"/>.
/// </summary>
public class TimerRunner : BackgroundService
{
    private readonly ILogger<TimerRunner> logger;
    private readonly IMqttService mqttService;
    private readonly IJsonConverterService jsonConverterService;
    private readonly IClockTimer clockTimer;

    /// <summary>
    /// Constructor for this implementation of <see cref="BackgroundService"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    /// <param name="mqttService">The <see cref="IMqttService"/> implementation to use.</param>
    /// <param name="jsonConverterService">The <see cref="IJsonConverterService"/> implementation to use.</param>
    public TimerRunner(
        ILogger<TimerRunner> logger,
        IMqttService mqttService,
        IJsonConverterService jsonConverterService)
    {
        this.logger = logger;
        this.mqttService = mqttService;
        this.jsonConverterService = jsonConverterService;
        clockTimer = CreateClockTimer();
        clockTimer.Start();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        mqttService.Subscribe("Timer.Stop", (s) => StopTimer());
        mqttService.Subscribe("Timer.Start", (s) => StartTimer());
    }

    private void StopTimer()
    {
        clockTimer.Stop();
        logger.LogDebug($"Timer stopped!");
    }

    private void StartTimer()
    {
        clockTimer.Start();
        logger.LogDebug($"Timer started!");
    }

    private void ActionToTrigger()
    {
        var dte = new DateTimeEntity() with { DateTime = DateTime.Now };
        var conversionResult = jsonConverterService.Serialize(dte);
        if (conversionResult.IsSuccessful)
        {
            mqttService.Publish("Timer.Tick", conversionResult.Data!);
            return;
        }
        else
        {
            logger.LogError(conversionResult.ThrownException, conversionResult.ThrownException?.Message);
        }
    }

    private IClockTimer CreateClockTimer()
    {
        return new ClockTimer(
            tickInterval: TimeSpan.FromSeconds(1),
            triggeredAction: ActionToTrigger);
            
    }
}
