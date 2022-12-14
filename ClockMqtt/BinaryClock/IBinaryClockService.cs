using ClockMqtt.Dtos;

namespace ClockMqtt.BinaryClock;

/// <summary>
/// Interface for binary clock service.
/// </summary>
public interface IBinaryClockService
{
    /// <summary>
    /// Create data to display on a binary clock display from the given <paramref name="dateTime"/>.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> to display.</param>
    /// <returns>Returns a collection of <see cref="DisplayDataEntity"/> to display.</returns>
    IEnumerable<DisplayDataEntity> CreateDisplayData(DateTime dateTime);
}