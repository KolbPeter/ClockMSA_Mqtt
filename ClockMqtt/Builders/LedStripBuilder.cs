using ClockMqtt.LedStrips;
using Microsoft.Extensions.Logging;

namespace ClockMqtt.Builders
{
    /// <summary>
    /// Default implementation of <see cref="ILedStripBuilder"/>.
    /// </summary>
    public record LedStripBuilder : ILedStripBuilder
    {
        private IEnumerable<IPartialLedStrip> PartialLedStrips { get; init; }
        private ILogger<ILedStrip> Logger { get; init; }
        private int DisplayPin { get; init; }

        /// <summary>
        /// Instantiate a <see cref="LedStripBuilder"/>.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        /// <param name="displayService">The <see cref="IDisplayService"/> implementation to use.</param>
        public LedStripBuilder(ILogger<ILedStrip> logger)
        {
            Logger = logger;
            PartialLedStrips = Enumerable.Empty<IPartialLedStrip>();
        }

        /// <inheritdoc/>
        public ILedStripBuilder WithPartialLedStrip(IPartialLedStrip newPartialLedStrip) =>
            this with { PartialLedStrips = PartialLedStrips.Append(newPartialLedStrip) };

        /// <inheritdoc/>
        public ILedStripBuilder WithDisplayPin(int newDisplayPin) =>
            this with { DisplayPin = newDisplayPin };

        /// <inheritdoc/>
        public ILedStrip Create => new LedStrip(DisplayPin, PartialLedStrips, Logger);

        /// <inheritdoc/>
        public ILedStripBuilder Reset =>
            this with { PartialLedStrips = Enumerable.Empty<IPartialLedStrip>(), DisplayPin = default };
    }
}
