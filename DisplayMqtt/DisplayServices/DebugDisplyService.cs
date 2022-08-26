using DisplayMqtt.Entities;
using DisplayMqtt.Extensions;
using Microsoft.Extensions.Logging;

namespace DisplayMqtt.DisplayServices
{
    public class DebugDisplyService : IDisplayService
    {
        private readonly ILogger<IDisplayService> logger;

        /// <summary>
        /// Instantiates a <see cref="DebugDisplyService"/>.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        public DebugDisplyService(ILogger<IDisplayService> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public void Display(DisplayDataEntities displayData)
        {
            foreach (var ledStrip in displayData.LedStrips)
            {
                var actions = ledStrip
                    .CreateBitMap()
                    .Select(x => x
                        ? new Action<int>((i) => Fake_Send_1(i))
                        : new Action<int>((i) => Fake_Send_0(i)));

                Fake_Send_Reset(ledStrip.DisplayPin);
                foreach (var action in actions)
                {
                    action(ledStrip.DisplayPin);
                }
            }
        }

        private void Fake_Send_Reset(int displayPin)
        {
            LogLow();
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
            LogHigh();
        }

        private void Fake_Send_0(int displayPin)
        {
            LogHigh();
            Thread.Sleep(TimeSpan.FromTicks(40000));
            LogLow();
            Thread.Sleep(TimeSpan.FromTicks(85000));
            LogHigh();
        }

        private void Fake_Send_1(int displayPin)
        {
            LogHigh();
            Thread.Sleep(TimeSpan.FromTicks(80000));
            LogLow();
            Thread.Sleep(TimeSpan.FromTicks(45000));
            LogHigh();
        }

        private void LogHigh()
        {
            logger.LogDebug($",{DateTime.Now.ToString("hh:mm:ss.FFFFFF")},1");
        }

        private void LogLow()
        {
            logger.LogDebug($",{DateTime.Now.ToString("hh:mm:ss.FFFFFF")},0");
        }
    }
}