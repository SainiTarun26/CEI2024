﻿using CEI_PRoject;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Input;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class GenerateInspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        //string id = string.Empty;https://localhost:44393/Contractor/Work_Intimation.aspx.cs
        string fileExtension = string.Empty;
        string fileExtension2 = string.Empty;
        string fileExtension3 = string.Empty;
        string fileExtension4 = string.Empty;
        string IntimationId = string.Empty;
        int ServiceType = 0;
        int inspectionCountRes = 0;
        int inspectionIdRes = 0;
        string InstallationId = string.Empty;
        protected decimal totalAmount = 0;
        int intSubTotalIndex = 1, dblSubTotalCapacity = 0, dblGrandTotalCapacity = 0, highestOfficerDesignation = 0;
        decimal dblSubTotalAmount = 0, dblGrandTotalAmount = 0;
        double dblSubHighestVoltage = 0, dblHighestVoltage = 0;

        string strPreviousRowID = string.Empty;

        // string Count = string.Empty;
        private static string PremisesType, ApplicantTypeCode, id, Category, InstallationTypeId, Count, PaymentMode,
            ApplicantType, InstallationType, AssigDesignation, InspectionType, PlantLocation;
        //private static int TotalAmount;
        string LoginId, PlantLocationRoofTop, PlantLocationGroundMounted = string.Empty;
        //string id = string.Empty;
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();
        string TestReportId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    List<string> sessionKeysToRemove = new List<string>
                    {
                        "Amount","TotalCapacity","HighestVoltage","File","Line","SubStation","GeneratingSet","PendingIntimations","PendingPaymentId","PrintInspectionID","InstallationId"
                    };
                    ClearSessions(sessionKeysToRemove);
                    //if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
                    {
                        hfOwner.Value = Convert.ToString(Session["SiteOwnerId"]);
                        Session["Amount"] = "";
                        getWorkIntimationData();
                        Session["PreviousPage"] = Request.Url.ToString();
                        Grd_Document.RowDataBound += Grd_Document_RowDataBound;

                        //customFile.Visible = true;
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("SiteOwnerPages/CreateTestReports.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("/login.aspx");
                Session["SiteOwnerId"] = "";
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
        }

        private void ClearSessions(List<string> sessionKeysToRemove)
        {
            foreach (string sessionKey in sessionKeysToRemove)
            {
                if (Session[sessionKey] != null && Convert.ToString(Session[sessionKey]) != string.Empty)
                {
                    Session.Remove(sessionKey);
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                //    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                //}

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int reportTypeColumnIndex = 7;
                    TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];
                    Label lblTypeOf = (Label)e.Row.FindControl("lblCategory");
                    LinkButton linkButton = (LinkButton)e.Row.FindControl("LnkInovoice");
                    LinkButton LinkButton3 = (LinkButton)e.Row.FindControl("lnkReport");

                    if (reportTypeCell.Text == "Returned")
                    {
                        e.Row.CssClass = "ReturnedRowColor";
                    }
                    //Only Condition Changed By Navneet 30-april-2025 
                    if (linkButton.CommandArgument.ToString()==null|| linkButton.CommandArgument.ToString() == ""|| LinkButton3.CommandArgument.ToString() == null)
                    {
                        linkButton.Visible = false;
                        LinkButton3.Visible = false;
                    }
                    else
                    {
                        linkButton.Visible = true;
                        LinkButton3.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void getWorkIntimationData()
        {
            if (CheckAndRedirect("id", "ForNewInstallation.aspx"))
            {
                return;
            }
            id = Session["id"].ToString();
            Session["PendingIntimations"] = id;
            DataSet ds = new DataSet();
            ds = CEI.SiteOwnerInstallations(id);
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

        private bool CheckAndRedirect(string sessionKeysCsv, string redirectPage)
        {
            List<string> sessionKeys = sessionKeysCsv.Split(',').Select(s => s.Trim()).ToList();
            string resultPage = CheckSessionsAndRedirect(sessionKeys, redirectPage);
            if (!string.IsNullOrEmpty(resultPage))
            {
                Response.Redirect(resultPage, false);
                return true;
            }
            return false;
        }

        private string CheckSessionsAndRedirect(List<string> sessionKeysToCheck, string redirectPage)
        {
            List<string> mandatorySessionKeys = new List<string>
            {
                "SiteOwnerId"
            };
            List<string> allSessionKeysToCheck = mandatorySessionKeys.Concat(sessionKeysToCheck).ToList();

            foreach (string sessionKey in allSessionKeysToCheck)
            {
                string sessionValue = Convert.ToString(Session[sessionKey]);

                if (Session[sessionKey] == null || string.IsNullOrEmpty(Convert.ToString(Session[sessionKey])))
                {
                    if (mandatorySessionKeys.Contains(sessionKey))
                    {
                        return "/SiteOwnerLogout.aspx";
                    }
                    else
                    {
                        return redirectPage;
                    }
                }

                if (sessionKey == "SiteOwnerId" && sessionValue != hfOwner.Value)
                {
                    return "/SiteOwnerLogout.aspx"; // Redirect to logout if session value doesn't match hidden field value
                }
            }
            return null;
        }

        //////protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //////{
        //////    GridView1.PageIndex = e.NewPageIndex;
        //////    getWorkIntimationData();
        //////}
        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAndRedirect("Duplicacy", "CreateTestReports.aspx"))
            {
                return;
            }
            try
            {
                List<string> selectedTypes = new List<string>();
                Dictionary<string, int> categoryCounts = new Dictionary<string, int>();

                foreach (GridViewRow rows in GridView1.Rows)
                {
                    // Find the CheckBox in the current row
                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                    // Check if the CheckBox is selected
                    if (chk != null && chk.Checked)
                    {
                        // Find the label that holds the 'Typs' value (lblCategory)
                        Label lblTyps = (Label)rows.FindControl("lblCategory");

                        string type = lblTyps.Text;
                        if (!selectedTypes.Contains(type))
                        {
                            selectedTypes.Add(type);
                        }

                        if (categoryCounts.ContainsKey(type))
                        {
                            categoryCounts[type]++;
                        }
                        else
                        {
                            categoryCounts[type] = 1;
                        }
                    }
                }
                InstallationId = string.Join(",", selectedTypes);
                DataTable ds = new DataTable();
                ds = CEI.GetApplicantCode(InstallationId);
                if (ds.Rows.Count > 0)
                {
                    InstallationId = ds.Rows[0]["Id"].ToString();
                    Session["InstallationId"] = InstallationId;
                }
                else
                {
                    InstallationId = Session["InstallationId"].ToString();

                }
                GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;

                if (row != null)
                {
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    //Label lblApplicant = (Label)row.FindControl("lblApplicant");
                    //Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                    //Label lblDivision = (Label)row.FindControl("lblDivision");
                    Label lblDistrict = (Label)row.FindControl("lblDistrict");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    Label lblPremises = (Label)row.FindControl("lblPermises");
                    Label lblApplicantTypeCode = (Label)row.FindControl("lblApplicantTypeCode");
                    Label lblDesignation = (Label)row.FindControl("lblDesignation");
                    Label lblTypeOfPlant = (Label)row.FindControl("LblTypeofPlant");
                    Label LblSactionLoad = (Label)row.FindControl("LblSactionLoad");
                    Label lblReportType = (Label)row.FindControl("lblReportType");
                    Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                    //Session["lblIntimationId"] = lblIntimationId.Text;
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    TestReportId = lblTestReportId.Text;
                    if (LblSactionLoad.Text == "1")
                    {
                        SactionVoltage.Visible = true;
                    }
                    if (lblReportType.Text == "Returned")
                    {
                        lnkFile.Visible = true;
                        customFileLocation.Visible = false;
                        customFile.Visible = false;
                        txtSaction.ReadOnly = true;
                    }
                    else
                    {
                        lnkFile.Visible = false;
                        customFile.Visible = true;
                        customFileLocation.Visible = false;
                        txtSaction.ReadOnly = false;
                        txtSaction.Text = "";
                    }

                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                    DropDownList ddlDocumentFor = Documents.FindControl("ddlDocumentFor") as DropDownList;

                    inspectionCountRes = Convert.ToInt32(((HtmlInputHidden)row.FindControl("InspectionCount")).Value.Replace("\r\n", ""));
                    inspectionIdRes = Convert.ToInt32(((HtmlInputHidden)row.FindControl("InspectionId")).Value.Replace("\r\n", ""));
                    if (ddlDocumentFor != null)
                    {
                        ddlDocumentFor.Items.Clear();
                        ddlDocumentFor.Items.Add(new ListItem("Select", "0"));
                        int checkedCount = 0;
                        foreach (GridViewRow CurrentRow in GridView1.Rows)
                        {
                            CheckBox chkSelect = CurrentRow.FindControl("CheckBox1") as CheckBox;

                            if (chkSelect != null && chkSelect.Checked)
                            {
                                checkedCount++;
                                Label lblNoOfInstallation = CurrentRow.FindControl("lblNoOfInstallations") as Label;

                                if (lblNoOfInstallations != null)
                                {
                                    // Add values to the DropDownList
                                    string category = lblCategory.Text;
                                    string noOfInstallations = lblNoOfInstallation.Text;
                                    ddlDocumentFor.Items.Add(new ListItem($"{category} - {noOfInstallations}", $"{category}_{noOfInstallations}"));
                                }
                            }
                        }
                        if (checkedCount > 1)
                        {
                            ddlDocumentFor.Items.Add(new ListItem("Select All", "1"));
                            UploadDocuments.Visible = true;
                        }
                        else
                        {
                            UploadDocuments.Visible = false;
                            TestReportId = null;
                        }
                    }
                    string CreatedBy = Session["SiteOwnerId"].ToString();
                    TotalPayment.Visible = true;
                    ChallanDetail.Visible = true;

                    // txtInspectionDetails.Text = Session["SiteOwnerId"].ToString() + "-" + lblCategory.Text + "-" + lblVoltageLevel.Text;
                    ////Session["SelectedCategory"] = lblCategory.Text;
                    ////Session["SelectedApplicant"] = lblApplicant.Text;
                    ////Session["SelectedVoltageLevel"] = lblVoltageLevel.Text;
                    ////Session["SelectedDivision"] = lblDivision.Text;
                    ////Session["SelectedDistrict"] = lblDistrict.Text;
                    ////Session["SelectedNoOfInstallations"] = lblNoOfInstallations.Text;
                    PremisesType = lblPremises.Text;
                    ApplicantTypeCode = lblApplicantTypeCode.Text;
                    Category = lblCategory.Text;
                    Count = lblNoOfInstallations.Text;
                    if (Session["Duplicacy"].ToString().Trim() == "0")
                    {
                        CEI.DeleteduplicateHistory(lblIntimationId.Text, CreatedBy);
                        Session["Duplicacy"] = "1";
                    }
                    else
                    {
                    }
                    //ApplicantType = lblApplicant.Text;
                    //if (ApplicantType == "Private/Personal Installation")
                    //{
                    //    ApplicantType = "Private And Personal";
                    //}
                    //if (ApplicantType == "Other Department/Organization") 
                    //{
                    //    ApplicantType = "Other Department";
                    //} 

                    InspectionType = "New";
                    AssigDesignation = lblDesignation.Text;
                    if (Session["InstallationId"].ToString() == "1" || Session["InstallationId"].ToString() == "2" || Session["InstallationId"].ToString() == "5")
                    {
                        PlantLocation = null;
                        //// Session["PlantLocation"] = "";
                    }
                    else
                    {
                        foreach (GridViewRow rows in GridView1.Rows)
                        {
                            CheckBox chk1 = (CheckBox)rows.FindControl("CheckBox1");
                            if (chk1 != null && chk1.Checked)
                            {
                                Label lblTyps1 = (Label)rows.FindControl("lblCategory");
                                if (lblTyps1.Text == "Generating Set")
                                {
                                    Label lblTypeOfPlant1 = (Label)rows.FindControl("LblTypeofPlant");
                                    if (lblTypeOfPlant1 != null)
                                    {
                                        string plantType = lblTypeOfPlant1.Text;

                                        if (plantType == "Roof Top")
                                        {
                                            PlantLocationRoofTop = plantType;
                                        }
                                        else if (plantType == "Ground Mounted")
                                        {
                                            PlantLocationGroundMounted = plantType;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //if (Convert.ToString(Session["PlantLocation"]) != null && Session["PlantLocation"].ToString() != "")
                    //{
                    //    PlantLocation = Session["PlantLocation"].ToString();
                    //}
                    //else
                    //{
                    //    PlantLocation = null;
                    //}
                    UploadDocuments.Visible = true;
                    //SactionVoltage.Visible= true;
                    FeesDetails.Visible = true;
                    PaymentDetails.Visible = true;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    Declaration.Visible = true;
                    //lnkFile.Visible = true;
                    GetDocumentUploadData(ApplicantTypeCode, int.Parse(InstallationId), InspectionType, PlantLocationRoofTop, PlantLocationGroundMounted, inspectionIdRes);
                    //Session["InstallationTypeID"] = int.Parse(InstallationId);

                    DataTable dt = new DataTable();
                    dt = CEI.GetApplicantCode(lblCategory.Text);
                    if (dt.Rows.Count > 0)
                    {
                        InstallationId = dt.Rows[0]["Id"].ToString();


                    }
                    else
                    {
                    }
                    //id = Session["lblIntimationId"].ToString();
                    DataTable dsa = new DataTable();
                    dsa = CEI.Payment(id, Count, InstallationId, "New");
                    int Amount = 0;
                    if (dsa.Rows.Count > 0)
                    {
                        Amount = Convert.ToInt32(dsa.Rows[0]["Amount"].ToString());
                    }
                    else
                    {
                    }
                    //if (chk.Checked == true)
                    //{
                    if (chk.Checked)
                    {
                        CEI.InsertPaymentHistory(id, int.Parse(lblNoOfInstallations.Text), int.Parse(InstallationId),
                            //lblVoltageLevel.Text,
                            Amount, CreatedBy);
                    }
                    //}
                    else
                    {
                        CEI.DeletePaymentHistory(id, int.Parse(lblNoOfInstallations.Text), int.Parse(InstallationId), CreatedBy);
                    }

                    PaymentGridViewBind(id);

                    GetOtherDetails_ForReturnedInspection(inspectionIdRes);
                    //    else
                    //    {
                    //    Session["SelectedCategory"] = lblCategory.Text;
                    //    DataTable dt = new DataTable();
                    //    dt = CEI.GetApplicantCode(lblCategory.Text);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        InstallationId = dt.Rows[0]["Id"].ToString();
                    //    }
                    //    else
                    //    {
                    //    }
                    //    ApplicantTypeCode = lblApplicantTypeCode.Text;
                    //    CEI.DeletePaymentHistory(id, int.Parse(Count), int.Parse(InstallationId), CreatedBy);
                    //    PaymentGridViewBind(id);
                    //    GetDocumentUploadData(ApplicantTypeCode, int.Parse(InstallationId), InspectionType, PlantLocation, inspectionIdRes);
                    //}
                }
            }
            catch (Exception ex)
            {
                //Handle the exception appropriately
            }
        }
        protected void GridViewPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label LblCount = e.Row.FindControl("LblCount") as Label;
                    Label LblInstallationName = e.Row.FindControl("LblInstallationName") as Label;
                    Label LblIntimationId = e.Row.FindControl("LblIntimationId") as Label;
                    // Label LblInspectionId = e.Row.FindControl("LblInspectionId") as Label;
                    //string InspectionId = LblInspectionId.Text;

                    // PrevInspectionId = InspectionId;
                    //Label Lbldesignation = e.Row.FindControl("Lbldesignation") as Label;                    
                    if (LblCount.Text != null && LblInstallationName.Text != null && LblIntimationId != null)
                    {
                        if (LblInstallationName.Text == "Line")
                        {
                            InstallationTypeId = "1";
                        }
                        else if (LblInstallationName.Text == "Substation Transformer")
                        {
                            InstallationTypeId = "2";
                        }
                        else if (LblInstallationName.Text == "Generating Set")
                        {
                            InstallationTypeId = "3";
                        }
                        //string InspectionType = "Periodic";
                        //DataTable ds = new DataTable();
                        //ds = CEI.Payment(LblIntimationId.Text, LblCount.Text, InstallationTypeId, InspectionType);
                        //if (ds.Rows.Count > 0 && ds != null)
                        //{
                        //    int Amount = Convert.ToInt32(ds.Rows[0]["Amount"].ToString());
                        //    TotalAmount = Convert.ToInt32(Session["FinalAmount"]);
                        //    TotalAmount = TotalAmount + Amount;
                        //    Session["FinalAmount"] = TotalAmount;
                        //}
                    }

                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "installationType").ToString();

                    // Check and parse Capacity
                    object capacityObj = DataBinder.Eval(e.Row.DataItem, "Capacity");
                    int dblCapacity = 0;
                    if (capacityObj != null && int.TryParse(capacityObj.ToString(), out dblCapacity))
                    {
                        dblSubTotalCapacity += dblCapacity;
                        dblGrandTotalCapacity += dblCapacity;
                    }

                    // Check and parse Voltage
                    object voltageObj = DataBinder.Eval(e.Row.DataItem, "voltage");
                    double dblVoltage = 0;
                    if (voltageObj != null && double.TryParse(voltageObj.ToString(), out dblVoltage))
                    {
                        // Update the highest voltage for the subtotal 
                        dblSubHighestVoltage = Math.Max(dblSubHighestVoltage, dblVoltage);
                        dblHighestVoltage = Math.Max(dblHighestVoltage, dblVoltage);
                    }


                    // Check and parse Total Amount 
                    object amountObj = DataBinder.Eval(e.Row.DataItem, "Amount");
                    //decimal dblAmount = 0;
                    if (amountObj != null && decimal.TryParse(amountObj.ToString(), out decimal dblAmount))
                    {
                        dblSubTotalAmount += dblAmount;
                        dblGrandTotalAmount += dblAmount;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblTotalCapacity = (Label)e.Row.FindControl("lblTotalCapacity");
                    Label lblMaxVoltage = (Label)e.Row.FindControl("lblMaxVoltage");

                    Label lblMaxAmount = (Label)e.Row.FindControl("lblMaxAmount");

                    lblTotalCapacity.Text = "Total Capacity: " + dblGrandTotalCapacity.ToString("N0") + "KVA";
                    lblMaxVoltage.Text = "Max Voltage: " + dblHighestVoltage.ToString("N0");

                    lblMaxAmount.Text = "Total Amount: " + dblGrandTotalAmount.ToString("N0");

                    Session["TotalCapacity"] = dblGrandTotalCapacity;
                    Session["HighestVoltage"] = dblHighestVoltage;
                    Session["Amount"] = dblGrandTotalAmount;
                }
            }
            catch (Exception ex) { }
            #region old 
            // Check if the row is a data row
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // Get the value of the 'Amount' column and add it to the total
            //    decimal amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            //    totalAmount += amount;
            //    if (amount != 0.00m)
            //    {
            //        Session["TotalAmount"] = amount;
            //    }
            //    else
            //    {
            //    }
            //}
            //else
            //{
            //}
            // Check if the row is the footer row
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    // Add the 'Total' label and total amount in the footer
            //    e.Row.Cells[2].Text = "<b>Total</b>";  // Assuming the 'Amount' column is the 3rd column
            //    e.Row.Cells[3].Text = $"<b>{totalAmount:C}</b>"; // Format as currency
            //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //}
            #endregion
        }
        protected void GridViewPayment_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                bool IsSubTotalRowNeedToAdd = false;
                if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "installationType") != null))
                    if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "installationType").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "installationType") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    intSubTotalIndex = 0;
                }
                if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "installationType") != null))
                {
                    GridView grdViewOrders = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Installation Name: " + DataBinder.Eval(e.Row.DataItem, "installationType").ToString();
                    cell.Font.Bold = true;
                    cell.ColumnSpan = 6;
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                if (IsSubTotalRowNeedToAdd)
                {
                    AddSubTotalRow((GridView)sender, e.Row.RowIndex + intSubTotalIndex);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "installationType") != null)
                    {
                        GridView grdViewOrders = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Installation Name: " + DataBinder.Eval(e.Row.DataItem, "installationType").ToString();
                        cell.Font.Bold = true;
                        cell.ColumnSpan = 6;
                        row.Cells.Add(cell);
                        grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void AddSubTotalRow(GridView gridView, int rowIndex)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

            // Create a cell for the subtotal label
            TableCell cell = new TableCell();
            cell.Text = "Sub Total";
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.ColumnSpan = 2;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Create a cell for the subtotal capacity
            cell = new TableCell();
            cell.Text = string.Format("{0:0}", dblSubTotalCapacity);
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Create a cell for the highest voltage in the group
            cell = new TableCell();
            cell.Text = string.Format("{0:0}", dblSubHighestVoltage);
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Create a cell for the Amount in the group
            cell = new TableCell();
            cell.Text = string.Format("{0:0}", dblSubTotalAmount);
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Add the subtotal row to the grid
            gridView.Controls[0].Controls.AddAt(rowIndex, row);

            dblSubTotalCapacity = 0;
            dblSubHighestVoltage = 0;
            dblSubTotalAmount = 0;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    IntimationId = Session["id"].ToString();
                    Count = lblNoOfInstallations.Text.Trim();
                    DataSet ds = new DataSet();
                    ds = CEI.GetData(lblCategory.Text.Trim(), IntimationId, Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (lblCategory.Text.Trim() == "Line")
                        {
                            //Session["LineID"] = ds.Tables[0].Rows[0]["ID"].ToString();// gurmeet 4 may, to testreportid instead of id 
                            Session["LineID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                            Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Substation Transformer")
                        {
                            //Session["SubStationID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                            Session["SubStationID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Generating Set")
                        {
                            //Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["ID"].ToString();
                            Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                        }
                    }
                }
                else if (e.CommandName == "View")
                {
                    string fileName = "";
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //lblerror.Text = fileName;
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception)
            {
            }
        }
        #region visibilty
        // protected void Visibility()
        //{
        //    Uploads.Visible = true;
        //    if (txtWorkType.Text == "Line")
        //    {
        //        if (txtApplicantType.Text.Trim() == "Supplier Installation")
        //        {
        //            LineSubstationSupplier.Visible = true;
        //            SupplierSub.Visible = true;
        //        }
        //        else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
        //        {
        //            LinePersonal.Visible = true;
        //            SupplierSub.Visible = true;
        //        }
        //    }
        //    else if (txtWorkType.Text == "Substation Transformer")
        //    {
        //        if (txtApplicantType.Text.Trim() == "Supplier Installation")
        //        {
        //            LineSubstationSupplier.Visible = true;
        //        }
        //        else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
        //        {
        //            PersonalSub.Visible = true;
        //        }
        //    }
        //    else if (txtWorkType.Text == "Generating Set")
        //    {
        //        if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
        //        {
        //            PersonalGenerating.Visible = true;
        //        }
        //        else
        //        {
        //            PersonalGenerating.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        LineSubstationSupplier.Visible = false;
        //        SupplierSub.Visible = false;
        //        PersonalGenerating.Visible = false;
        //    }

        //}
        #endregion
        private string GetDocumentIDFromFileUploadID(string fileUploadID)
        {
            string[] parts = fileUploadID.Split('_');
            if (parts.Length > 1)
            {
                return parts[1];
            }
            return null;
        }
        protected void lnkFile_Click(object sender, EventArgs e)
        {
            if (CheckAndRedirect("File", "CreateTestReports.aspx"))
            {
                return;
            }

            string fileName = Session["File"].ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            }
            Session["File"] = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //Added on 3 apl 2025  Method to Check If Any of Neccessary Session is Empty then redirect to Corresponding page
            if (CheckAndRedirect("InstallationId,id,Amount,TotalCapacity,HighestVoltage", "ForNewInstallation.aspx"))
            {
                return;
            }

            string CreatedBy = Session["SiteOwnerId"].ToString();
            //string script = "<script type=\"text/javascript\">window.onload = function() { printDiv('printableDiv'); }</script>";
            //ClientScript.RegisterStartupScript(this.GetType(), "print", script);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
            try
            {
                int checkedCount = 0;
                bool atLeastOneInspectionChecked = false;
                foreach (GridViewRow rows in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                    if (chk != null && chk.Checked)
                    {
                        checkedCount++;
                        atLeastOneInspectionChecked = true;
                        //break;
                    }
                }
                if (atLeastOneInspectionChecked)
                {
                    if (Check.Checked == true)
                    {

                        List<string> selectedTypes = new List<string>();
                        Dictionary<string, int> categoryCounts = new Dictionary<string, int>();

                        Label lblSelectedCategoryFromGridview;
                        Label lblSelectedApplicantFromGridview;
                        Label lblSelectedVoltageLevelFromGridview;
                        Label lblSelectedDivisionFromGridview;
                        Label lblSelectedDistrictFromGridview;

                        lblSelectedCategoryFromGridview = null;
                        lblSelectedApplicantFromGridview = null;
                        lblSelectedVoltageLevelFromGridview = null;
                        lblSelectedDivisionFromGridview = null;
                        lblSelectedDistrictFromGridview = null;

                        foreach (GridViewRow rows in GridView1.Rows)
                        {
                            // Find the CheckBox in the current row
                            CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                            // Check if the CheckBox is selected
                            if (chk != null && chk.Checked)
                            {
                                // Find the label that holds the 'Typs' value (lblCategory)
                                Label lblTyps = (Label)rows.FindControl("lblCategory");
                                lblSelectedCategoryFromGridview = (Label)rows.FindControl("lblCategoryName");
                                lblSelectedApplicantFromGridview = (Label)rows.FindControl("lblApplicant");
                                lblSelectedVoltageLevelFromGridview = (Label)rows.FindControl("lblVoltageLevel");
                                lblSelectedDivisionFromGridview = (Label)rows.FindControl("lblDivision");
                                lblSelectedDistrictFromGridview = (Label)rows.FindControl("lblDistrict");

                                string type = lblTyps.Text;
                                if (!selectedTypes.Contains(type))
                                {
                                    selectedTypes.Add(type);
                                }

                                if (categoryCounts.ContainsKey(type))
                                {
                                    categoryCounts[type]++;
                                }
                                else
                                {
                                    categoryCounts[type] = 1;
                                }
                            }
                        }
                        InstallationId = string.Join(",", selectedTypes);
                        DataTable ds1 = new DataTable();
                        ds1 = CEI.GetApplicantCodeIndustry(InstallationId);
                        if (ds1.Rows.Count > 0)
                        {
                            InstallationId = ds1.Rows[0]["Id"].ToString();
                            Session["InstallationId"] = InstallationId;
                        }
                        else
                        {
                            InstallationId = Session["InstallationId"].ToString();

                        }



                        //string lblCategory = string.Empty;
                        //if (Session["InstallationId"].ToString() != "1" || Session["InstallationId"].ToString() != "2" || Session["InstallationId"].ToString() != "3")
                        //{
                        //    lblCategory = "Multiple";
                        //}
                        //else
                        //{
                        //    lblCategory = Session["SelectedCategory"].ToString().Trim();
                        //}
                        string Category;
                        if (checkedCount == 1)
                        {
                            //Category = Session["SelectedCategoryName"].ToString().Trim();
                            Category = lblSelectedCategoryFromGridview.Text.ToString().Trim();
                        }
                        else
                        {
                            Category = "Multiple";
                        }

                        IntimationId = Session["id"].ToString();
                        DataTable dta = new DataTable();
                        dta = CEI.GetMaxValues(CreatedBy, IntimationId);
                        string lblNoOfInstallations = dta.Rows[0]["count"].ToString();
                        //string lblApplicant = Session["SelectedApplicant"].ToString().Trim();
                        //string lblVoltageLevel = Session["SelectedVoltageLevel"].ToString().Trim();
                        //string lblDivision = Session["SelectedDivision"].ToString().Trim();
                        //string lblDistrict = Session["SelectedDistrict"].ToString().Trim();
                        string lblApplicant = lblSelectedApplicantFromGridview.Text.ToString().Trim();
                        string lblVoltageLevel = lblSelectedVoltageLevelFromGridview.Text.ToString().Trim();
                        string lblDivision = lblSelectedDivisionFromGridview.Text.ToString().Trim();
                        string lblDistrict = lblSelectedDistrictFromGridview.Text.ToString().Trim();

                        //string lblNoOfInstallations = Session["SelectedNoOfInstallations"].ToString().Trim();
                        string District = lblDistrict.Trim();
                        string Assign = string.Empty;
                        string To = lblDivision.Trim();
                        string input = lblVoltageLevel.Trim();
                        string FileName = string.Empty;
                        string ChallanAttachment = string.Empty;
                        string DemandNotice = string.Empty;
                        string LineLength = string.Empty;
                        string FeesLeft = string.Empty;
                        string transcationId = string.Empty;
                        string TranscationDate = string.Empty;
                        //decimal TotalAmount = Convert.ToDecimal(Session["Amount"]);

                        //int TotalCapacity = Convert.ToInt32(Session["TotalCapacity"]);
                        int MaxVoltage = Convert.ToInt32(Session["HighestVoltage"]);

                        //decimal TotalAmount = decimal.Parse(amount);

                        string StaffAssignedCount = string.Empty;
                        string StaffAssigned = string.Empty;
                        string Assigned = string.Empty;
                        string InstallationTypeID = string.Empty;

                        //string SactionLoad = string.Empty;
                        int maxFileSize = 1048576;

                        Count = lblNoOfInstallations.Trim();

                        if (ChallanDetail.Visible == true)
                        {
                            if (txttransactionId.Text != "")
                            {
                                transcationId = txttransactionId.Text.Trim();
                                TranscationDate = string.IsNullOrEmpty(txttransactionDate.Text) ? null : txttransactionDate.Text;
                            }
                            else
                            {
                                txttransactionDate.Focus();
                                txttransactionId.Focus();
                                return;
                            }
                        }
                        if (RadioButtonList2.SelectedValue != null)
                        {
                            PaymentMode = RadioButtonList2.SelectedItem.ToString();
                        }
                        double kVA = 0.0;
                        double kW = 0.0;
                        if (double.TryParse(txtSaction.Text.Trim(), out kW))
                        {

                            double powerFactor = 0.9;
                            kVA = kW / powerFactor;
                        }
                        string filePath = string.Empty;
                        HttpPostedFile postedFile = customFile.PostedFile;
                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            if (postedFile.ContentLength <= maxFileSize)
                            {
                                string fileName = Path.GetFileName(postedFile.FileName);
                                string fileExtension = Path.GetExtension(fileName).ToLower();
                                if (fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx")
                                {
                                    FileName = "DemandNotice_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                                    string folderPath = Server.MapPath("~/DemandNotices/");
                                    if (!Directory.Exists(folderPath))
                                    {
                                        Directory.CreateDirectory(folderPath);
                                    }
                                    filePath = Path.Combine(folderPath, FileName);
                                    postedFile.SaveAs(filePath);
                                    DemandNotice = "~/DemandNotices/" + FileName;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "FileFormatError", "alert('File Format Not Supported. Only PDF, DOC, DOCX files are allowed.');", true);
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "FileSizeError", "alert('File exceeds maximum size limit (1 MB).');", true);
                                return;
                            }
                        }
                        DataSet ds = new DataSet();
                        ds = CEI.GetStaffAssignedforNewInspection(IntimationId);

                        if (ds.Tables.Count > 0 && ds != null)
                        {
                            StaffAssignedCount = ds.Tables[0].Rows[0]["AssignedCount"].ToString();
                        }

                        if (StaffAssignedCount == "1")
                        {
                            StaffAssigned = "JE";
                            ServiceType = 2;
                        }
                        else if (StaffAssignedCount == "2")
                        {
                            StaffAssigned = "AE";
                            ServiceType = 3;
                        }

                        else if (StaffAssignedCount == "3")
                        {
                            StaffAssigned = "XEN";
                            ServiceType = 4;
                        }
                        else if (StaffAssignedCount == "4")
                        {
                            StaffAssigned = "CEI";
                            ServiceType = 1;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Process has been upgraded kindly create new workIntimation to Process further')", true);
                            return;
                        }

                        DataSet dsp = new DataSet();
                        dsp = CEI.ToGetStaffIdforPeriodic(lblDivision, StaffAssigned, District);
                        if (dsp.Tables.Count > 0 && dsp.Tables[0].Rows.Count > 0)
                        {
                            Assigned = dsp.Tables[0].Rows[0]["StaffUserId"].ToString();
                        }
                        //InstallationTypeID = Session["InstallationTypeID"].ToString();
                        InstallationTypeID = Session["InstallationId"].ToString();
                        InsertFilesIntoDatabase(InstallationTypeID, CreatedBy, txtContact.Text, ApplicantTypeCode, IntimationId, PremisesType, lblApplicant.Trim(), Category.Trim(), lblVoltageLevel.Trim(),
                    District, To, PaymentMode, txtDate.Text, txtInspectionRemarks.Text.Trim(), CreatedBy, Assigned, transcationId, TranscationDate, ChallanAttachment, Convert.ToInt32(InspectionIdClientSideCheckedRow.Value)
                    , kVA.ToString(), DemandNotice, MaxVoltage, ServiceType);
                        //Session["PrintInspectionID"] = id.ToString();
                    }
            
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                }
            }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please First tick the any one installation for inspection')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }
        public void UploadCheckListDocInCollection(string Category, string CreatedByy, string intimationids, string InstallTypes, string InstallTypeCount)
        {
            foreach (GridViewRow row in Grd_Document.Rows)
            {
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                string Req = ((HtmlInputHidden)row.FindControl("Req")).Value.Replace("\r\n", "");
                string DocSaveName = ((HtmlInputHidden)row.FindControl("DocumentShortName")).Value.Replace("\r\n", "");
                string DocumentID = ((HtmlInputHidden)row.FindControl("DocumentID")).Value.Replace("\r\n", "");
                string DocName = row.Cells[1].Text.Replace("\r\n", "");

                if (Convert.ToInt32(InspectionIdClientSideCheckedRow.Value) == 0)
                {
                    if (Req == "1")
                    {

                        if (!fileUpload.HasFile && Req == "1")
                        {
                            string message = DocName + " is mandatory to upload.";
                            throw new Exception(message);

                        }
                    }
                }

                if (fileUpload.HasFile)
                {
                    string CreatedBy = CreatedByy;
                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")
                    {

                        if (fileUpload.PostedFile.ContentLength <= 1048576)
                        {
                            string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);

                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/"));
                            }

                            string ext = fileUpload.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/";
                            //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            //string fileName = DocSaveName + "." + ext;
                            string fileName = DocSaveName + ".pdf";

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/" + fileName);

                            fileUpload.PostedFile.SaveAs(filePathInfo2);

                            uploadedFiles.Add((Category, DocumentID, DocName, fileName, path + fileName));

                        }
                        else
                        {
                            throw new Exception("Please Upload Pdf Files Less Than 1 Mb Only");
                        }
                    }
                    else
                    {
                        throw new Exception("Please Upload Pdf Files Only");
                    }
                }

            }

        }

        public void InsertFilesIntoDatabase(string InstallationTypeID, string para_CreatedBy, string para_txtContact, string para_ApplicantTypeCode, string para_IntimationId, string para_PremisesType, string para_lblApplicant, string para_lblCategory, string para_lblVoltageLevel,
             string para_District, string para_To, string para_PaymentMode, string para_txtDate, string para_txtInspectionRemarks, string para_CreatedByy, string para_Assigned, string para_transcationId, string para_TranscationDate, string para_ChallanAttachment, int para_InspectID, string para_kVA
            , string para_DemandNotice, int MaxVoltage, int ServiceType)
        {           
            // Insert the uploaded files into the database
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    Session["Duplicacy"] = "2";
                    CEI.InsertInspectionDataNewCode(InstallationTypeID, para_txtContact, para_ApplicantTypeCode, para_IntimationId, para_PremisesType, para_lblApplicant, para_lblCategory, para_lblVoltageLevel,
                    para_District, para_To, para_PaymentMode, para_txtDate, para_txtInspectionRemarks, para_CreatedByy, para_Assigned, para_transcationId, para_TranscationDate, para_ChallanAttachment, para_InspectID, para_kVA, para_DemandNotice, MaxVoltage, ServiceType, transaction);

                    string generatedIdCombinedDetails = CEI.InspectionId();
                    string[] SplitResultPartsArray = generatedIdCombinedDetails.Split('|');
                    Session["PendingPaymentId"] = SplitResultPartsArray[0];
                    string firstValue = SplitResultPartsArray[0]; // Extract the first value
                    Session["PrintInspectionID"] = firstValue;
                    UploadCheckListDocInCollection("MultipleInstallationType", para_CreatedByy, SplitResultPartsArray[1], "MultipleInstallationType", InstallationTypeID);

                    foreach (var file in uploadedFiles)
                    {
                        //string query = "INSERT INTO tbl_InspectionAttachment (InspectionId,InstallationType,DocumentID,DocumentName,fileName, DocumentPath,CreatedDate,CreatedBy,Status) VALUES (@InspectionId,@InstallationType,@DocumentID,@DocSaveName,@FileName, @FilePath,getdate(),@CreatedBy,1)";
                        string query = "sp_InsertInspectionAttachments";

                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@InspectionId", SplitResultPartsArray[0]);
                            command.Parameters.AddWithValue("@InstallationType", file.Installtypes);
                            command.Parameters.AddWithValue("@DocumentID", file.DocumentID);
                            command.Parameters.AddWithValue("@DocSaveName", file.DocSaveName);
                            command.Parameters.AddWithValue("@FileName", file.FileName);
                            command.Parameters.AddWithValue("@FilePath", file.FilePath);
                            command.Parameters.AddWithValue("@CreatedBy", para_CreatedBy);
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();

                    foreach (GridViewRow rows in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                        if (chk != null && chk.Checked)
                        {
                            Label lblIntimationId = (Label)rows.FindControl("lblIntimationId");
                            Label lblCategorys = (Label)rows.FindControl("lblCategory");
                            Label lblNoOfInstallation = (Label)rows.FindControl("lblNoOfInstallations");
                            CEI.UpdateInstallationHistory(lblCategorys.Text, lblIntimationId.Text, para_CreatedBy, int.Parse(lblNoOfInstallation.Text));
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Please Upload Pdf Files Only")
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                        return;
                    }
                    else if (ex.Message == "Please Upload Pdf Files Less Than 1 Mb Only")
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                    else if (ex.Message.Contains(" is mandatory to upload."))
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                    else
                    {
                        transaction.Rollback();
                        //Commented below to raise errors as per backend
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill All details carefully')", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                }
                finally
                {
                    connection.Close();
                }               
            }
        }
        protected void ddlDocumentFor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void PaymentGridViewBind(string id)
        {
            if (CheckAndRedirect("SiteOwnerId", "CreateTestReports.aspx"))
            {
                return;
            }
            try
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetPaymentHistory(CreatedBy, id);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    GridViewPayment.DataSource = ds;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    //string script = "alert(\"Please Fill the Form first for knowing Payment \");";
                    string script = "alert(\"Please Check atleast one CheckBox \");";

                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);

                    UploadDocuments.Visible = false;
                    FeesDetails.Visible = false;
                    PaymentDetails.Visible = false;
                    btnReset.Visible = false;
                    btnSubmit.Visible = false;
                    Declaration.Visible = false;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
        //protected void PaymentGridViewBind()
        //{
        //    try
        //    {
        //        if (Category == "Line")
        //        {
        //            InstallationTypeId = "1";
        //        }
        //        else if (Category == "Substation Transformer")
        //        {
        //            InstallationTypeId = "2";
        //        }
        //        else if (Category == "Generating Set")
        //        {
        //            InstallationTypeId = "3";
        //        }
        //        string InspectionType="New";
        //        DataTable ds = new DataTable();
        //        ds = CEI.Payment(id, Count, InstallationTypeId, InspectionType);
        //        if (ds.Rows.Count > 0 && ds != null)
        //        {
        //            GridViewPayment.DataSource = ds;
        //            GridViewPayment.DataBind();
        //            //TotalAmount = Convert.ToInt32(GridViewPayment.Rows[0].Cells[2].Text);
        //            int Amount = Convert.ToInt32(GridViewPayment.Rows[0].Cells[2].Text);                    
        //            Session["Amount"] = Amount.ToString();
        //            //txtPayment.Text = Convert.ToString(TotalAmount);
        //        }
        //        else
        //        {
        //            GridViewPayment.DataSource = null;
        //            GridViewPayment.DataBind();
        //            string script = "alert(\"Please Fill the Form first for knowing Payment \");";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
        //        }
        //        ds.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        //
        //    }
        //}
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChallanDetail.Visible = true;
            if (RadioButtonList2.SelectedValue == "0")
            {
                ChallanDetail.Visible = false;
            }
            else if (RadioButtonList2.SelectedValue == "1")
            {
                ChallanDetail.Visible = true;
            }
        }
        private void GetDocumentUploadData(string ApplicantType, int InstallationTypeID, string InspectionType, string PlantLocationRoofTop, string PlantLocationGroundMounted, int inspectionIdPrm)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlistfornewInspection(ApplicantType, InstallationTypeID, InspectionType, PlantLocationRoofTop, PlantLocationGroundMounted, inspectionIdPrm);
            if (ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();

                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        protected void Grd_Document_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //this code will work in case of New Upload documents  First Time Fresh Records
                if (inspectionCountRes == 0)
                {
                    LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");


                    string commandArgument = lnkDocumemtPath.CommandArgument;


                    if (string.IsNullOrEmpty(commandArgument))
                    {
                        // Get the index of the column containing the LinkButton
                        int columnIndex = GetColumnIndexByName(Grd_Document, "Uploaded Documents");

                        // Hide the column containing the LinkButton
                        e.Row.Cells[columnIndex].Visible = false;

                        // Find and hide the header cell of the column
                        GridViewRow headerRow = Grd_Document.HeaderRow;
                        if (headerRow != null && headerRow.Cells.Count > columnIndex)
                        {
                            headerRow.Cells[columnIndex].Visible = false;
                        }
                        customFile.Visible = true;
                    }
                }

                //this code will work in case of already uploaded documents
                if (inspectionCountRes > 0)
                {
                    LinkButton lnkDocumemtPath1 = (LinkButton)e.Row.FindControl("LnkDocumemtPath");

                    string commandArgument1 = lnkDocumemtPath1.CommandArgument;

                    if (string.IsNullOrEmpty(commandArgument1))
                    {
                        // Disable the LinkButton
                        lnkDocumemtPath1.Enabled = false;
                        customFile.Visible = false;
                    }
                }
            }
        }
        //protected void Grd_Document_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // Find the LinkButton control in the row
        //        LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");

        //        // Get the command argument
        //        string commandArgument = lnkDocumemtPath.CommandArgument;

        //        // Check if command argument is blank or null
        //        if (string.IsNullOrEmpty(commandArgument))
        //        {
        //            // Get the index of the column containing the LinkButton
        //            int columnIndex = GetColumnIndexByName(Grd_Document, "Uploaded Documents");

        //            // Hide the column containing the LinkButton
        //            e.Row.Cells[columnIndex].Visible = false;

        //            // Hide the header of the column
        //            Grd_Document.HeaderRow.Cells[columnIndex].Visible = false;
        //        }
        //    }
        //}

        // Function to get the index of a column by its header text
        private int GetColumnIndexByName(GridView grid, string headerText)
        {
            for (int i = 0; i < grid.HeaderRow.Cells.Count; i++)
            {
                if (grid.HeaderRow.Cells[i].Text.ToLower() == headerText.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        private void GetOtherDetails_ForReturnedInspection(int inspectionIdPrm)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "Sp_GetOtherDetails_ForReturnedInspection";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InspectionId", inspectionIdPrm);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txttransactionId.Text = reader["TransactionId"].ToString();
                        if (reader["TransctionDate"] != DBNull.Value)
                        {
                            txttransactionDate.Text = Convert.ToDateTime(reader["TransctionDate"]).ToString("yyyy-MM-dd");
                        }
                        txtInspectionRemarks.Text = reader["InspectionRemarks"].ToString();
                        txtSaction.Text = reader["SactionVoltage"].ToString();
                        customFileLocation.Text = reader["DemandDocument"].ToString();
                        Session["File"] = customFileLocation.Text;
                    }
                    reader.Close();
                }
            }
        }
    }
}