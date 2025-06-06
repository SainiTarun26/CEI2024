﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class Self_CertificationStatus : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {

                        hnStaffId.Value = Session["StaffID"].ToString();
                        GridBind(hnStaffId.Value);

                    }
                    else
                    {
                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }
        public void GridBind(string StaffId)
        {
            try
            {
                DataTable dt = CEI.GetStatusSC(StaffId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Self-Certification requests have been submitted by any Site Owner.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                dt.Dispose();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Convert.ToString(hnStaffId.Value) == Convert.ToString(Session["StaffID"]))
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblSC_ID = (Label)row.FindControl("lblSC_ID");
                if (e.CommandName == "Select")
                {
                    Session["SC_Id"] = lblSC_ID.Text;
                    Response.Redirect("/Officers/Self_CertificationActionView.aspx", false);
                }
            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx");

            }
        }
    }
}