using System.Device.Gpio;
using DisplayMqtt.Entities;

namespace DisplayMqtt.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="GpioController"/>.
    /// </summary>
    public static class GpioControllerExtensions
    {
        /// <summary>
        /// Extension method to initialize the given <paramref name="displayPin"/>.
        /// </summary>
        /// <param name="displayPin">The GpIO pin to initialize.</param>
        /// <returns>Returns a <see cref="GpioController"/> for further use with the initialized <paramref name="displayPin"/>.</returns>
        public static GpioController SetPinOutput(this int displayPin)
        {
            var controller = new GpioController();
            controller.OpenPin(displayPin, PinMode.Output, PinValue.High);
            return controller;
        }

        /// <summary>
        /// Extension method to send a reset signal for a Ws2812b led strip on <paramref name="displayPin"/>.
        /// </summary>
        /// <param name="controller">The <see cref="GpioController"/> to use.</param>
        /// <param name="displayPin">The GpIO pin to use.</param>
        public static void Send_Reset(this GpioController controller, int displayPin)
        {
            controller.Write(displayPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
            controller.Write(displayPin, PinValue.High);
        }

        /// <summary>
        /// Extension method to send a low value (0) for a Ws2812b led strip on <paramref name="displayPin"/>.
        /// </summary>
        /// <param name="controller">The <see cref="GpioController"/> to use.</param>
        /// <param name="displayPin">The GpIO pin to use.</param>
        public static void Send_0(this GpioController controller, int displayPin)
        {
            controller.Write(displayPin, PinValue.High);
            Thread.Sleep(TimeSpan.FromTicks(40000));
            controller.Write(displayPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromTicks(85000));
            controller.Write(displayPin, PinValue.High);
        }

        /// <summary>
        /// Extension method to send a high value (1) for a Ws2812b led strip on <paramref name="displayPin"/>.
        /// </summary>
        /// <param name="controller">The <see cref="GpioController"/> to use.</param>
        /// <param name="displayPin">The GpIO pin to use.</param>
        public static void Send_1(this GpioController controller, int displayPin)
        {
            controller.Write(displayPin, PinValue.High);
            Thread.Sleep(TimeSpan.FromTicks(80000));
            controller.Write(displayPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromTicks(45000));
            controller.Write(displayPin, PinValue.High);
        }

        /// <summary>
        /// Extension method to convert a <see cref="IDisplayDataEntity"/> to a bitmap represent by a collection of <see cref="bool"/>.
        /// </summary>
        /// <param name="displayData">The data to display.</param>
        /// <returns>Returns a collection of <see cref="bool"/>.</returns>
        public static IEnumerable<bool> CreateBitMap(this IDisplayDataEntity displayData)
        {
             return displayData.Leds.SelectMany(LedToBitmap);

            IEnumerable<bool> ByteToBitmap(byte data)
            {
                for (var i = 128; i >= 1; i /= 2)
                {
                    yield return ((data & i) != 0);
                }
            }

            IEnumerable<bool> LedToBitmap(ILed led) =>
                ByteToBitmap(led.Green)
                    .Concat(ByteToBitmap(led.Red))
                    .Concat(ByteToBitmap(led.Blue));

        }
    }
}

