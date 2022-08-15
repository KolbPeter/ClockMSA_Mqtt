using ClockMqtt.Extensions;
using ClockMqtt.Leds;
using Microsoft.Extensions.Logging;

namespace ClockMqtt.LedStrips
{
    /// <summary>
    /// Default implementation of <see cref="IPartialLedStrip"/>.
    /// </summary>
    public class PartialLedStrip : IPartialLedStrip
    {
        private readonly Func<DateTime, int, IEnumerable<bool>> calculator;
        private readonly ILed colorWhenSet;
        private readonly ILed colorWhenCleared;
        private readonly ILogger<IPartialLedStrip> logger;

        /// <summary>
        /// Instantiate a <see cref="PartialLedStrip"/>.
        /// </summary>
        /// <param name="ledCount">The number of led in this led strip segment.</param>
        /// <param name="calculator">The calculator function to use.</param>
        /// <param name="colorWhenSet">The led color when the led is set.</param>
        /// <param name="colorWhenCleared">The led color when the led is cleared.</param>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        public PartialLedStrip(
            int ledCount,
            Func<DateTime, int, IEnumerable<bool>> calculator,
            ILed colorWhenSet,
            ILed colorWhenCleared,
            ILogger<IPartialLedStrip> logger)
        {
            LedCount = ledCount;
            this.calculator = calculator;
            this.colorWhenSet = colorWhenSet;
            this.colorWhenCleared = colorWhenCleared;
            this.logger = logger;
            this.logger.LogDebug($"Initialized partial ledstrip with {LedCount} leds, {colorWhenSet.ColorString} colored leds and {colorWhenCleared.ColorString} cleared led color.");
        }

        /// <inheritdoc/>
        public int LedCount { get; }

        /// <inheritdoc/>
        public IEnumerable<ILed> CalculateLedColors(DateTime dateTime) =>
            CalculateLedStates(dateTime)
            .ToColorValues(colorWhenSet, colorWhenCleared);

        /// <inheritdoc/>
        public IEnumerable<bool> CalculateLedStates(DateTime dateTime) =>
            calculator(dateTime, LedCount);
    }
}
