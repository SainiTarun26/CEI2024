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
    public partial class Consolidated_Report : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string submittedDate = string.Empty;
        string EndDate = string.Empty;
        string Division = string.Empty;
        string District = string.Empty;
        string Status = string.Empty;
        string InspectionType = string.Empty;
        string PendingWith = string.Empty;
        string OwnerApplication = string.Empty;
        string GSTNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    DdlBindStaffPendingWith();
                    DdlDivisionData();
                }
            }
            catch
            {

            }
        }

        private void DdlDivisionData()
        {
            try
            {
                DataSet dsStaff = new DataSet();
                dsStaff = CEI.GetDdlDivisionData();
                DdlDivision.DataSource = dsStaff;
                DdlDivision.DataTextField = "Area";
                DdlDivision.DataValueField = "Area";
                DdlDivision.DataBind();
                DdlDivision.Items.Insert(0, new ListItem("Select", "0"));
                dsStaff.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        private void DdlBindStaffPendingWith()
        {

            try
            {
                DataSet dsStaff = new DataSet();
                dsStaff = CEI.GetStaffDetailsDropDown();
                DdlStaffPendingWith.DataSource = dsStaff;
                DdlStaffPendingWith.DataTextField = "StaffAssigned";
                DdlStaffPendingWith.DataValueField = "StaffUserId";
                DdlStaffPendingWith.DataBind();
                DdlStaffPendingWith.Items.Insert(0, new ListItem("Select", "0"));
                dsStaff.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }


        private void BindGrid()
        {
            try
            {
                string submittedDate = string.IsNullOrEmpty(txtSubmitted.Text.Trim()) ? null : txtSubmitted.Text.Trim();
                string endDate = string.IsNullOrEmpty(txtEndDate.Text.Trim()) ? null : txtEndDate.Text.Trim();
                string division = DdlDivision.SelectedValue == "0" ? null : DdlDivision.SelectedValue;
                string district = DdlDistrict.SelectedValue == "0" ? null : DdlDistrict.SelectedValue;
                string status = ddlStatus.SelectedValue == "0" ? null : ddlStatus.SelectedItem.ToString();
                string inspectionType = ddlInstallatiosType.SelectedValue == "0" ? null : ddlInstallatiosType.SelectedItem.ToString();
                string pendingWith = DdlStaffPendingWith.SelectedValue == "0" ? null : DdlStaffPendingWith.SelectedValue;
                string ownerApplication = string.IsNullOrEmpty(txtownerApplication.Text.Trim()) ? null : txtownerApplication.Text.Trim();
                string gstNumber = string.IsNullOrEmpty(txtGST.Text.Trim()) ? null : txtGST.Text.Trim();
                DataSet ds = new DataSet();
                 ds = CEI.ConsolidateSearchData(submittedDate, endDate, division, district, status, inspectionType, pendingWith,
                    ownerApplication, gstNumber);
                if (ds.Tables.Count > 0)
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

        protected void DdlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindDistrict(DdlDivision.SelectedItem.ToString());
        }

        private void ddlLoadBindDistrict(string Area)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddldistrictfromDivision(Area);
                DdlDistrict.DataSource = dsDistrict;
                DdlDistrict.DataTextField = "AreaCovered";
                DdlDistrict.DataValueField = "AreaCovered";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch { }
        }
    }
}