namespace MqttComm.ActionResults
{
    /// <summary>
    /// Default implementation of <see cref="IActionResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the result of the action.</typeparam>
    public record ActionResult<T> : IActionResult<T>
    {
        /// <summary>
        /// Instantiates a successful action result.
        /// </summary>
        /// <param name="data">The resulted data of the action.</param>
        public ActionResult(T data)
        {
            Data = data;
            ThrownException = null;
        }

        /// <summary>
        /// Instantiates an unsuccessful action result.
        /// </summary>
        /// <param name="exception">The exception that was thrown.</param>
        public ActionResult(Exception exception)
        {
            Data = default;
            ThrownException = exception;
        }

        /// <inheritdoc/>
        public T? Data { get; init; }

        /// <inheritdoc/>
        public Exception? ThrownException { get; init; }

        /// <inheritdoc/>
        public bool IsSuccessful => ThrownException is null;
    }
}
