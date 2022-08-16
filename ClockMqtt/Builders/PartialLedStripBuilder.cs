using ClockMqtt.Leds;
using ClockMqtt.LedStrips;
using Microsoft.Extensions.Logging;

namespace ClockMqtt.Builders
{
    /// <summary>
    /// Default implementation of <see cref="IPartialLedStripBuilder"/>.
    /// </summary>
    public record PartialLedStripBuilder : IPartialLedStripBuilder
    {
        private int LedCount { get; init; }
        private Func<DateTime, int, IEnumerable<bool>> Calculator { get; init; }
        private ILed ColorWhenSet { get; init; }
        private ILed ColorWhenCleared { get; init; }
        private ILogger<IPartialLedStrip> Logger { get; }

        /// <summary>
        /// Instantiate a <see cref="PartialLedStripBuilder"/>.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        public PartialLedStripBuilder(ILogger<IPartialLedStrip> logger)
        {
            Logger = logger;
            LedCount = 1;
            ColorWhenSet = new Led(red: 50, green: 50, blue: 50);
            ColorWhenCleared = new Led(red: 0, green: 0, blue: 0);
            Calculator = (dt, i) => Enumerable.Range(0, i).Select(x => true);
        }

        /// <inheritdoc/>
        public IPartialLedStripBuilder WithLedCount(int newLedCount) =>
            this with { LedCount = newLedCount };

        /// <inheritdoc/>
        public IPartialLedStripBuilder WithColorWhenSet(ILed newColorWhenSet) =>
            this with { ColorWhenSet = newColorWhenSet };

        /// <inheritdoc/>
        public IPartialLedStripBuilder WithColorWhenCleared(ILed newColorWhenCleared) =>
            this with { ColorWhenCleared = newColorWhenCleared };

        /// <inheritdoc/>
        public IPartialLedStripBuilder WithCalculatorFunction(Func<DateTime, int, IEnumerable<bool>> calculatorFunction) =>
            this with { Calculator = calculatorFunction };

        /// <inheritdoc/>
        public IPartialLedStrip Create =>
            new PartialLedStrip(LedCount, Calculator, ColorWhenSet, ColorWhenCleared, Logger);

        /// <inheritdoc/>
        public IPartialLedStripBuilder Reset =>
            this with
            {
                LedCount = 1,
                ColorWhenSet = new Led(red: 50, green: 50, blue: 50),
                ColorWhenCleared = new Led(red: 0, green: 0, blue: 0),
                Calculator = (dt, i) => Enumerable.Range(0, i).Select(x => true)
            };
    }
}
