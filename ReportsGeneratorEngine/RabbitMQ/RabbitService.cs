using System;
using System.IO;
using System.Text.Json;

namespace ReportsGeneratorEngine.RabbitMQ
{
    public interface IRabbitService : IDisposable
    {
        IRabbitService WithConfiguration(RabbitConfigurationModel configuration);
        void SendMessage<T>(T message);
    }

    public class RabbitService : IRabbitService
    {
        private readonly RabbitProvider _rabbitMqProvider;

        public RabbitService()
        {
            _rabbitMqProvider = RabbitProvider.Build();
        }

        public IRabbitService WithConfiguration(RabbitConfigurationModel configuration)
        {
            _rabbitMqProvider.WithConfiguration(configuration);
            return this;
        }

        public void SendMessage<T>(T message)
        {
            _rabbitMqProvider.Publish(message);
        }

        public void Dispose()
        {
            _rabbitMqProvider?.Dispose();
        }
    }
}
