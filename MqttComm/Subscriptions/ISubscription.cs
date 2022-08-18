namespace MqttComm.Subscriptions
{
    /// <summary>
    /// Interface for subscriptions.
    /// </summary>
    public interface ISubscription
    {
        /// <summary>
        /// Gets an action, that accepts the received message string. It will be executed when receiving a message on the given topic.
        /// </summary>
        Action<string> OnReceive { get; init; }

        /// <summary>
        /// Gets the topic for this subscription.
        /// </summary>
        string Topic { get; init; }
    }
}