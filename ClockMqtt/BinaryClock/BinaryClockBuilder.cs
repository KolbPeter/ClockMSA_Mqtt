using ClockMqtt.Builders;
using ClockMqtt.Clocks;
using ClockMqtt.Extensions;
using ClockMqtt.Leds;

namespace ClockMqtt.BinaryClock
{
    /// <summary>
    /// Default implementation of <see cref="IBinaryClockBuilder"/>.
    /// </summary>
    public class BinaryClockBuilder : IBinaryClockBuilder
    {
        private readonly IClockBuilder clockBuilder;
        private readonly ILedStripBuilder ledStripBuilder;
        private readonly IPartialLedStripBuilder partialLedStripBuilder;

        /// <summary>
        /// Instantiates a <see cref="BinaryClockBuilder"/>.
        /// </summary>
        /// <param name="clockBuilder">The <see cref="IClockBuilder"/> to use.</param>
        /// <param name="ledStripBuilder">The <see cref="ILedStripBuilder"/> to use.</param>
        /// <param name="partialLedStripBuilder">The <see cref="IPartialLedStripBuilder"/> to use.</param>
        public BinaryClockBuilder(
            IClockBuilder clockBuilder,
            ILedStripBuilder ledStripBuilder,
            IPartialLedStripBuilder partialLedStripBuilder)
        {
            this.clockBuilder = clockBuilder;
            this.ledStripBuilder = ledStripBuilder;
            this.partialLedStripBuilder = partialLedStripBuilder;
        }

        /// <inheritdoc/>
        public IClock CreateBinaryClock() =>
            clockBuilder
                .WithLedStrip(newLedStrip: ledStripBuilder
                    .Reset
                    .WithDisplayPin(newDisplayPin: 1)
                    .WithPartialLedStrip(
                        newPartialLedStrip: partialLedStripBuilder
                            .Reset
                            .WithLedCount(newLedCount: 6)
                            .WithColorWhenSet(newColorWhenSet: new Led(red: 0, green: 0, blue: 150))
                            .WithColorWhenCleared(newColorWhenCleared: new Led(red: 0, green: 0, blue: 0))
                            .WithCalculatorFunction(calculatorFunction: (dt, lc) =>
                                dt.SecondsToBinaryValues(ledCount: lc))
                            .Create)
                    .WithPartialLedStrip(
                        newPartialLedStrip: partialLedStripBuilder
                            .WithLedCount(newLedCount: 6)
                            .WithColorWhenSet(newColorWhenSet: new Led(red: 0, green: 150, blue: 0))
                            .WithColorWhenCleared(newColorWhenCleared: new Led(red: 0, green: 0, blue: 0))
                            .WithCalculatorFunction(calculatorFunction: (dt, lc) =>
                                dt.MinutesToBinaryValues(ledCount: lc))
                            .Create)
                    .WithPartialLedStrip(
                        newPartialLedStrip: partialLedStripBuilder
                            .WithLedCount(newLedCount: 5)
                            .WithColorWhenSet(newColorWhenSet: new Led(red: 150, green: 0, blue: 0))
                            .WithColorWhenCleared(newColorWhenCleared: new Led(red: 0, green: 0, blue: 0))
                            .WithCalculatorFunction(
                                calculatorFunction: (dt, lc) => dt.HoursToBinaryValues(ledCount: lc))
                            .Create)
                    .Create)
                .WithLedStrip(ledStripBuilder
                    .Reset
                    .WithDisplayPin(2)
                    .WithPartialLedStrip(
                        newPartialLedStrip: partialLedStripBuilder
                            .WithLedCount(newLedCount: 5)
                            .WithColorWhenSet(newColorWhenSet: new Led(red: 75, green: 0, blue: 75))
                            .WithColorWhenCleared(newColorWhenCleared: new Led(red: 0, green: 0, blue: 0))
                            .WithCalculatorFunction(calculatorFunction: (dt, lc) => dt.DaysToBinaryValues(ledCount: lc))
                            .Create)
                    .WithPartialLedStrip(
                        newPartialLedStrip: partialLedStripBuilder
                            .WithLedCount(newLedCount: 4)
                            .WithColorWhenSet(newColorWhenSet: new Led(red: 0, green: 75, blue: 75))
                            .WithColorWhenCleared(newColorWhenCleared: new Led(red: 0, green: 0, blue: 0))
                            .WithCalculatorFunction(calculatorFunction: (dt, lc) =>
                                dt.MonthsToBinaryValues(ledCount: lc))
                            .Create)
                    .WithPartialLedStrip(
                        newPartialLedStrip: partialLedStripBuilder
                            .WithLedCount(newLedCount: 7)
                            .WithColorWhenSet(newColorWhenSet: new Led(red: 75, green: 75, blue: 0))
                            .WithColorWhenCleared(newColorWhenCleared: new Led(red: 0, green: 0, blue: 0))
                            .WithCalculatorFunction(
                                calculatorFunction: (dt, lc) => dt.YearsToBinaryValues(ledCount: lc))
                            .Create)
                    .Create)
                .Create;
    }
}