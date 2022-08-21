using Common.DtoInterfaces;

namespace TimerMqtt.Dtos
{
    /// <summary>
    /// Record to store date time values.
    /// </summary>
    public record DateTimeEntity : IDateTimeEntity
    {
        /// <inheritdoc/>
        public DateTime DateTime { get; init; }

        /// <inheritdoc/>
        public long EpochTimeSeconds => ((DateTimeOffset)DateTime.SpecifyKind(DateTime, DateTimeKind.Local)).ToUnixTimeSeconds();
    }
}