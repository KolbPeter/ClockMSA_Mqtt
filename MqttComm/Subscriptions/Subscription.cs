namespace MqttComm.Subscriptions
{
    /// <summary>
    /// Defautl implementation of <see cref="ISubscription"/>.
    /// </summary>
    public record Subscription : ISubscription
    {
        /// <summary>
        /// Instantiate a <see cref="Subscription"/>.
        /// </summary>
        /// <param name="topic">The topic for this subscription.</param>
        /// <param name="onReceive">An action, that accepts the received message string. It will be executed when receiving a message on the given topic.</param>
        public Subscription(
            string topic,
            Action<string> onReceive)
        {
            Topic = topic;
            OnReceive = onReceive;
        }

        /// <inheritdoc/>
        public string Topic { get; init; }

        /// <inheritdoc/>
        public Action<string> OnReceive { get; init; }
    }
}
