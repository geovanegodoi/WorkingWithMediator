using System;
namespace ReportsGeneratorEngine.Exceptions
{
    public class SendEmailException : Exception
    {
        public SendEmailException(string message="") : base(message)
        {}

        public SendEmailException(string message, Exception exception) : base(message, exception)
        {}
    }

}
