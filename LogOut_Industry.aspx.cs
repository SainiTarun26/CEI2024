using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class LogOut_Industry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            Response.Write("<script> window.close(); localStorage.removeItem('activeSession'); sessionStorage.clear(); window.close();</script>");
            Response.Redirect("https://staging.investharyana.in/#/", false);

        }
    }
}