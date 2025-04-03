using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class AdminLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AdminId"] = "";
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Session["Username"] = null;
            Session["AdminID"] = null;
            Session["ContractorID"] = null;
            Session["SupervisorID"] = null;
            Session["SiteOwnerId"] = null;
            Session["StaffID"] = null;
            Session["NewUserId"] = null;
            Session["ID"] = "";
            Session["LineID"] = "";
            Session["SubStationID"] = "";
            Session["GeneratingSetId"] = "";
            Session["PeriodicMultiple"] = "";
        }
    }
}