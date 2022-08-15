namespace MqttComm.Subscriptions
{
    public record Subscription : ISubscription
    {
        public Subscription(
            string topic,
            Action<string> onReceive)
        {
            Topic = topic;
            OnReceive = onReceive;
        }

        public string Topic { get; init; }
        public Action<string> OnReceive { get; init; }
    }
}
