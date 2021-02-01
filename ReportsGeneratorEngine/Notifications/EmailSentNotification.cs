using System;
using MediatR;
using ReportsGeneratorEngine.Models;

namespace ReportsGeneratorEngine.Notifications
{
    public class EmailSentNotification : NotificationBase
    {
        public EmailModel Email { get; private set; }

        public EmailSentNotification() {}

        public EmailSentNotification(EmailModel email)
        {
            Email = email;
        }

        public EmailSentNotification WithEmail(EmailModel email)
        {
            Email = email;
            return this;
        }
    }
}
