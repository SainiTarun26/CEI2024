using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
	public partial class SupervisorGeneraterSetTestReport : System.Web.UI.Page
	{
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridviewBind();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void GridviewBind()
        {
            string LoginId = string.Empty;
            LoginId = Session["SupervisorID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.GetGeneraterSetData(LoginId);
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "serverScript", script, true);
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
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text;
                Session["Approval3"] = lblApproval.Text;
                Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                Session["TestReportId"] = lblTestReportId.Text;
                if (e.CommandName == "Select")
                {

                    if (lblApproval.Text.Trim() == "Reject")
                    {
                        Response.Redirect("/TestReport/GeneratingSetTestReport.aspx");
                    }
                    else
                    {
                        Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx");
                    }
                    //Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx");
                }
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searhterm = txtSearch.Text.Trim();
            string LoginId = string.Empty;
            LoginId = Session["SupervisorID"].ToString();

            DataSet ds = new DataSet();
            ds = cei.SearchingOnGeneraterSet(searhterm, LoginId);
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                string script = "alert(\"No Record Match\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "Server Script", script, true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridviewBind();
        }
    }
}