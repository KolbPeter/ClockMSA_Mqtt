namespace DisplayMqtt.Entities;

/// <summary>
/// Default implementation of <see cref="IDisplayDataEntity"/>.
/// </summary>
public record DisplayDataEntity : IDisplayDataEntity
{
    /// <inheritdoc/>
    public int DisplayPin { get; init; }

    /// <inheritdoc/>
    public IEnumerable<ILed> Leds { get; init; }

    /// <summary>
    /// Instantiate a <see cref="DisplayDataEntity"/>.
    /// </summary>
    /// <param name="displayPin">The display pin to use to display teh led values.</param>
    /// <param name="leds">The led values to display.</param>
    public DisplayDataEntity(int displayPin, IEnumerable<Led> leds)
    {
        Leds = leds;
        DisplayPin = displayPin;
    }
}
