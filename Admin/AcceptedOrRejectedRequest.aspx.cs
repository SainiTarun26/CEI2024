﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class AcceptedOrRejectedRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "Admin / Dashboard / Approved / Rejected / Return Requests";
                    }

                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    { }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private void GridBind()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                LoginId = Convert.ToString(Session["AdminId"]);
                DataSet ds = new DataSet();
                ds = CEI.AcceptedOrRejectedRequestInspectionForAdmin(LoginId);
                if (ds.Tables.Count > 0)
                {
                    DataTable ftrtbs = CEI.Grddtl(searchText, ds, "id");
                    if (ftrtbs.Rows.Count > 0)
                    {
                        GridView1.DataSource = ftrtbs;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        string script = "alert(\"No Record Found\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
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
            catch (Exception ex)
            {
                //throw;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select" || e.CommandName == "Print")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                string id = lblID.Text;
                Session["InspectionId"] = id;
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/Admin/InspectionDetails.aspx", false);
                }
                else if (e.CommandName == "Print")
                {
                    if (LblInspectionType.Text == "New")
                    {
                        Session["InProcessInspectionId"] = id;
                        Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                    }
                    else
                    {
                        Session["InProcessInspectionId"] = id;
                        Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                if (applicationStatus == "Approved")
                {

                    linkButton.Visible = true;
                }
                else
                {

                    linkButton.Visible = false;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            GridBind();
        }
    }
}
