using ClockMqtt.Clocks;
using ClockMqtt.Entities;

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
        public DisplayDataEntities CreateDisplayData(DateTime dateTime) =>
            new()
            {
                LedStrips = binaryClock
                    .DisplayLedStrips(dateTime)
                    .Select(x => new DisplayDataEntity(x.DisplayPin, x.Leds))
            };
    }
}
