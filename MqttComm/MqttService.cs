using Microsoft.Extensions.Logging;
using MqttComm.ActionResults;
using MqttComm.Subscriptions;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using System.Text;

namespace MqttComm
{
    /// <summary>
    /// Default implementation of <see cref="IMqttService"/>.
    /// </summary>
    public class MqttService : IMqttService
    {
        private readonly IManagedMqttClient client;
        private readonly ILogger<IMqttService> logger;
        private readonly string brokerAddress;
        private readonly string userName;
        private readonly string password;

        private readonly Guid clientId = Guid.NewGuid();
        private IEnumerable<ISubscription> subscriptions;

        /// <summary>
        /// Instantiate a <see cref="MqttService"/>.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use.</param>
        /// <param name="brokerAddress">The address of the broker.</param>
        /// <param name="userName">The user name to use to connect to the broker.</param>
        /// <param name="password">The password to use to connect to the broker.</param>
        public MqttService(
            ILogger<IMqttService> logger,
            string brokerAddress,
            string userName,
            string password)
        {
            this.logger = logger;
            this.brokerAddress = brokerAddress;
            this.userName = userName;
            this.password = password;
            subscriptions = Enumerable.Empty<ISubscription>();
            client = new MqttFactory().CreateManagedMqttClient();
            client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
            client.ConnectedAsync += Client_ConnectedAsync;
            client.ConnectingFailedAsync += Client_ConnectingFailedAsync;
            StartClient();
        }

        private Task Client_ConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            return Task.Run(() =>
            {
                logger.LogError("Client connection failed!");
            });
        }

        private Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            return Task.Run(() => logger.LogDebug("Client connected!"));
        }

        private Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg) =>
            Task.Run(() =>
                {
                     var actions = subscriptions
                    .Where(x => x.Topic == arg.ApplicationMessage.Topic)
                    .Select(x => x.OnReceive);

                    foreach (var action in actions)
                    {
                        Task.Run(() => action(Encoding.Default.GetString(arg.ApplicationMessage.Payload ?? Array.Empty<byte>())));
                    }
                });

        /// <inheritdoc/>
        public async Task SubscribeAsync(string topic, Action<string> onReceive)
        {
            await client.SubscribeAsync(topic);
            subscriptions = subscriptions
                .Append(new Subscription(
                    topic: topic,
                    onReceive: onReceive));
            logger.LogDebug($"Subscribed on topic {topic}");
        }

        /// <inheritdoc/>
        public async Task UnSubscribeAsync(string topic)
        {
            await client.UnsubscribeAsync(topic);
            subscriptions = subscriptions
                .Where(s => s.Topic != topic);
            logger.LogDebug($"Unsubscribed from topic {topic}");
        }

        /// <inheritdoc/>
        public async Task<ActionResult<string>> PublishAsync(string topic, string message)
        {
            var managedMessage = new ManagedMqttApplicationMessageBuilder()
                .WithApplicationMessage(x =>
                    x.WithTopic(topic)
                   .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                   .WithPayload(Encoding.UTF8.GetBytes(message))
                   .Build())
                .Build();

            if (managedMessage != null)
            {
                await client.EnqueueAsync(managedMessage);
                logger.LogDebug($"Queued message with topic {topic}, {client.PendingApplicationMessagesCount} messages in queue.");
                return new ActionResult<string>($"Message builded with topic {topic}!");
            }

            logger.LogDebug($"Message build and publish failed with payload '{message}' on topic '{topic}'");
            return new ActionResult<string>(
                new InvalidOperationException($"Message build and publish failed with payload '{message}' on topic '{topic}'"));
        }

        private async void StartClient()
        {
            var options = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(new MqttClientOptionsBuilder()
                    .WithClientId(clientId.ToString())
                    .WithTcpServer(brokerAddress)
                    .WithCredentials(userName, password)
                    .Build())
                .Build();

            await client.StartAsync(options);
        }
    }
}
