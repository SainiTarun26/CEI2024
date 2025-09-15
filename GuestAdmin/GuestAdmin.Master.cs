using CEIHaryana.Industry_Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.GuestAdmin
{
    public partial class GuestAdmin : System.Web.UI.MasterPage
    {
            protected void Page_Load(object sender, EventArgs e)
            {
            try
            {
                if (Convert.ToString(Session["GuestAdmin"]) != null || Convert.ToString(Session["GuestAdmin"]) != string.Empty || Request.Cookies["GuestAdmin"] != null)
                {
                    if (Request.Cookies["GuestAdmin"] != null)
                    {

                        lblName.Text = Request.Cookies["GuestAdmin"].Value;


                    }
                    else
                    {
                        lblName.Text = Convert.ToString(Session["GuestAdmin"]);
                    }
                }
                else if (Session["GuestAdmin"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/GuestAdminLogout.aspx");
                }
                else
                {

                    Session["GuestAdmin"] = "";
                    Response.Redirect("/GuestAdminLogout.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["GuestAdmin"] = "";
                Response.Redirect("/GuestAdminLogout.aspx");
            }


            }
            protected void btnLogout_Click(object sender, EventArgs e)
            {
                Session.Abandon();
                Response.Cookies["GuestAdmin"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/GuestAdminLogout.aspx");
        }

            protected void BtnChangePassword_Click(object sender, EventArgs e)
            {
                string AdminId = Session["GuestAdmin"].ToString();
                Response.Redirect("/ChangePassword.aspx");
            }
        
    }
}