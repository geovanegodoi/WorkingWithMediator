using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Models;
using ReportsGeneratorEngine.Notifications;

namespace ReportsGeneratorEngine.Requests.Handlers
{
    public class GenerateReportHandler : AsyncRequestHandler<GenerateReportRequest>
    {
        private readonly IMediator   _mediator;
        private readonly IRepository _repository;

        public GenerateReportHandler(IMediator mediator, IRepository repository)
        {
            _mediator   = mediator;
            _repository = repository;
        }

        protected async override Task Handle(GenerateReportRequest request, CancellationToken cancellationToken)
        {
            var notification = new ReportGeneratedNotification();

            try
            {
                var dataTable = await _repository.RunQueryAsync(request.Query);

                var report = new ReportModel(dataTable);

                notification.WithReport(report).WithSuccess();
            }
            catch (Exception ex)
            {
                notification.WithExcetion(ex);
            }
            finally
            {
                await _mediator.Publish(notification);
            }
        }
    }
}
