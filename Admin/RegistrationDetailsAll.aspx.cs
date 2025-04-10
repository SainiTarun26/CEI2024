﻿using CEI_PRoject;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class RegistrationDetailsAll1 : System.Web.UI.Page
    {
        // string registrationId = "";
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    getRegistrationDetails();
                    getRegistrationDetailsWirmen();
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            catch
            {
                Response.Redirect("/AdminLogout.aspx");
            }
        }
        private void getRegistrationDetails()
        {
            DataTable ds = new DataTable();
            ds = cei.RegistrationDetails();
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        private void getRegistrationDetailsWirmen()
        {
            DataTable ds = new DataTable();
            ds = cei.WirmenRegistrationDetails();
            if (ds.Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string registrationId = e.CommandArgument.ToString();
                Session["registrationId"] = registrationId;
                Response.Redirect("RegistrationDetailsSelected.aspx");

            }
            else if (e.CommandName == "Drop")
            {
                try
                {
                    string registrationId = e.CommandArgument.ToString();

                    if (int.TryParse(registrationId, out int parsedRegistrationId))
                    {
                        int ivalue = CEI.DropRegistrationData(parsedRegistrationId);

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }

            }
        }



    }
}