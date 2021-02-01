using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ReportsGeneratorEngine.RabbitMQ
{
    public class RabbitProvider : IDisposable
    {
        private static RabbitProvider _instance = null;

        private IConnection              _connection;
        private IModel                   _channel;
        private RabbitConfigurationModel _rabbitConfig;

        private static class ExchangeType
        {
            public const string Direct  = "direct";
            public const string Fanout  = "fanout";
            public const string Headers = "headers";
            public const string Topic   = "topic";
        }

        protected RabbitProvider()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
        }

        public static RabbitProvider Build()
        {
            if (_instance == null)
            {
                _instance = new RabbitProvider().OneTimeSetup();
            }
            return _instance;
        }

        public RabbitProvider OneTimeSetup()
        {
            var configForError     = RabbitConfigurationModel.Factory.NewConfigurationForError();
            var configForException = RabbitConfigurationModel.Factory.NewConfigurationForException();

            this.WithConfiguration(configForError)
                .WithQueue()
                .WithExchange()
                .WithBind();

            this.WithConfiguration(configForException)
                .WithQueue()
                .WithExchange()
                .WithBind();

            return this;
        }

        public RabbitProvider WithConfiguration(RabbitConfigurationModel configuration)
        {
            _rabbitConfig = configuration;
            return this;
        }

        public RabbitProvider WithQueue()
        {
            _channel.QueueDeclare(queue: _rabbitConfig.Queue, durable: true, exclusive: false, autoDelete: false);
            return this;
        }

        public RabbitProvider WithExchange()
        {
            _channel.ExchangeDeclare(exchange: _rabbitConfig.Exchange, type: ExchangeType.Direct, durable: true, autoDelete: false);
            return this;
        }

        public RabbitProvider WithBind()
        {
            _channel.QueueBind(queue: _rabbitConfig.Queue, exchange: _rabbitConfig.Exchange, routingKey: _rabbitConfig.RoutingKey);
            return this;
        }

        public RabbitProvider Publish<T>(T message)
        {
            var byteMessage = ConvertMessageToByteArray(message);

            _channel.BasicPublish(exchange: _rabbitConfig.Exchange,
                                  routingKey: _rabbitConfig.RoutingKey,
                                  basicProperties: null,
                                  body: byteMessage);
            return this;
        }

        private byte[] ConvertMessageToByteArray<T>(T message)
        {
            var strMessage = "";

            if (message is string)
            {
                strMessage = (message as string);
            }
            else
            {
                strMessage = JsonConvert.SerializeObject(message);
            }
            return Encoding.UTF8.GetBytes(strMessage);
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
