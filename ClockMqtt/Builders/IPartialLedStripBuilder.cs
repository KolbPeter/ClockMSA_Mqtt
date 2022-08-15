using ClockMqtt.Leds;
using ClockMqtt.LedStrips;

namespace ClockMqtt.Builders
{
    /// <summary>
    /// Interface for building a <see cref="IPartialLedStrip"/>.
    /// </summary>
    public interface IPartialLedStripBuilder : IBuilder<IPartialLedStripBuilder, IPartialLedStrip>
    {
        /// <summary>
        /// Sets the given <paramref name="calculatorFunction"/>.
        /// </summary>
        /// <param name="calculatorFunction">The calculator function to set.</param>
        /// <returns>Returns a <see cref="IPartialLedStripBuilder"/> with the updated value.</returns>
        IPartialLedStripBuilder WithCalculatorFunction(Func<DateTime, int, IEnumerable<bool>> calculatorFunction);

        /// <summary>
        /// Sets the given <see cref="ILed"/> as the color when a led is cleared.
        /// </summary>
        /// <param name="newColorWhenCleared">An <see cref="ILed"/> to set.</param>
        /// <returns>Returns a <see cref="IPartialLedStripBuilder"/> with the updated value.</returns>
        IPartialLedStripBuilder WithColorWhenCleared(ILed newColorWhenCleared);


        /// <summary>
        /// Sets the given <see cref="ILed"/> as the color when a led is set.
        /// </summary>
        /// <param name="newColorWhenSet">An <see cref="ILed"/> to set.</param>
        /// <returns>Returns a <see cref="IPartialLedStripBuilder"/> with the updated value.</returns>
        IPartialLedStripBuilder WithColorWhenSet(ILed newColorWhenSet);

        /// <summary>
        /// Sets the led count for this <see cref="IPartialLedStrip"/>.
        /// </summary>
        /// <param name="newLedCount">The value to set as led count.</param>
        /// <returns>Returns a <see cref="IPartialLedStripBuilder"/> with the updated value.</returns>
        IPartialLedStripBuilder WithLedCount(int newLedCount);
    }
}