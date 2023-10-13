﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class GeneratingSet : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridData();
            }
        }

        protected void GridData()
        {
            string LoginID = string.Empty;
            LoginID = Session["AdminID"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.TestReportGeneratingData(LoginID);
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                string id = lblID.Text;
                Session["GeneratingSetId"] = id;
                Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                string IntimationId = lblIntimationId.Text;
                Session["IntimationId"] = IntimationId;
                Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                Session["InspectionType"] = lblInspectionType.Text;
                Label lblApplicantType = (Label)row.FindControl("lblApplicantType");
                Session["ApplicantType"] = lblApplicantType.Text;
                Label lblVoltage = (Label)row.FindControl("lblVoltage");
                Session["Voltage"] = lblVoltage.Text;
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx");

                }
            }
        }
    }
}