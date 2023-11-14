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
    public partial class IntimationHistoryForAdmin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindGrid();
                }
            }
            catch
            {
            }
        }

        private void BindGrid()
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.InspectionHistoryForAdminData();
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
            catch { }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblID = (Label)row.FindControl("lblID");
            Session["InspectionId"] = lblID.Text;
            Label lblApproval = (Label)row.FindControl("lblApproval");
            Session["Approval"] = lblApproval.Text.Trim();
            Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
            string installationType = lblInstallationType.Text.Trim();
            Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
            string TestRportId = lblTestRportId.Text.Trim();
            if (installationType.Trim() == "Line")
            {
                Session["LineID"] = installationType;
            }
            else if (installationType.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = TestRportId;
            }
            else if (installationType.Trim() == "Generating Station")
            {
                Session["GeneratingSetId"] = TestRportId;
            }

            if (e.CommandName == "Select")
            {
                Response.Redirect("/Admin/IntimationForHistory.aspx");
            }
        }
    }
}