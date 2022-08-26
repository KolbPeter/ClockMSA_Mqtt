using System.Diagnostics;
using DisplaMqtt.Dtos;
using DisplayMqtt.Extensions;
using Microsoft.Extensions.Logging;

namespace DisplayMqtt.DisplayServices
{
    public class DebugDisplyService : IDisplayService
    {
        private readonly ILogger<IDisplayService> logger;
        private readonly Stopwatch stopwatch;

        /// <summary>
        /// Instantiates a <see cref="DebugDisplyService"/>.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        public DebugDisplyService(ILogger<IDisplayService> logger)
        {
            this.logger = logger;
            this.stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        /// <inheritdoc/>
        public void Display(IEnumerable<DisplayDataEntity> displayData)
        {
            foreach (var ledStrip in displayData)
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

            stopwatch.Stop();
        }

        private void Fake_Send_Reset(int displayPin)
        {
            var localsw = new Stopwatch();
            localsw.Start();
            stopwatch.Restart();
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
            LogTime(localsw);
        }

        private void Fake_Send_0(int displayPin)
        {
            var localsw = new Stopwatch();
            localsw.Start();
            stopwatch.Restart();
            WaitAfter(0.00045);
            WaitAfter(0.0008);
            LogTime(localsw);
        }

        private void Fake_Send_1(int displayPin)
        {
            var localsw = new Stopwatch();
            localsw.Start();
            stopwatch.Restart();
            WaitAfter(0.00085);
            WaitAfter(0.0004);
            LogTime(localsw);
       }

        private void LogTime(Stopwatch localsw)
        {
            logger.LogDebug($"ms: {localsw.Elapsed.TotalMilliseconds}");
        }

        private void WaitAfter(double targetMillis)
        {
            stopwatch.Restart();
            while (stopwatch.Elapsed.TotalMilliseconds <= targetMillis)
            {
            }
        }
    }
}