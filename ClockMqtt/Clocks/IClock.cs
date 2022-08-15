using ClockMqtt.Leds;
using ClockMqtt.LedStrips;

namespace ClockMqtt.Clocks
{
    /// <summary>
    /// Interface for a clock that uses a led strip to display the time and/or date.
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Gets a collection of <see cref="ILedStrip"/> to display the time/date on.
        /// </summary>
        IEnumerable<ILedStrip> LedStrips { get; }

        /// <summary>
        /// Displays the given <paramref name="dateTime"/> on the led strips.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to display.</param>
        /// <returns>Returns a collection of <see cref="int"/> display pin and <see cref="ILed"/>, represents the led values to display in the given display pin.</returns>
        IEnumerable<(int DisplayPin, IEnumerable<ILed> Leds)> DisplayLedStrips(DateTime dateTime);
    }
}
