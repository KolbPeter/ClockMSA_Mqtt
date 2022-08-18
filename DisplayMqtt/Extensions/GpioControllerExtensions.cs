using System.Device.Gpio;
using DisplayMqtt.Entities;

namespace DisplayMqtt.Extensions
{
    public static class GpioControllerExtensions
    {
        public static GpioController SetPinOutput(this int displayPin)
        {
            var controller = new GpioController();
            controller.OpenPin(displayPin, PinMode.Output, PinValue.High);
            return controller;
        }

        public static void Send_Reset(this GpioController controller, int displayPin)
        {
            controller.Write(displayPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
            controller.Write(displayPin, PinValue.High);
        }

        public static void Send_0(this GpioController controller, int displayPin)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(0.4));
            controller.Write(displayPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromMilliseconds(0.85));
            controller.Write(displayPin, PinValue.High);
        }

        public static void Send_1(this GpioController controller, int displayPin)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(0.8));
            controller.Write(displayPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromMilliseconds(0.45));
            controller.Write(displayPin, PinValue.High);
        }

        public static IEnumerable<bool> CreateBitMap(this IDisplayDataEntity displayData)
        {
             return displayData.Leds.SelectMany(LedToBitmap);

            IEnumerable<bool> ByteToBitmap(byte data)
            {
                for (var i = 1; i <= 128; i *= 2)
                {
                    yield return ((data & i) != 0);
                }
            }

            IEnumerable<bool> LedToBitmap(ILed led) =>
                ByteToBitmap(led.Red)
                    .Concat(ByteToBitmap(led.Green))
                    .Concat(ByteToBitmap(led.Blue));

        }
    }
}

