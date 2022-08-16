using ClockMqtt.Leds;

namespace ClockMqtt.Entities;

/// <summary>
/// Record to store display data values.
/// </summary>
public record DisplayDataEntity
{
    /// <summary>
    /// Gets the display pin to use to display teh led values.
    /// </summary>
    public int DisplayPin { get; init; }

    /// <summary>
    /// Gets the led values to display.
    /// </summary>
    public IEnumerable<ILed> Leds { get; init; }

    /// <summary>
    /// Instantiate a <see cref="DisplayDataEntity"/>.
    /// </summary>
    /// <param name="displayPin">The display pin to use to display teh led values.</param>
    /// <param name="leds">The led values to display.</param>
    public DisplayDataEntity(int displayPin, IEnumerable<ILed> leds)
    {
        Leds = leds;
        DisplayPin = displayPin;
    }
}
