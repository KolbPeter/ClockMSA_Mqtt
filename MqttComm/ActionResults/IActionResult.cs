namespace MqttComm.ActionResults
{
    public interface IActionResult<T>
    {
        T? Data { get; init; }

        bool IsSuccessfull { get; }
    }
}