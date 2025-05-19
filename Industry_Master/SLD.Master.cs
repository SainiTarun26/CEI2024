using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class SLD : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId_Sld_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Industry"]) != string.Empty)
            {
                //New Session Making Null 
                Session["SiteOwnerId_Sld_Indus"] = null;
                Session["Serviceid_New_Temp"] = null;
                Session["projectid_New_Temp"] = null;

                //Periodic Session Making Null 
                Session["SiteOwnerId_Industry"] = null;
                Session["Serviceid_pd_Indus"] = null;
                Session["projectid_pd_Indus"] = null;
                #region code by aslam, 19-may-2025
                //LiftNew Session Making Null 
                Session["SiteOwnerId_IndustryLift"] = null;
                Session["Serviceid_IndustryLift"] = null;
                Session["projectid_IndustryLift"] = null;
                #endregion
            }
        }

    }
}