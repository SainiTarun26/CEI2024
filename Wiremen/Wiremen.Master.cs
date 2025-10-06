using CEI_PRoject;
using System;

namespace CEIHaryana.Wiremen
{
    public partial class Wiremen : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["WiremanId"]) != null || Convert.ToString(Session["WiremanId"]) != string.Empty || Request.Cookies["WiremanId"] != null)
            {
                string UserId = Convert.ToString(Session["WiremanId"]);
                bool showGetLicence = CEI.Get_RegistrationIdExistForShowingLink(UserId);
                UserCurrent_Licence_Link.Visible = showGetLicence;
            }
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