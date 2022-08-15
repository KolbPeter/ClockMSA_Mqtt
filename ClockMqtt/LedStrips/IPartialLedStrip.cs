using ClockMqtt.Leds;

namespace ClockMqtt.LedStrips
{
    /// <summary>
    /// Interface for RGB led strips segment.
    /// </summary>
    public interface IPartialLedStrip
    {
        /// <summary>
        /// Calculates the led color values from the <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to use.</param>
        /// <returns>Returns a collection of <see cref="ILed"/> that represents the given <paramref name="dateTime"/>.</returns>
        IEnumerable<ILed> CalculateLedColors(DateTime dateTime);


        /// <summary>
        /// Calculates the led states from the <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to use.</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents the given <paramref name="dateTime"/>.</returns>
        IEnumerable<bool> CalculateLedStates(DateTime dateTime);


        /// <summary>
        /// Gets the number of led in this <see cref="ILedStrip"/>.
        /// </summary>
        int LedCount { get; }
    }
}
