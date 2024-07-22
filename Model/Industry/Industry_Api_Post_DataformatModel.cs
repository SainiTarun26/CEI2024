using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class Industry_Api_Post_DataformatModel
    {
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

    }
}