using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class Industry_Inspection_StageWise_ReturnedJsonDataFormat_ViewModel
    {
        public string result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public WebHeaderCollection Headers { get; set; }
    }
}