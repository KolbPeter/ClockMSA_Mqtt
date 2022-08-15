namespace MqttComm.Subscriptions
{
    public interface ISubscription
    {
        Action<string> OnReceive { get; init; }
        string Topic { get; init; }
    }
}