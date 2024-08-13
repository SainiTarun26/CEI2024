using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class Officers : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                {
                    lblName.Text = Convert.ToString(Session["StaffID"]);
                    PersonDetails.Text = lblName.Text.Trim();
                }
                else if (Session["StaffID"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/Login.aspx");
                }
                else
                {

                    Session["StaffID"] = "";
                    Response.Redirect("/Login.aspx");
                }
            }
            catch
            {
                Session["StaffID"] = "";
                Response.Redirect("/Login.aspx");
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Login.aspx");
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string StaffId = Session["StaffID"].ToString();
            Response.Redirect("/ChangePassword.aspx");
        }
    }
}