using System.Device.Gpio;
using DisplaMqtt.Dtos;

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
            controller.ClearAsync(displayPin);
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
            controller.SetAsync(displayPin);
        }

        /// <summary>
        /// Extension method to send a low value (0) for a Ws2812b led strip on <paramref name="displayPin"/>.
        /// </summary>
        /// <param name="controller">The <see cref="GpioController"/> to use.</param>
        /// <param name="displayPin">The GpIO pin to use.</param>
        public static void Send_0(this GpioController controller, int displayPin)
        {
            Thread.Sleep(TimeSpan.FromTicks(4));
            controller.ClearAsync(displayPin);
            Thread.Sleep(TimeSpan.FromTicks(8));
            controller.SetAsync(displayPin);
        }

        /// <summary>
        /// Extension method to send a high value (1) for a Ws2812b led strip on <paramref name="displayPin"/>.
        /// </summary>
        /// <param name="controller">The <see cref="GpioController"/> to use.</param>
        /// <param name="displayPin">The GpIO pin to use.</param>
        public static void Send_1(this GpioController controller, int displayPin)
        {
            Thread.Sleep(TimeSpan.FromTicks(8));
            controller.ClearAsync(displayPin);
            Thread.Sleep(TimeSpan.FromTicks(4));
            controller.SetAsync(displayPin);
        }

        /// <summary>
        /// Extension method to convert a <see cref="IDisplayDataEntity"/> to a bitmap represent by a collection of <see cref="bool"/>.
        /// </summary>
        /// <param name="displayData">The data to display.</param>
        /// <returns>Returns a collection of <see cref="bool"/>.</returns>
        public static IEnumerable<bool> CreateBitMap(this DisplayDataEntity displayData)
        {
             return displayData.Leds.SelectMany(LedToBitmap);

            IEnumerable<bool> ByteToBitmap(byte data)
            {
                for (var i = 128; i >= 1; i /= 2)
                {
                    yield return ((data & i) != 0);
                }
            }

            IEnumerable<bool> LedToBitmap(byte[] led) =>
                ByteToBitmap(led[0])
                    .Concat(ByteToBitmap(led[1]))
                    .Concat(ByteToBitmap(led[2]));
        }

        private static void SetAsync(this GpioController controller, int displayPin)
        {
            Task.Run(() => controller.Write(displayPin, PinValue.High));
        }

        private static void ClearAsync(this GpioController controller, int displayPin)
        {
            Task.Run(() => controller.Write(displayPin, PinValue.Low));
        }
    }
}

