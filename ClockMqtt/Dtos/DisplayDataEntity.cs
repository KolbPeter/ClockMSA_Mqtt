using Common.DtoInterfaces;

namespace ClockMqtt.Dtos;

/// <summary>
/// Record to store led strip values to display.
/// </summary>
public record DisplayDataEntity : IDisplayDataEntity
{
    /// <inheritdoc/>
    public int DisplayPin { get; init; }

    /// <inheritdoc/>
    public IEnumerable<byte[]> Leds { get; init; }
}
