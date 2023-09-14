using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class Supervisor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["AdminID"]) != null || Convert.ToString(Session["AdminID"]) != string.Empty || Request.Cookies["AdminID"] != null)
                {
                    if (Request.Cookies["AdminID"] != null)
                    {

                        lblName.Text = Request.Cookies["AdminID"].Value;
                    }
                    else
                    {
                        lblName.Text = Convert.ToString(Session["AdminID"]);
                    }
                }
                else if (Session["AdminID"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/Login.aspx");
                }
                else
                {

                    Session["AdminID"] = "";
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["AdminID"] = "";
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }
    }
}