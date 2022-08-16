namespace ClockMqtt.Entities;

/// <summary>
/// Record to store date time values.
/// </summary>
public record DateTimeEntity
{
    /// <summary>
    /// Gets a <see cref="DateTime"/> value.
    /// </summary>
    public DateTime DateTime { get; init; }
 
    /// <summary>
    /// Gets the seconds between epoch time and the property <see cref="DateTime"/>.
    /// </summary>
    public long EpochTimeSeconds => ((DateTimeOffset)DateTime.SpecifyKind(DateTime, DateTimeKind.Local)).ToUnixTimeSeconds();
}
