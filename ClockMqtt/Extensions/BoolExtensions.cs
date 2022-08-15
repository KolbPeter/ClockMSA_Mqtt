using ClockMqtt.Leds;

namespace ClockMqtt.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="bool"/>.
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// Extension method to convert a collection of <see cref="bool"/> to a collection to <see cref="ILed"/> value.
        /// </summary>
        /// <param name="controlValues">The collection of <see cref="bool"/> to convert.</param>
        /// <param name="colorWhenSet">The <see cref="ILed"/> value to set where the <paramref name="controlValues"/> contains true.</param>
        /// <param name="colorWhenCleared">The <see cref="ILed"/> value to set where the <paramref name="controlValues"/> contains false.</param>
        /// <returns>Returns a collection of <see cref="ILed"/>.</returns>
        public static IEnumerable<ILed> ToColorValues(
            this IEnumerable<bool> controlValues,
            ILed colorWhenSet,
            ILed colorWhenCleared) =>
            controlValues.Select(x => x ? colorWhenSet : colorWhenCleared);
    }
}