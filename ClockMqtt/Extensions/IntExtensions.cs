namespace ClockMqtt.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="int"/>.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Extension method to create a collection of led control value from the given <paramref name="number"/> to a binary clock.
        /// </summary>
        /// <param name="number">The <see cref="int"/> value to convert to binary led control value.</param>
        /// <param name="ledCount">The number of leds for control values.</param>
        /// <returns>Returns a collection of <see cref="bool"/> to control the leds.</returns>
        public static IEnumerable<bool> ToBinaryValues(
          this int number,
          int ledCount)
        {
            for (var i = 0; i < ledCount; i++)
            {
                yield return number % 2 == 1;
                number /= 2;
            }
        }
    }
}