using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Registration1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                if (Convert.ToString(Session["SupervisorID"]) != null || Convert.ToString(Session["SupervisorID"]) != string.Empty)
                {

                    lblName.Text = Convert.ToString(Session["SupervisorID"]);
                }
                else if (Convert.ToString(Session["WiremanId"]) != null || Convert.ToString(Session["WiremanId"]) != string.Empty)
                {
                    lblName.Text = Convert.ToString(Session["WiremanId"]);
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Login.aspx");
        }
    }
}