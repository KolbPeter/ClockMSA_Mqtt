namespace MqttComm.ActionResults
{
    public record ActionResult<T> : IActionResult<T>
    {
        public ActionResult(T data)
        {
            Data = data;
            ThrownException = null;
        }

        public ActionResult(Exception exception)
        {
            Data = default;
            ThrownException = exception;
        }

        public T? Data { get; init; }

        public Exception? ThrownException { get; init; }

        public bool IsSuccessfull => ThrownException is null;
    }
}
