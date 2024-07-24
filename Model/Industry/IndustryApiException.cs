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

        public string PremisesType { get; set; }
        public int InspectionId { get; set; }
        public int InspectionLogId { get; set; }
        public int IncomingJsonId { get; set; }
        public string ActionTaken { get; set; }
        public string CommentByUserLogin { get; set; }
        public DateTime CommentDate { get; set; }
        public string Comments { get; set; }
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string ServiceId { get; set; }

        public IndustryApiException(
            string message, string url, string method, string requestHeaders,
            string contentType, string requestBody, string responseStatusCode,
            string responseHeaders, string responseBody, string premisesType = null, int inspectionId = 0, int inspectionLogId = 0,
            int incomingJsonId = 0,
            string actionTaken = null,
            string commentByUserLogin = null,
            DateTime commentDate = default,
            string comments = null,
            string id = null,
            string projectId = null,
            string serviceId = null) : base(message)
        {
            RequestUrl = url;
            RequestMethod = method;
            RequestHeaders = requestHeaders;
            RequestContentType = contentType;
            RequestBody = requestBody;
            ResponseStatusCode = responseStatusCode;
            ResponseHeaders = responseHeaders;
            ResponseBody = responseBody;

            PremisesType = premisesType;
            InspectionId = inspectionId;
            InspectionLogId = inspectionLogId;
            IncomingJsonId = incomingJsonId;
            ActionTaken = actionTaken;
            CommentByUserLogin = commentByUserLogin;
            CommentDate = commentDate;
            Comments = comments;
            Id = id;
            ProjectId = projectId;
            ServiceId = serviceId;
        }
    }

}