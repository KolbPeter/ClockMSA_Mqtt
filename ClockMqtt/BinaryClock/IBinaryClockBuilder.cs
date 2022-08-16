using ClockMqtt.Clocks;

namespace ClockMqtt.BinaryClock;

/// <summary>
/// Interface for binary clock builder.
/// </summary>
public interface IBinaryClockBuilder
{
    /// <summary>
    /// Creates a default binary <see cref="IClock"/>.
    /// </summary>
    /// <returns>Returns a <see cref="IClock"/>.</returns>
    IClock CreateBinaryClock();
}