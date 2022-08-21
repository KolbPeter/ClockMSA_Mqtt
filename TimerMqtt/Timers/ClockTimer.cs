using System.Timers;

namespace TimerMqtt.Timers
{
    /// <summary>
    /// Default implementation of <see cref="IClockTimer"/>.
    /// </summary>
    public class ClockTimer : IClockTimer
    {
        private readonly TimeSpan tickInterval;
        private readonly Action triggeredAction;
        private readonly System.Timers.Timer ticker;

        /// <summary>
        /// Instantiate a <see cref="ClockTimer"/>
        /// </summary>
        /// <param name="tickInterval">The time interval between the clockTimer checks the current time.</param>
        public ClockTimer(
            TimeSpan tickInterval,
            Action triggeredAction)
        {
            this.tickInterval = tickInterval;
            this.triggeredAction = triggeredAction;
            ticker = CreateTimer(checkInterval: tickInterval);
        }

        /// <inheritdoc/>
        public double TickInterval => tickInterval.TotalMilliseconds / 1000;

        private System.Timers.Timer CreateTimer(TimeSpan checkInterval)
        {
            var ticker = new System.Timers.Timer();
            ticker.Elapsed += Ticker_Elapsed;
            ticker.Interval = checkInterval.TotalMilliseconds;
            return ticker;
        }

        private void Ticker_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Task.Run(() => triggeredAction());
        }

        /// <inheritdoc/>
        public void Start()
        {
            ticker.Start();
        }

        /// <inheritdoc/>
        public void Stop()
        {
            ticker.Stop();
        }

        /// <inheritdoc/>
        public bool IsEnabled => ticker.Enabled;
    }
}