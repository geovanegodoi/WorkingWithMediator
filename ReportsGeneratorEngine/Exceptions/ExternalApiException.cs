using System;
namespace ReportsGeneratorEngine.Exceptions
{
    public class ExternalApiException : Exception
    {
        public ExternalApiException(string message = "") : base(message)
        { }

        public ExternalApiException(string message, Exception exception) : base(message, exception)
        { }
    }

}
