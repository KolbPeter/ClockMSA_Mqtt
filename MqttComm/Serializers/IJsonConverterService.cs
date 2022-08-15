using MqttComm.ActionResults;

namespace MqttComm.Serializers
{
    public interface IJsonConverterService
    {
        ActionResult<T> Deserialize<T>(string message);
        ActionResult<string> Serialize<T>(T toSerialize);
    }
}