using ClockMqtt.LedStrips;

namespace ClockMqtt.Builders
{
    /// <summary>
    /// Interface for building a <see cref="ILedStrip"/>.
    /// </summary>
    public interface ILedStripBuilder : IBuilder<ILedStripBuilder, ILedStrip>
    {
        /// <summary>
        /// Sets the given <paramref name="newDisplayPin"/> as a display pin.
        /// </summary>
        /// <param name="newDisplayPin">The value of the display pin to set.</param>
        /// <returns>Returns a <see cref="ILedStripBuilder"/> with the updated value.</returns>
        ILedStripBuilder WithDisplayPin(int newDisplayPin);

        /// <summary>
        /// Adds the given <see cref="IPartialLedStrip"/> to the collection.
        /// </summary>
        /// <param name="newPartialLedStrip">The <see cref="IPartialLedStrip"/> to add.</param>
        /// <returns>Returns a <see cref="ILedStripBuilder"/> with the updated value.</returns>
        ILedStripBuilder WithPartialLedStrip(IPartialLedStrip newPartialLedStrip);
    }
}