using ClockMqtt.Clocks;
using ClockMqtt.Dtos;

namespace ClockMqtt.BinaryClock
{
    /// <summary>
    /// Default implementation of <see cref="IBinaryClockService"/>.
    /// </summary>
    public class BinaryClockService : IBinaryClockService
    {
        private readonly IClock binaryClock;

        /// <summary>
        /// Instantiate a <see cref="BinaryClockService"/>.
        /// </summary>
        /// <param name="clockBuilder">The <see cref="IBinaryClockBuilder"/> implementation to use.</param>
        public BinaryClockService(IBinaryClockBuilder clockBuilder)
        {
            binaryClock = clockBuilder.CreateBinaryClock();
        }

        /// <inheritdoc/>
        public IEnumerable<DisplayDataEntity> CreateDisplayData(DateTime dateTime) =>
            binaryClock
                .DisplayLedStrips(dateTime)
                .Select(x => new DisplayDataEntity()
                {
                    DisplayPin = x.DisplayPin,
                    Leds = x.Leds.Select(y =>
                        new[] { y.Red, y.Green, y.Blue })
                });
    };
}
