namespace TimerMqtt.Entities
{
    public interface IDateTimeEntity
    {
        DateTime DateTime { get; init; }
        long EpochTimeSeconds { get; }
    }
}