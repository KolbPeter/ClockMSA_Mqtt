using System.Device.Gpio;
using DisplayMqtt.Entities;
using DisplayMqtt.Extensions;
using Microsoft.Extensions.Logging;

namespace DisplayMqtt.DisplayServices
{
    public class Ws2812bDisplay : IDisplayService
    {
        private readonly ILogger<IDisplayService> logger;

        public Ws2812bDisplay(ILogger<IDisplayService> logger)
        {
            this.logger = logger;
        }

        public void Display(DisplayDataEntities displayData)
        {
#if DEBUG
            DebugDisplay(displayData);
#else
            ReleaseDisplay(displayData);
#endif
        }

        private void DebugDisplay(DisplayDataEntities displayData)
        {
            foreach (var ledStrip in displayData.LedStrips)
            {
                var bitmap = ledStrip
                    .CreateBitMap()
                    .Select(x => x ? 1 : 0)
                    .Chunk(8).Select(x => string.Join("", x))
                    .Chunk(3).Select(x => string.Join(" ", x));

                var message = string.Join("|", bitmap);

                logger.LogDebug($"Sendng {message} to led strip on pin {ledStrip.DisplayPin}.");
            }
        }

        private void ReleaseDisplay(DisplayDataEntities displayData)
        {
            foreach (var ledStrip in displayData.LedStrips)
            {
                var actions = ledStrip
                    .CreateBitMap()
                    .Select(x => x
                        ? new Action<GpioController, int>((c, i) => c.Send_1(i))
                        : new Action<GpioController, int>((c, i) => c.Send_0(i)));

                using var controller = ledStrip.DisplayPin.SetPinOutput();

                controller.Send_Reset(ledStrip.DisplayPin);
                foreach (var action in actions)
                {
                    action(controller, ledStrip.DisplayPin);
                }
            }
        }
    }
}
