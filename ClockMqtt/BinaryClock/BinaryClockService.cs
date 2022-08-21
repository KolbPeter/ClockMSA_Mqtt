using ClockMqtt.Clocks;
using Common.DataTransferObjects;

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
            new Common.DataTransferObjects.DisplayDataEntities()
            {
                LedStrips = binaryClock
                    .DisplayLedStrips(dateTime)
                    .Select(x => new Common.DataTransferObjects.DisplayDataEntity()
                    { 
                        DisplayPin = x.DisplayPin,
                        Leds = x.Leds.Select(y => 
                            new Common.DataTransferObjects.Led() with
                            {
                                Red = y.Red,
                                Green = y.Green,
                                Blue = y.Blue
                            })
                    })
            };
    }
}
