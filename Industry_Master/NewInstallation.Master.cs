using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class Industry : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty)
            {
                //Periodic Session Making Null 
                Session["SiteOwnerId_Industry"] = null;
                Session["Serviceid_pd_Indus"] = null;
                Session["projectid_pd_Indus"] = null;


                //SLD Session Making Null 
                Session["SiteOwnerId_Sld_Industry"] = null;
                Session["Serviceid_Sld_Indus"] = null;
                Session["projectid_Sld_Indus"] = null;

                //LiftNew Session Making Null 
                Session["SiteOwnerId_IndustryLift"] = null;
                Session["Serviceid_IndustryLift"] = null;
                Session["projectid_IndustryLift"] = null;

                //Periodic Lift Session Making Null 
                Session["SiteOwnerId_PeriodicIndustryLift"] = null;
                Session["Serviceid_PeriodicIndustryLift"] = null;
                Session["projectid_PeriodicIndustryLift"] = null;
            }

        }
    }
}