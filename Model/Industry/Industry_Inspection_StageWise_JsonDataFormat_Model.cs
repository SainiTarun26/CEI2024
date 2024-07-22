using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class Industry_Inspection_StageWise_JsonDataFormat_Model
    {
        public string actionTaken { get; set; }
        public string commentByUserLogin { get; set; } // Name of Person taken Action
        public DateTime commentDate { get; set; } // application approved date
        public string comments { get; set; } // Clearnace Comments, if any
        public string id { get; set; } // // Leave it blank
        public string projectid { get; set; }  // projectid of user
        public string serviceid { get; set; } // serviceid of user
    }
}