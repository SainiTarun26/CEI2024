using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class TokenManagerException : Exception
    {
        public string RequestUrl { get; }
        public string RequestMethod { get; }
        public string RequestHeaders { get; }
        public string RequestContentType { get; }
        public string RequestBody { get; }
        public string ResponseStatusCode { get; }
        public string ResponseHeaders { get; }
        public string ResponseBody { get; }

        public TokenManagerException(string message, string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody) : base(message)
        {
            RequestUrl = requestUrl;
            RequestMethod = requestMethod;
            RequestHeaders = requestHeaders;
            RequestContentType = requestContentType;
            RequestBody = requestBody;
            ResponseStatusCode = responseStatusCode;
            ResponseHeaders = responseHeaders;
            ResponseBody = responseBody;
        }
    }

}