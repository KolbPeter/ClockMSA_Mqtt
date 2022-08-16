using MqttComm.ActionResults;
using Newtonsoft.Json;

namespace MqttComm.Serializers
{
    public class JsonConverterService : IJsonConverterService
    {
        public JsonConverterService()
        {
        }

        public ActionResult<string> Serialize<T>(T toSerialize)
        {
            try
            {
                var result = JsonConvert.SerializeObject(toSerialize);
                if (result == null)
                {
                    return new ActionResult<string>(
                        new Exception($"Serialization failed! '{toSerialize?.ToString() ?? nameof(toSerialize)}'"));
                }

                return new ActionResult<string>(result);
            }
            catch (Exception ex)
            {
                return new ActionResult<string>(ex);
            }
        }

        public ActionResult<T> Deserialize<T>(string message)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<T>(message);
                if (result == null)
                {
                    return new ActionResult<T>(new Exception($"Deserialization failed! '{message}'"));
                }

                return new ActionResult<T>(result);
            }
            catch (Exception ex)
            {
                return new ActionResult<T>(ex);
            }
        }
    }
}
