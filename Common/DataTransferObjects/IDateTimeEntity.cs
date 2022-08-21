namespace Common.DtoInterfaces
{
    /// <summary>
    /// Interface for store date time values.
    /// </summary>
    public interface IDateTimeEntity
    {
        /// <summary>
        /// Gets a <see cref="DateTime"/> value.
        /// </summary>
        DateTime DateTime { get; init; }

        /// <summary>
        /// Gets the seconds between epoch time and the property <see cref="DateTime"/>.
        /// </summary>
        long EpochTimeSeconds { get; }
    }
}