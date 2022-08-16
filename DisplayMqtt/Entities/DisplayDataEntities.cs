namespace DisplayMqtt.Entities
{
    public record DisplayDataEntities
    {
        public IEnumerable<DisplayDataEntity> LedStrips { get; init; }
    }
}
