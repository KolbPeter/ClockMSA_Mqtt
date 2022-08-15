using ClockMqtt.Clocks;
using ClockMqtt.LedStrips;

namespace ClockMqtt.Builders
{
    /// <summary>
    /// Interface for building a <see cref="IClock"/>.
    /// </summary>
    public interface IClockBuilder : IBuilder<IClockBuilder, IClock>
    {
        /// <summary>
        /// Adds the given <see cref="ILedStrip"/> to the collection.
        /// </summary>
        /// <param name="newLedStrip"></param>
        /// <returns>Returns a <see cref="IClockBuilder"/> with the updated value.</returns>
        /// <exception cref="ArgumentException">Throws when led strip already exist on the same display pin.</exception>
        IClockBuilder WithLedStrip(ILedStrip newLedStrip);
    }
}