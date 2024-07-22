using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class IndustryApiLogDetails
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string RequestHeaders { get; set; }
        public string ContentType { get; set; }
        public string RequestBody { get; set; }
        public string ResponseStatusCode { get; set; }
        public string ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }
        public string ErrorMessage { get; set; }
    }
}