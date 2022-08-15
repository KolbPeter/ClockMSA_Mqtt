using ClockMqtt.Leds;
using Microsoft.Extensions.Logging;

namespace ClockMqtt.LedStrips
{
    /// <summary>
    /// Default implementation of <see cref="ILedStrip"/>.
    /// </summary>
    public class LedStrip : ILedStrip
    {
        private readonly ILogger<ILedStrip> logger;

        /// <summary>
        /// Instantiates a <see cref="LedStrip"/>.
        /// </summary>
        /// <param name="displayPin">The pin number this led strip is connected to.</param>
        /// <param name="partialLedStrips">A collection of <see cref="IPartialLedStrip"/> to use.</param>
        /// <param name="displayService">The <see cref="IDisplayService"/> implementation to use.</param>
        /// <param name="logger"></param>
        public LedStrip(
            int displayPin,
            IEnumerable<IPartialLedStrip> partialLedStrips,
            ILogger<ILedStrip> logger)
        {
            this.DisplayPin = displayPin;
            this.PartialLedStrips = partialLedStrips;
            this.logger = logger;
            this.logger.LogDebug(message: $"Initialized led strip with {LedCount} leds, on pin {displayPin}.");
        }

        /// <inheritdoc/>
        public IEnumerable<IPartialLedStrip> PartialLedStrips { get; }

        /// <inheritdoc/>
        public int LedCount => PartialLedStrips.Sum(selector: x => x.LedCount);

        /// <inheritdoc/>
        public int DisplayPin { get; }

        /// <inheritdoc/>
        public IEnumerable<ILed> CalculateLedColors(DateTime dateTime) =>
            PartialLedStrips.SelectMany(selector: x => x.CalculateLedColors(dateTime: dateTime));

        /// <inheritdoc/>
        public IEnumerable<bool> CalculateLedStates(DateTime dateTime) =>
            PartialLedStrips.SelectMany(selector: x => x.CalculateLedStates(dateTime: dateTime));
    }
}
