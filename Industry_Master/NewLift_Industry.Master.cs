using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master.SiteOwner_Industry
{
    public partial class NewLift_Industry : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblName.Text = Session["SiteOwnerId_IndustryLift"].ToString();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
                return;
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != null && Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != string.Empty)
            {
                //New Session Making Null 
                Session["SiteOwnerId_Sld_Indus"] = null;
                Session["Serviceid_New_Temp"] = null;
                Session["projectid_New_Temp"] = null;

                //SLD Session Making Null 
                Session["SiteOwnerId_Sld_Industry"] = null;
                Session["Serviceid_Sld_Indus"] = null;
                Session["projectid_Sld_Indus"] = null;

                //Periodic Session Making Null 
                Session["SiteOwnerId_Industry"] = null;
                Session["Serviceid_pd_Indus"] = null;
                Session["projectid_pd_Indus"] = null;
            }

        }
    }
}