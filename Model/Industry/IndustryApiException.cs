using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class IndustryApiException : Exception
    {
        public string RequestUrl { get; }
        public string RequestMethod { get; }
        public string RequestHeaders { get; }
        public string RequestContentType { get; }
        public string RequestBody { get; }
        public string ResponseStatusCode { get; }
        public string ResponseHeaders { get; }
        public string ResponseBody { get; }

        public IndustryApiException(
            string message, string url, string method, string requestHeaders,
            string contentType, string requestBody, string responseStatusCode,
            string responseHeaders, string responseBody) : base(message)
        {
            RequestUrl = url;
            RequestMethod = method;
            RequestHeaders = requestHeaders;
            RequestContentType = contentType;
            RequestBody = requestBody;
            ResponseStatusCode = responseStatusCode;
            ResponseHeaders = responseHeaders;
            ResponseBody = responseBody;
        }
    }

}