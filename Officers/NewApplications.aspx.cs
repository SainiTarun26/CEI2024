using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class NewApplications : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        //string LoginID = string.Empty;
        string TypeOfInspection = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        //LoginID = Session["StaffID"].ToString();
                        //GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }

        }
        public void GridBind()
        {

            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.NewRequestRecieved(LoginID, TypeOfInspection);
            if (ds.Tables.Count > 0 && ds != null)
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
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Session["InspectionId"] = id;
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/Officers/Inspection.aspx", false);
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "0")
            {
                TypeOfInspection = "New";
                GridBind();
            }
            else if (RadioButtonList1.SelectedValue == "1")
            {
                TypeOfInspection = "Periodic";
                GridBindPeriodic();
            }
        }

        private void GridBindPeriodic()
        {
            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataSet dsp = new DataSet();
            dsp = CEI.NewRequestRecievedAsPeriodic(LoginID, TypeOfInspection);
            if (dsp.Tables.Count > 0 && dsp != null)
            {
                GridView2.DataSource = dsp;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dsp.Dispose();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    string id = lblID.Text;
                    Label lblApproval = (Label)row.FindControl("lblApproval");
                    Session["Approval"] = lblApproval.Text.Trim();
                    Session["InspectionId"] = id;
                    if (e.CommandName == "Select")
                    {
                        Response.Redirect("/Officers/Inspection.aspx", false);
                    }
                }
            }
            catch (Exception ex) { }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView2.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }
    }
}