namespace ClockMqtt.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Reference value to display years since this year only.
        /// </summary>
        private const int ReferenceYear = 2000;

        /// <summary>
        /// Extension method to calculate led states from seconds. 
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to calculate values from.</param>
        /// <param name="ledCount">The number of leds</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents seconds of the given <paramref name="dateTime"/>.</returns>
        public static IEnumerable<bool> SecondsToBinaryValues(
            this DateTime dateTime,
            int ledCount) =>
            dateTime.Second.ToBinaryValues(ledCount: ledCount);

        /// <summary>
        /// Extension method to calculate led states from minutes. 
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to calculate values from.</param>
        /// <param name="ledCount">The number of leds</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents minutes of the given <paramref name="dateTime"/>.</returns>
        public static IEnumerable<bool> MinutesToBinaryValues(
            this DateTime dateTime,
            int ledCount) =>
            dateTime.Minute.ToBinaryValues(ledCount: ledCount);

        /// <summary>
        /// Extension method to calculate led states from hours. 
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to calculate values from.</param>
        /// <param name="ledCount">The number of leds</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents hours of the given <paramref name="dateTime"/>.</returns>
        public static IEnumerable<bool> HoursToBinaryValues(
            this DateTime dateTime,
            int ledCount) =>
            dateTime.Hour.ToBinaryValues(ledCount: ledCount);

        /// <summary>
        /// Extension method to calculate led states from days. 
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to calculate values from.</param>
        /// <param name="ledCount">The number of leds</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents days of the given <paramref name="dateTime"/>.</returns>
        public static IEnumerable<bool> DaysToBinaryValues(
            this DateTime dateTime,
            int ledCount) =>
            dateTime.Day.ToBinaryValues(ledCount: ledCount);

        /// <summary>
        /// Extension method to calculate led states from months. 
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to calculate values from.</param>
        /// <param name="ledCount">The number of leds</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents months of the given <paramref name="dateTime"/>.</returns>
        public static IEnumerable<bool> MonthsToBinaryValues(
            this DateTime dateTime,
            int ledCount) =>
            dateTime.Month.ToBinaryValues(ledCount: ledCount);

        /// <summary>
        /// Extension method to calculate led states from years.
        /// Only the years since the <see cref="ReferenceYear"/> will be calculated.  
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to calculate values from.</param>
        /// <param name="ledCount">The number of leds.</param>
        /// <returns>Returns a collection of <see cref="bool"/> that represents years of the given <paramref name="dateTime"/>.</returns>
        public static IEnumerable<bool> YearsToBinaryValues(
            this DateTime dateTime,
            int ledCount) =>
            (dateTime.Year - ReferenceYear).ToBinaryValues(ledCount: ledCount);
    }
}