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

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //    Response.Cookies["SiteOwnerId_Industry"].Expires = DateTime.Now.AddDays(-1);
        //    Response.Redirect("/Login.aspx");
        //}
    }
}