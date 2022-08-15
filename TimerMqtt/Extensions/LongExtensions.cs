namespace TimerMqtt.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="long"/>.
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Extension method to convert a <see cref="long"/> that represents a unix seconds timestamp to <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="unixSeconds">The unix seconds timestamp to convert.</param>
        /// <returns>Returns a <see cref="DateTime"/> calculated from the given <paramref name="unixSeconds"/> timestamp value.</returns>
        public static DateTime UnixSecondsToDateTime(this long unixSeconds) =>
            DateTime.UnixEpoch.AddSeconds(unixSeconds);
    }
}