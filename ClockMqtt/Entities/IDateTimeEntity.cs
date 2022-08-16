namespace ClockMqtt.Entities
{
    public interface IDateTimeEntity
    {
        DateTime DateTime { get; init; }
        long EpochTimeSeconds { get; }
    }
}