using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SiteOwner : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null || Convert.ToString(Session["SiteOwnerId"]) != string.Empty || Request.Cookies["SiteOwnerId"] != null)
                {
                    if (Request.Cookies["SiteOwnerId"] != null)
                    {

                        lblName.Text = Request.Cookies["SiteOwnerId"].Value;
                    }
                    else
                    {
                        lblName.Text = Convert.ToString(Session["SiteOwnerId"]);
                    }
                }
                else if (Session["SiteOwnerId"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/Login.aspx");
                }
                else
                {

                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["SiteOwnerId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }
    }
}