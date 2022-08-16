namespace ClockMqtt.Entities
{
    /// <summary>
    /// Record to store a collection of <see cref="DisplayDataEntities"/> 
    /// </summary>
    public record DisplayDataEntities
    {
        /// <summary>
        /// Gets a collection of <see cref="DisplayDataEntity"/>.
        /// </summary>
        public IEnumerable<DisplayDataEntity> LedStrips { get; init; }
    }
}
