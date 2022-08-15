namespace ClockMqtt.Leds
{
    /// <summary>
    /// Interface for a single led color values.
    /// </summary>
    public interface ILed
    {
        /// <summary>
        /// Gets a <see cref="byte"/> that represents the red value of the RGB led.
        /// </summary>
        byte Red { get; }

        /// <summary>
        /// Gets a <see cref="byte"/> that represents the green value of the RGB led.
        /// </summary>
        byte Green { get; }

        /// <summary>
        /// Gets a <see cref="byte"/> that represents the blue value of the RGB led.
        /// </summary>
        byte Blue { get; }

        /// <summary>
        /// Gets the color hex value string for this led.
        /// </summary>
        string ColorString { get; }
    }
}
