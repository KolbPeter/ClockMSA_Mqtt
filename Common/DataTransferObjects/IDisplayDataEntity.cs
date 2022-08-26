namespace Common.DtoInterfaces;

/// <summary>
/// Interface for store led strip values to display.
/// </summary>
public interface IDisplayDataEntity
{
    /// <summary>
    /// Gets the pin number for the led strip.
    /// </summary>
    int DisplayPin { get; init; }

    /// <summary>
    /// Gets a collection of RGB led values as <see cref="byte"/> to display.
    /// </summary>
    IEnumerable<byte[]> Leds { get; init; }
}
