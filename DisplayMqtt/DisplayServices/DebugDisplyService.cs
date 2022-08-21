using System.Diagnostics;
using Common.DataTransferObjects;
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var ledStrip in displayData.LedStrips)
            {
                var actions = ledStrip
                    .CreateBitMap()
                    .Select(x => x
                        ? new Action<int>((i) => Fake_Send_1(i, stopwatch))
                        : new Action<int>((i) => Fake_Send_0(i, stopwatch)));

                Fake_Send_Reset(ledStrip.DisplayPin, stopwatch);
                foreach (var action in actions)
                {
                    action(ledStrip.DisplayPin);
                }
            }

            stopwatch.Stop();
        }

        private void Fake_Send_Reset(int displayPin, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
            LogTime(stopwatch);
        }

        private void Fake_Send_0(int displayPin, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            Thread.Sleep(TimeSpan.FromMilliseconds(0.00045));
            Thread.Sleep(TimeSpan.FromMilliseconds(0.0008));
            LogTime(stopwatch);
        }

        private void Fake_Send_1(int displayPin, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            Thread.Sleep(TimeSpan.FromMilliseconds(0.00085));
            Thread.Sleep(TimeSpan.FromMilliseconds(0.0004));
             LogTime(stopwatch);
       }

        private void LogTime(Stopwatch stopwatch)
        {
            logger.LogDebug($"ms: {stopwatch.Elapsed.TotalMilliseconds}");
        }
    }
}