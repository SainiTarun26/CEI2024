using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CEIHaryana.ScannedDocuments
{
    public partial class ValidateCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Request.QueryString["ID"]) != null && Convert.ToString(Request.QueryString["ID"]) != "")// && Convert.ToString(Request.QueryString["RegistrationNo"]) != null && Convert.ToString(Request.QueryString["RegistrationNo"]) != "")
            {
                Redirectaccording();
               

            }
        }
        protected void Redirectaccording()
        {
            string id = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            string LiftTestReportID = Request.QueryString["LiftTestReportID"];

            Session["SiteOwnerId"] = "12345";
            Session["InspectionId"] = Convert.ToString(Request.QueryString["ID"]);
            if (LiftTestReportID!="" & LiftTestReportID!=null) 
            {
                Session["LiftTestReportID"] = Convert.ToString(Request.QueryString["LiftTestReportID"]);
            }
            string url = "https://uat.ceiharyana.com/" + name;
            Response.Redirect(url, false);
        }
    }
}