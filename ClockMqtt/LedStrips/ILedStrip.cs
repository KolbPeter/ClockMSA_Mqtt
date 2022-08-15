namespace ClockMqtt.LedStrips
{
    /// <summary>
    /// Interface for RGB led strips.
    /// </summary>
    public interface ILedStrip : IPartialLedStrip
    {
        /// <summary>
        /// Gets a collection of <see cref="IPartialLedStrip"/>.
        /// </summary>
        IEnumerable<IPartialLedStrip> PartialLedStrips { get; }

        /// <summary>
        /// Gets the number of pin that led strip is connected to.
        /// </summary>
        int DisplayPin { get; }
    }
}
