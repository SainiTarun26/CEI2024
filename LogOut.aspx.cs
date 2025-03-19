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
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId", "");
                sessionCookie.Expires = DateTime.Now.AddDays(-30); // Expire the cookie
                Response.Cookies.Add(sessionCookie);
            }
            if (Request.Cookies["UserActiveSession"] != null)
            {
                HttpCookie userSessionCookie = new HttpCookie("UserActiveSession", "");
                userSessionCookie.Expires = DateTime.Now.AddDays(-30);
                Response.Cookies.Add(userSessionCookie);
            }
            Response.Write("<script>localStorage.removeItem('activeSession'); sessionStorage.clear(); window.location='Login.aspx';</script>");
            Response.End();
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                     process.Kill();
                }
            }
            Response.Redirect("Login.aspx", false);
            
        }
    }
}