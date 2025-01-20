using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class PeriodicInspection : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblName.Text = Session["SiteOwnerId_Industry"].ToString();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != string.Empty)
            {
                //New Session Making Null 
                Session["SiteOwnerId_Sld_Indus"] = null;
                Session["Serviceid_New_Temp"] = null;
                Session["projectid_New_Temp"] = null;

                //SLD Session Making Null 
                Session["SiteOwnerId_Sld_Industry"] = null;
                Session["Serviceid_Sld_Indus"] = null;
                Session["projectid_Sld_Indus"] = null;
            }

        }

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //    Response.Cookies["SiteOwnerId_Industry"].Expires = DateTime.Now.AddDays(-1);
        //    Response.Redirect("/Login.aspx");
        //}
    }
}