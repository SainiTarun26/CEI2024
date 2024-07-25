using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OfficeOpenXml;

namespace CEIHaryana.Admin
{
    public partial class Consolidated_Report : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["AdminID"].ToString() != null && Session["AdminID"].ToString() != "")
                    {

                        string LoginId = Session["AdminID"].ToString();
                        AllDataGrid();
                        DdlDivisionData();
                    }
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
              
                DataTable ds = new DataTable();
                ds = CEI.InspectionHistoryForAdminData(LoginId);
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
                string LoginId = Session["AdminID"].ToString().Trim();
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
               // ds.Dispose();
            }
            catch 
            {
            }
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
            else if (installationType.Trim() == "Generating Set")
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    DataTable ds = CEI.InspectionHistoryForAdminData(LoginId);

                    //custom header names
                    Dictionary<string, string> columnHeadersMapping = new Dictionary<string, string>
             {
             {"ApplicationForInspection", " Application For Inspection"},
             {"Createddate1", "Application Date"},
             {"Installationfor", "Installation Applied For"},
             {"Id", "Owner Application Number"},
             {"AcceptedOrRejected", "Status"},
             {"AssignedStaff", "Pending With"}
             };

                    // List of specific columns to export
                    List<string> columnsToExport = new List<string>(columnHeadersMapping.Keys);
                    if (ds.Rows.Count > 0)
                    {
                        // Add header row with custom header names for specific columns
                        int col = 1;
                        foreach (string columnName in columnsToExport)
                        {
                            worksheet.Cells[1, col].Value = columnHeadersMapping[columnName];
                            col++;
                        }

                        // Add data rows for specific columns
                        int row = 2;
                        foreach (DataRow dataRow in ds.Rows)
                        {
                            col = 1;
                            foreach (string columnName in columnsToExport)
                            {
                                if (ds.Columns.Contains(columnName))
                                {
                                    worksheet.Cells[row, col].Value = dataRow[columnName];
                                }
                                else
                                {
                                    // Handle the case where the specified column is not found in the DataTable
                                    worksheet.Cells[row, col].Value = DBNull.Value;
                                }
                                col++;
                            }
                            row++;
                        }

                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=CONSOLIDATEDREPORT.xlsx");
                        Response.BinaryWrite(package.GetAsByteArray());
                        Response.Flush();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        string script = "alert(\"No Record Found\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                }

            }
            catch
            {
            }
        }

        private void ExportToExcel()
        {

            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "ConsolidatedReport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Response.ContentType = "application/ms-excel";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        // Create a form to contain the grid
                        HtmlForm frm = new HtmlForm();
                        GridView1.Parent.Controls.Add(frm);
                        frm.Attributes["runat"] = "server";
                        frm.Controls.Add(GridView1);
                        frm.RenderControl(htw);

                        // End the HTML response and output to the browser
                        Response.Write(sw.ToString());
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}