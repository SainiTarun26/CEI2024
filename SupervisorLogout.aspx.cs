﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class SupervisorLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            //Response.Write("<script> window.close(); localStorage.removeItem('activeSession'); sessionStorage.clear(); window.close();</script>");
            // Response.Redirect("/Login.aspx", false);


        }
    }
}