using System;

namespace CEIHaryana.Wiremen
{
    public partial class Wiremen : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["WiremanId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/SupervisorLogout.aspx");
        }
    }
}