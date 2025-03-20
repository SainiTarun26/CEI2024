using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
           Session["Username"] = null;
            Session["AdminID"] = null;
            Session["ContractorID"] = null;
            Session["SupervisorID"] = null;
            Session["SiteOwnerId"] = null;
            Session["StaffID"] = null;
            Session["NewUserId"] = null;
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            //if (Request.Cookies["ASP.NET_SessionId"] != null)
            //{
            //    HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            //    sessionCookie.Expires = DateTime.Now.AddDays(-30); // Expire the cookie
            //    Response.Cookies.Add(sessionCookie);
            //}
            //if (Request.Cookies["UserActiveSession"] != null)
            //{
            //    HttpCookie userSessionCookie = new HttpCookie("UserActiveSession", "");
            //    userSessionCookie.Expires = DateTime.Now.AddDays(-30);
            //    Response.Cookies.Add(userSessionCookie);
            //}
            Response.Write("<script> window.close(); localStorage.removeItem('activeSession'); sessionStorage.clear(); window.close();</script>");
            Response.Redirect("https://www.google.com", false);

            
           // Response.Redirect("Login.aspx", false);
            
        }
    }
}