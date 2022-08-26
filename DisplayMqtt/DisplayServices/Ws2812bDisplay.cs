using System.Device.Gpio;
using System.Diagnostics;
using DisplaMqtt.Dtos;
using DisplayMqtt.Extensions;
using Microsoft.Extensions.Logging;

namespace DisplayMqtt.DisplayServices
{
    /// <summary>
    /// Implementation of <see cref="IDisplayService"/> to control a GpIO pin.
    /// </summary>
    public class Ws2812bDisplay : IDisplayService
    {
        private readonly ILogger<IDisplayService> logger;

        /// <summary>
        /// Instantiates a <see cref="Ws2812bDisplay"/>.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        public Ws2812bDisplay(ILogger<IDisplayService> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public void Display(IEnumerable<DisplayDataEntity> displayData)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var ledStrip in displayData)
            {
                var actions = ledStrip
                    .CreateBitMap()
                    .Select(x => x
                        ? new Action<GpioController, int>((c, i) => c.Send_1(i, stopwatch))
                        : new Action<GpioController, int>((c, i) => c.Send_0(i, stopwatch)));

                using (var controller = ledStrip.DisplayPin.SetPinOutput())
                {
                    controller.Send_Reset(ledStrip.DisplayPin);
                    foreach (var action in actions)
                    {
                        action(controller, ledStrip.DisplayPin);
                    }

                    controller.ClosePin(ledStrip.DisplayPin);
                }
            }
        }
    }
}
