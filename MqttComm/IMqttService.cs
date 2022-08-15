using MqttComm.ActionResults;

namespace MqttComm
{
    public interface IMqttService
    {
        Task<ActionResult<string>> Publish(string topic, string message);
        void Subscribe(string topic, Action<string> onReceive);
        void UnSubscribe(string topic);
    }
}