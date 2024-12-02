using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class LiftPeriodic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        GridBind();
                    }
                }
            }
            catch
            { }
        }

        private void GridBind()
        {
            throw new NotImplementedException();
        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/LiftPeriodicRenewal.aspx", false);
        }
    }
}