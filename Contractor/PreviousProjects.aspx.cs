﻿using CEI_PRoject;
using System;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class PreviousProjects : System.Web.UI.Page
    {
        CEI cei = new CEI();
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
                        loginTypeLabel.Text = "Contractor / WorkIntimation History";
                    }

                    if (Session["ContractorID"] != null || Request.Cookies["ContractorID"] != null)
                    {
                        getWorkIntimationData();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/ContractorLogout.aspx");
            }
        }
        private void getWorkIntimationData()
        {
            string LoginID = string.Empty;
            LoginID = Session["ContractorID"].ToString();
            DataTable ds = new DataTable();
            ds = cei.WorkIntimationData(LoginID);
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
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    string id = lblID.Text;
                    Session["id"] = id;
                    if (e.CommandName == "Select")
                    {
                        //Session["id"] = ID;
                        Response.Redirect("/Contractor/WorkIntimationDetails.aspx");
                    }
                    else
                    {

                    }

                }
                if (e.CommandName == "Print")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    string id = lblID.Text;
                    Session["id"] = id;
                    Response.Redirect("/Contractor/Upgratation_WorkIntimation.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (ThreadAbortException)
            { }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                getWorkIntimationData();
            }
            catch 
            {
                
            }
        }
    }
}