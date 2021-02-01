using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Notifications;
using ReportsGeneratorEngine.RabbitMQ;

namespace ReportsGeneratorEngine.Requests.Handlers
{
    public class SendMessageRabbitHandler : AsyncRequestHandler<SendMessageRabbitRequest>
    {
        private readonly IRabbitService _rabbitService;
        private readonly ILogger _logger;

        public SendMessageRabbitHandler(IRabbitService rabbitService, ILogger logger)
        {
            _rabbitService = rabbitService;
            _logger = logger;
        }

        protected override Task Handle(SendMessageRabbitRequest request, CancellationToken cancellationToken)
        {
            // Recuperando configuracao de acordo com o tipo de notificao
            var configuration = GetConfigurationForNotification(request.Notification);

            // Recuperando a mensagem de acordo com tipo de notificação
            var message = GetMessageForNotification(request.Notification);

            // Se não encontrou nenhuma configuracao ou mensagem nem continua
            if (configuration == null || message == null) return Task.CompletedTask;

            // Enviando mensagem para a fila
            _rabbitService.WithConfiguration(configuration).SendMessage(message);

            // Logando que a mensagem foi envia para a fila
            _logger.Log("Mensagem foi enviada para a fila", message);

            return Task.CompletedTask;
        }

        private RabbitConfigurationModel GetConfigurationForNotification(NotificationBase notification)
        {
            if (notification.HasException())
            {
                return RabbitConfigurationModel.Factory.NewConfigurationForException();
            }
            else if (notification.HasError())
            {
                return RabbitConfigurationModel.Factory.NewConfigurationForError();
            }
            else
            {
                return null;
            }
        }

        private object GetMessageForNotification(NotificationBase notification)
        {
            if (notification.HasException())
            {
                return notification.Exception;
            }
            else if (notification.HasError())
            {
                return notification.Message;
            }
            else
            {
                return null;
            }
        }
    }
}
