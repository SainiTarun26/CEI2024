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
    public partial class DistrictData : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string Division = string.Empty;
        string dated = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDaysGridView();
            }
        }
        private void BindDaysGridView()
        {
            try
            {
                dated = Session["Days"].ToString();
                Division = Session["StaffID"].ToString();
                string District = Session["DistrictOfData"].ToString();
                DataTable ds = new DataTable();
                ds = cei.ShowPendingDivisionDaysData(dated, Division, District);
                if (ds.Rows.Count > 0)
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                }
            }
            catch (Exception)
            {
            }
        }
        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            //BindGridView();
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
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
                    Response.Redirect("/Officers/Inspection.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/Officers/OfficerDashboard.aspx");
            }
            catch
            {

            }
        }
    }
}