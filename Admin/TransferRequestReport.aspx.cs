using CEI_PRoject;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Admin
{
    public partial class TransferRequestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string InspectionId;
        string Status;
        DateTime? DateTo = null;
        DateTime? DateFrom = null;
        string Transfer;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        BindGrid();
                        BindDropDownToAssign();
                    }
                    else
                    {

                    }


                }
            }
            catch
            {

            }

        }

        private void BindDropDownToAssign()
        {
            try
            {
                DataSet dsAssign = new DataSet();
                dsAssign = CEI.DdlToTransferStaff();
                ddlTransferStaff.DataSource = dsAssign;
                ddlTransferStaff.DataTextField = "StaffUserId";
                ddlTransferStaff.DataValueField = "StaffUserId";
                ddlTransferStaff.DataBind();
                ddlTransferStaff.Items.Insert(0, new ListItem("Select", "0"));
                dsAssign.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        private void BindGrid()
        {
            try
            {

                DataTable ds = new DataTable();
                ds = CEI.GetTransferReport();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                BindGridAfterSearch();
            }
            catch
            {
            }


        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtInspection.Text = "";
            txtDateTo.Text = "";
            txtDateFrom.Text = "";
            ddlStatusWise.SelectedValue = "0";
            ddlTransferStaff.SelectedValue = "0";
            Session["Searched"] = "";
            BindGrid();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Print")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblType = (Label)row.FindControl("lblType");
                Session["Type"] = lblType.Text;
                Label lblApplicationStatus = (Label)row.FindControl("lblApplicationStatus");
                Session["lblApplicationStatus"] = lblType.Text;
                string id = lblID.Text;
                Session["InspectionId"] = id;

                if (lblApplicationStatus.Text == "Approved")
                {
                    if (lblType.Text == "New")
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
                else
                {
                    string script = "alert(\"This Record is not Approved. You can only Download Approved Reports\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                }
            }
            else
            {

            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            if (Session["Searched"] != null && Session["Searched"].ToString() == "true")
            {
                // If a search was performed, re-bind the grid using the search logic
                btnSearch_Click(sender, e);
            }
            else
            {
                // Otherwise, re-bind the grid with the default data
                BindGrid();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    DataTable ds;
                    if (string.IsNullOrEmpty(txtInspection.Text.Trim()))
                    {
                        InspectionId = null;
                    }
                    else
                    {
                        InspectionId = txtInspection.Text.Trim();

                    }
                    Status = ddlStatusWise.SelectedValue == "0" ? "" : ddlStatusWise.SelectedItem.ToString();
                    Transfer = ddlTransferStaff.SelectedValue == "0" ? "" : ddlTransferStaff.SelectedItem.ToString();

                    if (!string.IsNullOrEmpty(txtDateTo.Text.Trim()))
                    {
                        DateTime tempDateTo;
                        if (DateTime.TryParse(txtDateTo.Text.Trim(), out tempDateTo))
                        {
                            DateTo = tempDateTo;
                        }
                    }

                    if (!string.IsNullOrEmpty(txtDateFrom.Text.Trim()))
                    {
                        DateTime tempDateFrom;
                        if (DateTime.TryParse(txtDateFrom.Text.Trim(), out tempDateFrom))
                        {
                            DateFrom = tempDateFrom;
                        }
                    }

                    // Retrieve data based on session and procedure output
                    if (Session["Searched"] != null && !string.IsNullOrEmpty(Session["Searched"].ToString()))
                    {
                        ds = CEI.GetTransferSearchReport(DateFrom, DateTo, Transfer, Status, InspectionId);
                    }
                    else
                    {
                        ds = CEI.GetTransferReport();
                    }

                    // Log the number of rows to debug
                    System.Diagnostics.Debug.WriteLine($"Number of rows retrieved: {ds.Rows.Count}");

                    if (ds != null && ds.Rows.Count > 0)
                    {
                        Dictionary<string, string> columnHeadersMapping = new Dictionary<string, string>
                {
                    {"Id", "Inspection ID"},
                    {"Name", "SiteOwner Name"},
                    {"FirmName", "Contractor FirmName"},
                    {"TypeOfInstallations", "Type of Installation"},
                    {"Type", "Type(New/Periodic)"},
                    {"Capacity", "Capacity"},
                    {"CreatedDate", "Applied Date"},
                    {"TransferDate", "TransferDate"},
                    {"Transfer", "Transfer to"},
                    {"ApplicationStatus", "Current Status"},
                    {"PendingInDays", "PendingInDays"}
                };

                        List<string> columnsToExport = new List<string>(columnHeadersMapping.Keys);

                        // Add headers
                        int col = 1;
                        foreach (string columnName in columnsToExport)
                        {
                            worksheet.Cells[1, col].Value = columnHeadersMapping[columnName];
                            col++;
                        }

                        // Add data rows
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
                                    worksheet.Cells[row, col].Value = ""; // Set empty string if column is missing
                                }
                                col++;
                            }
                            row++;
                        }

                        // Prepare to send file
                        using (var memoryStream = new MemoryStream())
                        {
                            package.SaveAs(memoryStream);
                            byte[] fileBytes = memoryStream.ToArray();

                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=TransferReport.xlsx");
                            Response.BinaryWrite(fileBytes);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    else
                    {
                        // Handle case where no records are found
                        string script = "alert('No Record Found');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                string script = $"alert('An error occurred: {ex.Message}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Check if the row is a data row (not a header or footer row)
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPendingInDays = (Label)e.Row.FindControl("lblPendingInDays");

                // Find the LinkButton in the current row
                LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");


                // Use DataBinder.Eval to safely extract the "ApplicationStatus" field from the DataItem
                object statusObj = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus");

                // Ensure that the status object is not null
                if (statusObj != null)
                {
                    string status = statusObj.ToString();

                    // Check the status and apply the logic
                    if (status == "Approved")
                    {
                        //linkButton.Visible = true;
                        lblPendingInDays.Visible = false;

                    }
                    else
                    {
                        //linkButton.Visible = false;
                        lblPendingInDays.Visible = true;

                    }
                }

            }
        }
        private void BindGridAfterSearch()
        {
            try
            {

                if (string.IsNullOrEmpty(txtInspection.Text.Trim()))
                {
                    InspectionId = null;
                }
                else
                {
                    InspectionId = txtInspection.Text.Trim();

                }

                Transfer = ddlTransferStaff.SelectedValue == "0" ? "" : ddlTransferStaff.SelectedItem.ToString();
                Status = ddlStatusWise.SelectedValue == "0" ? "" : ddlStatusWise.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(txtDateTo.Text.Trim()))
                {
                    DateTime tempDateTo;
                    if (DateTime.TryParse(txtDateTo.Text.Trim(), out tempDateTo))
                    {
                        DateTo = tempDateTo;
                    }
                }

                if (!string.IsNullOrEmpty(txtDateFrom.Text.Trim()))
                {
                    DateTime tempDateFrom;
                    if (DateTime.TryParse(txtDateFrom.Text.Trim(), out tempDateFrom))
                    {
                        DateFrom = tempDateFrom;
                    }
                }


                DataTable ds = CEI.GetTransferSearchReport(DateFrom, DateTo, Transfer, Status, InspectionId);

                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Session["Searched"] = "true";
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }

            }
            catch { }
        }

    }
}