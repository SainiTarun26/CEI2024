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
    public partial class ConsolidatedReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    AllDataGrid();
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
                DdlDivision.DataTextField = "HeadOffice";
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

        private void DdlBindStaffPendingWith(string Division)
        {

            try
            {
                DataSet dsStaff = new DataSet();
                dsStaff = CEI.GetStaffDetailsDropDown(Division);
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

        private void AllDataGrid()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["StaffID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.StaffLogin(LoginID);
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
        private void BindGrid()
        {
            try
            {
                //Using Ternary operator In case value 0 then pass null
                string submittedDate = string.IsNullOrEmpty(txtSubmitted.Text.Trim()) ? null : txtSubmitted.Text.Trim();
                string endDate = string.IsNullOrEmpty(txtEndDate.Text.Trim()) ? null : txtEndDate.Text.Trim();
                string division = DdlDivision.SelectedValue == "0" ? null : DdlDivision.SelectedValue;
                string district = DdlDistrict.SelectedValue == "0" ? null : DdlDistrict.SelectedValue;
                string status = ddlStatus.SelectedValue == "0" ? null : ddlStatus.SelectedItem.ToString();
                string inspectionType = ddlInstallatiosType.SelectedValue == "0" ? null : ddlInstallatiosType.SelectedItem.ToString();
                string pendingWith = DdlStaffPendingWith.SelectedValue == "0" ? null : DdlStaffPendingWith.SelectedValue;
                string ownerApplication = string.IsNullOrEmpty(txtownerApplication.Text.Trim()) ? null : txtownerApplication.Text.Trim();
                string gstNumber = string.IsNullOrEmpty(txtGST.Text.Trim()) ? null : txtGST.Text.Trim();
                string LoginId = Session["StaffID"].ToString();
                // DataSet ds = new DataSet();
                DataSet ds = CEI.ConsolidateSearchData(submittedDate, endDate, division, district, status, inspectionType, pendingWith,
                    ownerApplication, gstNumber, LoginId);
                if (ds != null && ds.Tables.Count > 0)
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
            ddlLoadBindDistrict(DdlDivision.SelectedValue);

            DdlBindStaffPendingWith(DdlDivision.SelectedValue);
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

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtSubmitted.Text = "";
                txtEndDate.Text = "";
                DdlDivision.SelectedValue = "0";
                DdlDistrict.SelectedValue = "0";
                ddlStatus.SelectedValue = "0";
                ddlInstallatiosType.SelectedValue = "0";
                DdlStaffPendingWith.SelectedValue = "0";
                txtownerApplication.Text = "";
                txtGST.Text = "";
            }
            catch { }
        }
        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}