using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ProcessInspectionRenewalCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Request.Cookies["SiteOwnerId"] != null)
                    {
                        getInspectionData();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }
        }

        private void getInspectionData()
        {
            try
            {

            }
            catch { }
        }
    }
}