using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class TestHistoryReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    BindGridView();
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
        }
        private void BindGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.TestReportDataForAdmin();
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    string script = "alert(\"No Data Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), " script", script, true);
                }
            }
            catch (Exception ex)
            {

                //throw;
            }



        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblId = (Label)row.FindControl("lblId");
                string id = lblId.Text;
                Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                Session["TestReportId"] = lblTestReportId.Text; 
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval1"] = lblApproval.Text;
                Session["Approval"] = lblApproval.Text;
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/TestReport/TestReport.aspx", false);
                }
            }
        }
    }
}