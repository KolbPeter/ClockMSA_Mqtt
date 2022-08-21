namespace Common.DataTransferObjects;

/// <summary>
/// Default implementation of <see cref="IDisplayDataEntity"/>.
/// </summary>
public record DisplayDataEntity
{
    /// <summary>
    /// Gets the pin number for the led strip.
    /// </summary>
    public int DisplayPin { get; init; }

    /// <summary>
    /// Gets a collection of <see cref="Led"/> to display.
    /// </summary>
    public IEnumerable<Led> Leds { get; init; }
}
