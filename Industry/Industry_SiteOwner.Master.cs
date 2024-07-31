using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry
{
    public partial class Industry_SiteOwner : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               // GetContractorNotifications();
                if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null || Convert.ToString(Session["SiteOwnerId_Industry"]) != string.Empty || Request.Cookies["SiteOwnerId_Industry"] != null)
                {
                    if (Request.Cookies["SiteOwnerId_Industry"] != null)
                    {

                        //lblName.Text = Request.Cookies["SiteOwnerId_Industry"].Value;
                    }
                    else
                    {
                        //lblName.Text = Convert.ToString(Session["SiteOwnerId_Industry"]);
                    }
                }
                else if (Session["SiteOwnerId_Industry"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/IndustryServices.aspx");
                }
                else
                {

                    Session["SiteOwnerId_Industry"] = "";
                    Response.Redirect("/IndustryServices.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["SiteOwnerId_Industry"] = "";
                Response.Redirect("/IndustryServices.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["SiteOwnerId_Industry"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Industry/IndustryServices.aspx");
        }
    }
}