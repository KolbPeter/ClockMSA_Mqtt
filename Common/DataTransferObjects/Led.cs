namespace Common.DataTransferObjects
{
    /// <summary>
    /// Record to store RGB value for a single led.
    /// </summary>
    public record Led
    {
        /// <summary>
        /// Gets a <see cref="byte"/> that represents the red value of the RGB led.
        /// </summary>
        public byte Red { get; init; }

        /// <summary>
        /// Gets a <see cref="byte"/> that represents the red value of the RGB led.
        /// </summary>
        public byte Green { get; init; }

        /// <summary>
        /// Gets a <see cref="byte"/> that represents the red value of the RGB led.
        /// </summary>
        public byte Blue { get; init; }
    }
}
