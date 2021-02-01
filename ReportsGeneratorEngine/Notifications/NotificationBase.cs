using System;
using MediatR;

namespace ReportsGeneratorEngine.Notifications
{
    public abstract class NotificationBase : INotification
    {
        private bool _success = false;

        public string Message { get; private set; } = string.Empty;
        public Exception Exception { get; private set; } = null;

        public bool HasSuccess() => _success;

        public bool HasError() => !_success;

        public bool HasException() => Exception != null;

        public void WithSuccess() => _success = true;

        public void WithError() => _success = false;

        public void WithSuccess(string message)
        {
            WithSuccess();
            Message = message;
        }

        public void WithError(string error)
        {
            WithError();
            Message = error;
        }

        public void WithExcetion(Exception ex)
        {
            WithError();
            Exception = ex;
        }
    }
}
