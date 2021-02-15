using System;
using System.Net;

namespace ReportsGeneratorEngine.Models
{
    public class SalesforceResponse
    {
        public SalesforceResponse(HttpStatusCode httpCode)
        {
            HttpCode = httpCode;
        }

        public HttpStatusCode HttpCode { get; set; }
        public string Message { get; set; }
        public bool IsOk() => HttpCode == HttpStatusCode.OK;
    }
}
