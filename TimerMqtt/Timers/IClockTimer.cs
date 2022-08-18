namespace TimerMqtt.Timers;

/// <summary>
/// Interface for clock timers.
/// </summary>
public interface IClockTimer
{
    /// <summary>
    /// Gets the number of seconds between the clockTimer triggers the response action.
    /// </summary>
    double TickInterval { get; }

    /// <summary>
    /// Starts the clockTimer.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops the clockTimer.
    /// </summary>
    void Stop();

    /// <summary>
    /// Gets a value indicating that clockTimer is enabled or not.
    /// </summary>
    bool IsEnabled { get; }
}