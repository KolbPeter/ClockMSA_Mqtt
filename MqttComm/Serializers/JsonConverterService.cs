using MqttComm.ActionResults;
using Newtonsoft.Json;

namespace MqttComm.Serializers
{
    /// <summary>
    /// Default implementation of <see cref="IJsonConverterService"/>.
    /// </summary>
    public class JsonConverterService : IJsonConverterService
    {
        /// <inheritdoc/>
        public ActionResult<string> Serialize<T>(T objectToSerialize)
        {
            try
            {
                var result = JsonConvert.SerializeObject(objectToSerialize);
                if (result == null)
                {
                    return new ActionResult<string>(
                        new Exception($"Serialization failed! '{objectToSerialize?.ToString() ?? nameof(objectToSerialize)}'"));
                }

                return new ActionResult<string>(result);
            }
            catch (Exception ex)
            {
                return new ActionResult<string>(ex);
            }
        }

        /// <inheritdoc/>
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
