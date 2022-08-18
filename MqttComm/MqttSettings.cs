namespace MqttComm;

/// <summary>
/// Class to retrieve configuration values from a json file.
/// </summary>
public class MqttSettings
{
    /// <summary>
    /// Gets or sets the broker address.
    /// </summary>
    public string BrokerAddress { get; set; }

    /// <summary>
    /// Gets or sets the user name to use to connect to the broker.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the password to use to connect to the broker.
    /// </summary>
    public string Password { get; set; }
}