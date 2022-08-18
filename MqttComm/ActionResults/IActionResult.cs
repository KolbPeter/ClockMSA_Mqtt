namespace MqttComm.ActionResults
{
    /// <summary>
    /// Interface to store the result of an action.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the result of the action.</typeparam>
    public interface IActionResult<T>
    {
        /// <summary>
        /// Gets the resulted data of the action.
        /// </summary>
        T? Data { get; init; }

        /// <summary>
        /// Gets the exception the action resulted in or null.
        /// </summary>
        Exception? ThrownException { get; init; }

        /// <summary>
        /// Gets a value indicating whether the action was successful or not.
        /// </summary>
        bool IsSuccessful { get; }
    }
}