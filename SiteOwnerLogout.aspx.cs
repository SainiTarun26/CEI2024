using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class SiteOwnerLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["SiteOwnerId"] = "";
            Session["HighestVoltage"] = "";
            Session["CartID"] = "";
            Session["TotalCapacity"] = "";
            Session["FinalAmount"] = "";
           // Session["SelectedCartID"] = "";


            Session["IDCart"] = "";
            Session["CartID"] = "";
            Session["NewInspectionId"] = "";
            Session["ServiceType"] = ""; ///
            Session["LineID"] = "";
            Session["SubStationID"] = "";
            Session["GeneratingSetId"] = "";
            Session["SwitchingSubstationId"] = "";
            Session.Abandon();
            Session.Clear();
            string script = "alert('Session has been expired.'); window.location.href='/Login.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionExpired", script, true);

        }
    }
}