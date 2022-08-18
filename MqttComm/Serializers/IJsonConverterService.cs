using MqttComm.ActionResults;

namespace MqttComm.Serializers
{
    /// <summary>
    /// Interface for json converter service.
    /// </summary>
    public interface IJsonConverterService
    {
        /// <summary>
        /// Deserialize the given <paramref name="message"/> to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the result object.</typeparam>
        /// <param name="message">The <see cref="string"/> to deserialize.</param>
        /// <returns>Returns an <see cref="ActionResult{T}"/> with the result of the deserialization.</returns>
        ActionResult<T> Deserialize<T>(string message);

        /// <summary>
        /// Serialize the given <paramref name="objectToSerialize"/> to a string.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the object to serialize.</typeparam>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns>Returns an <see cref="ActionResult{T}"/> with the result of the serialization.</returns>
        ActionResult<string> Serialize<T>(T objectToSerialize);
    }
}