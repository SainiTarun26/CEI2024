using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CEIHaryana
{
    public partial class Industry_Sessions_Clear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Write("<script> window.close(); localStorage.removeItem('activeSession'); sessionStorage.clear(); window.close();</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
        }
    }
}