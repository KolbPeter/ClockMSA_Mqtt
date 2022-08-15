using ClockMqtt.Clocks;
using ClockMqtt.LedStrips;
using Microsoft.Extensions.Logging;

namespace ClockMqtt.Builders
{
    /// <summary>
    /// Default implementation of <see cref="IClockBuilder"/>.
    /// </summary>
    public record ClockBuilder : IClockBuilder
    {
        private readonly ILogger<IClock> logger;

        private IEnumerable<ILedStrip> LedStrips { get; init; }

        /// <summary>
        /// Instantiate a <see cref="ClockBuilder"/>.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger"/> implementation to use.</param>
        public ClockBuilder(ILogger<IClock> logger)
        {
            this.logger = logger;
            LedStrips = Enumerable.Empty<ILedStrip>();
        }

        /// <inheritdoc/>
        public IClockBuilder WithLedStrip(ILedStrip newLedStrip)
        {
            if (LedStrips.Any(x => x.DisplayPin == newLedStrip.DisplayPin))
            {
                throw new ArgumentException($"Led strip on display pin {newLedStrip.DisplayPin} already exists.");
            }
            return this with { LedStrips = LedStrips.Append(newLedStrip) };
        }

        /// <inheritdoc/>
        public IClock Create =>
            new Clock(ledStrips: LedStrips, logger: logger);

        /// <inheritdoc/>
        public IClockBuilder Reset =>
            this with { LedStrips = Enumerable.Empty<ILedStrip>() };
    }
}
