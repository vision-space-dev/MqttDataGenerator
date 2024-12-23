using System;
using System.Threading;
using MQTTnet;
using MQTTnet.Client;
using System.Threading.Tasks;

namespace MqttSender.service
{

    internal class MqttPublisher
    {
        private IMqttClient _mqttClient;

        public MqttPublisher()
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
        }
        
        public async Task ConnectAsync(string brokerHost, int brokerPort, string clientId,
            bool withTls = false, string username = null, string password = null,
            int timeoutMilliseconds = 2000)
        {
            var optionsBuilder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(brokerHost, brokerPort)
                .WithCleanSession();

            if (withTls)
            {
                // Correctly configure TLS options
                optionsBuilder.WithTlsOptions(tlsOptions =>
                {
                    tlsOptions.UseTls(); // Enable TLS
                });
            }

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                optionsBuilder.WithCredentials(username, password);
            }

            var options = optionsBuilder.Build();

            using (var cts = new CancellationTokenSource(timeoutMilliseconds))
            {
                try
                {
                    await _mqttClient.ConnectAsync(options, cts.Token);
                    Console.WriteLine("Connected to MQTT broker.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to MQTT broker: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task SendMessageAsync(string topic, string payload)
        {
            if (!_mqttClient.IsConnected)
            {
                throw new InvalidOperationException("MQTT client is not connected.");
            }

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await _mqttClient.PublishAsync(message);
            //Console.WriteLine($"Message published to topic {topic}: {payload}");
        }
        
        public async Task DisconnectAsync()
        {
            await _mqttClient.DisconnectAsync();
            Console.WriteLine("Disconnected from MQTT broker.");
        }
    }
}