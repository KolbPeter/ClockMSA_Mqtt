using MqttComm.ActionResults;

namespace MqttComm
{
    /// <summary>
    /// Interface for MQTT communication service
    /// </summary>
    public interface IMqttService
    {
        /// <summary>
        /// Async method to publish a <paramref name="message"/> on the given <paramref name="topic"/>.
        /// </summary>
        /// <param name="topic">The topic to publish to.</param>
        /// <param name="message">The message to publish.</param>
        /// <returns>Returns a <see cref="Task"/> that will be resulted in a <see cref="ActionResult{T}"/>.</returns>
        Task<ActionResult<string>> Publish(string topic, string message);

        /// <summary>
        /// Method to subscribe to the given <paramref name="topic"/> with the given <paramref name="onReceive"/>.
        /// </summary>
        /// <param name="topic">The topic to subscribe for.</param>
        /// <param name="onReceive">An action, that accepts the message string. It will be executed when receiving a message on the given topic.</param>
        void Subscribe(string topic, Action<string> onReceive);

        /// <summary>
        /// Method to unsubscribe from the given <paramref name="topic"/>. If there are multiple subscription on this topic,
        /// all of them will be unsubscribed.
        /// </summary>
        /// <param name="topic"></param>
        void UnSubscribe(string topic);
    }
}