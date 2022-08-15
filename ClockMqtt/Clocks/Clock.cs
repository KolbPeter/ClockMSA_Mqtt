using ClockMqtt.Leds;
using ClockMqtt.LedStrips;
using Microsoft.Extensions.Logging;

namespace ClockMqtt.Clocks
{
    /// <summary>
    /// Default implementation of <see cref="IClock"/>.
    /// </summary>
    public class Clock : IClock
    {
        private readonly ILogger<IClock> logger;

        /// <summary>
        /// Instantiates a <see cref="Clock"/>.
        /// </summary>
        /// <param name="ledStrips">A collection of <see cref="ILedStrip"/> to use.</param>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        public Clock(
            IEnumerable<ILedStrip> ledStrips,
            ILogger<IClock> logger)
        {
            LedStrips = ledStrips;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public IEnumerable<ILedStrip> LedStrips { get; }

        /// <inheritdoc/>
        public IEnumerable<(int DisplayPin, IEnumerable<ILed> Leds)> DisplayLedStrips(DateTime dateTime) =>
            LedStrips.Select(x => (x.DisplayPin, x.CalculateLedColors(dateTime)));
    }
}
