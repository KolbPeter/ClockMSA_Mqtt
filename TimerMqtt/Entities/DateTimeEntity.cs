namespace TimerMqtt.Entities
{
    public record DateTimeEntity : IDateTimeEntity
    {
        public DateTime DateTime { get; init; }
        public long EpochTimeSeconds => ((DateTimeOffset)DateTime.SpecifyKind(DateTime, DateTimeKind.Local)).ToUnixTimeSeconds();
    }
}