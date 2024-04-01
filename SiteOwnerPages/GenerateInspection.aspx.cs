using CEI_PRoject;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class GenerateInspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string id = string.Empty;
        string fileExtension = string.Empty;
        string fileExtension2 = string.Empty;
        string fileExtension3 = string.Empty;
        string fileExtension4 = string.Empty;
        string IntimationId = string.Empty;
        string Count = string.Empty;
        private static string PremisesType , ApplicantTypeCode;
        string LoginId = string.Empty;
        string IntimationIds = string.Empty;
        //string id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        getWorkIntimationData();
                        Session["PreviousPage"] = Request.Url.ToString();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
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

            }
            catch (Exception ex)
            {

            }
        }

        private void getWorkIntimationData()
        {
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow rows in GridView1.Rows)
                {
                    if (rows.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = rows.FindControl("CheckBox1") as CheckBox;


                        if (chk != null && chk.ClientID == ((CheckBox)sender).ClientID)
                        {

                        }
                        else
                        {
                            chk.Checked = false;
                        }
                    }
                }
                GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;

                if (row != null)
                {
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblApplicant = (Label)row.FindControl("lblApplicant");
                    Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                    Label lblDivision = (Label)row.FindControl("lblDivision");
                    Label lblDistrict = (Label)row.FindControl("lblDistrict");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    Label lblPremises = (Label)row.FindControl("lblPermises");
                    Label lblApplicantTypeCode = (Label)row.FindControl("lblApplicantTypeCode");

                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                    DropDownList ddlDocumentFor = Documents.FindControl("ddlDocumentFor") as DropDownList;

                    #region
                    // for  dynamically generation table row 
                    //DataTable documentData = new DataTable();
                    //documentData = CEI.GetDocumanetName(id);                   
                    //foreach (DataRow rows in documentData.Rows)
                    //{
                    //    // Create a new table row
                    //    HtmlTableRow tr = new HtmlTableRow();

                    //    // Create a cell for the document name
                    //    HtmlTableCell nameCell = new HtmlTableCell();
                    //    //nameCell.Controls.Add(new LiteralControl(rows["DocumentName"].ToString()));                       
                    //    nameCell.InnerText = rows["DocumentName"].ToString();


                    //    // Create a cell for the FileUpload control
                    //    HtmlTableCell fileUploadCell = new HtmlTableCell();
                    //    FileUpload fileUpload = new FileUpload();
                    //    fileUpload.ID = "FileUpload_" + rows["DocumentID"].ToString(); // Assign a unique ID to each FileUpload control
                    //    //fileUploadCell.Controls.Clear();
                    //    fileUploadCell.Controls.Add(fileUpload);

                    //    tr.Cells.Add(nameCell);
                    //    tr.Cells.Add(fileUploadCell);

                    //    // Add the table row to the existing table
                    //    DocumentsTable.Rows.Add(tr); // Assuming DocumentsTable is the ID of your existing table in the ASP.NET markup
                    //}


                    //Table dynamicTable = new Table();

                    //// Add headers
                    //TableRow headerRow = new TableRow();
                    //headerRow.Cells.Add(new TableCell { Text = "Column 1" });
                    //headerRow.Cells.Add(new TableCell { Text = "Column 2" });
                    //dynamicTable.Rows.Add(headerRow);

                    //// Add data rows
                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    TableRow dataRow = new TableRow();
                    //    dataRow.Cells.Add(new TableCell { Text = row["Column1"].ToString() });
                    //    dataRow.Cells.Add(new TableCell { Text = row["Column2"].ToString() });
                    //    dynamicTable.Rows.Add(dataRow);
                    //}

                    //// Add the dynamic table to a placeholder or panel in the ASP.NET markup
                    //TablePlaceholder.Controls.Add(dynamicTable);

                    #endregion


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
                        }
                        // Show the Documents div if at least one CheckBox is checked
                        //  Documents.Visible = ddlDocumentFor.Items.Count > 0;
                    }
                    Uploads.Visible = GridView1.Rows.Cast<GridViewRow>().Any(r => ((CheckBox)r.FindControl("CheckBox1")).Checked);

                    // Show fields based on the category and applicant type
                    if (chk.Checked)
                    {
                        TotalPayment.Visible = true;
                        ChallanDetail.Visible = true;
                        txtInspectionDetails.Text = Session["SiteOwnerId"].ToString() + "-" + lblCategory.Text + "-" + lblVoltageLevel.Text;
                        //GridViewBind();
                        txtPayment.Text = "1000";
                        Session["SelectedCategory"] = lblCategory.Text;
                        Session["SelectedApplicant"] = lblApplicant.Text;
                        Session["SelectedVoltageLevel"] = lblVoltageLevel.Text;
                        Session["SelectedDivision"] = lblDivision.Text;
                        Session["SelectedDistrict"] = lblDistrict.Text;
                        Session["SelectedNoOfInstallations"] = lblNoOfInstallations.Text;
                        PremisesType = lblPremises.Text;
                        ApplicantTypeCode = lblApplicantTypeCode.Text;

                        LineSubstationSupplier.Visible = false;
                        SupplierSub.Visible = false;
                        LinePersonal.Visible = false;
                        SupplierSub.Visible = false;
                        LineSubstationSupplier.Visible = false;
                        PersonalSub.Visible = false;
                        PersonalGenerating.Visible = false;
                        PersonalGenerating.Visible = false;

                        if (lblCategory.Text == "Line")
                        {
                            if (lblApplicant.Text.Trim() == "Power Utility")
                            {
                              LineSubstationSupplier.Visible = true;
                              SupplierSub.Visible = true;
                            }
                            else if (lblApplicant.Text.Trim() == "Private/Personal Installation")
                            {
                                LinePersonal.Visible = true;
                                SupplierSub.Visible = true;
                            }
                        }
                        else if (lblCategory.Text == "Substation Transformer")
                        {
                            txtApplicantType.Text = Session["SelectedApplicant"].ToString();     ///////////////////
                            if (txtApplicantType.Text.Trim() == "Power Utility")
                            {
                                LineSubstationSupplier.Visible = true;
                            }
                            else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                            {
                                PersonalSub.Visible = true;
                            }
                        }
                        else if (lblCategory.Text == "Generating Set")
                        {
                            txtApplicantType.Text = Session["SelectedApplicant"].ToString();      //////////////////
                            if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                            {
                              PersonalGenerating.Visible = true;
                            }
                            else
                            {
                                PersonalGenerating.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        // Hide the fields if the checkbox is unchecked
                        LineSubstationSupplier.Visible = false;
                        SupplierSub.Visible = false;
                        LinePersonal.Visible = false;
                        PersonalSub.Visible = false;
                        PersonalGenerating.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
            }
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
                            Session["LineID"] = ds.Tables[0].Rows[0]["ID"].ToString();

                            Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Substation Transformer")
                        {
                            Session["SubStationID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                            Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Generating Set")
                        {
                            Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["ID"].ToString();
                            Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                        }
                    }
                }
                else
                {

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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               

                #region comments code for documents uploaded
                //if (ddlDocumentFor.SelectedValue == "1" || ddlDocumentFor.SelectedItem.Text.Trim() == "Select All")
                //{
                //    foreach (GridViewRow row in GridView1.Rows)
                //    {

                //        if ((row.FindControl("CheckBox1") as CheckBox).Checked)
                //        {
                //            Label lblCategory = (Label)row.FindControl("lblCategory");
                //            Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                //            Label lblDivision = (Label)row.FindControl("lblDivision");
                //            Label lblDistrict = (Label)row.FindControl("lblDistrict");
                //            Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                //            string District = lblDistrict.Text.Trim();
                //            string Assign = string.Empty;
                //            string To = lblDivision.Text.Trim();
                //            string input = lblVoltageLevel.Text.Trim();
                //            string CreatedBy = Session["SiteOwnerId"].ToString();
                //            string FileName = string.Empty;
                //            string flpPhotourl = string.Empty;
                //            string flpPhotourl1 = string.Empty;
                //            string flpPhotourl2 = string.Empty;
                //            string flpPhotourl3 = string.Empty;
                //            string flpPhotourl4 = string.Empty;
                //            string flpPhotourl5 = string.Empty;
                //            string flpPhotourl6 = string.Empty;
                //            string flpPhotourl7 = string.Empty;
                //            string flpPhotourl8 = string.Empty;
                //            string flpPhotourl9 = string.Empty;
                //            string flpPhotourl10 = string.Empty;
                //            string flpPhotourl11 = string.Empty;
                //            string flpPhotourl12 = string.Empty;
                //            string LineLength = string.Empty;
                //            string FeesLeft = string.Empty;
                //            IntimationId = Session["id"].ToString();
                //            Count = lblNoOfInstallations.Text.Trim();
                //            DataSet ds = new DataSet();
                //            ds = CEI.GetData(lblCategory.Text.Trim(), IntimationId, Count);
                //            if (ds.Tables[0].Rows.Count > 0)
                //            {
                //                if (lblCategory.Text.Trim() == "Line")
                //                {
                //                    id = ds.Tables[0].Rows[0]["ID"].ToString();
                //                    LineLength = ds.Tables[0].Rows[0]["LineLength"].ToString();
                //                }
                //                else
                //                {
                //                    id = ds.Tables[0].Rows[0]["ID"].ToString();
                //                }
                //            }
                //            if (lblCategory.Text.Trim() == "Line")
                //            {
                //                if (input.EndsWith("kv", StringComparison.OrdinalIgnoreCase))
                //                {
                //                    string voltagePart = input.Substring(0, input.Length - 2);
                //                    if (int.TryParse(voltagePart, out int voltageLevel))
                //                    {
                //                        if (voltageLevel >= 11 && voltageLevel <= 33)
                //                        {
                //                            Assign = "SDO";
                //                        }
                //                        else if (voltageLevel >= 33)

                //                        {
                //                            Assign = "Admin@123";
                //                        }
                //                        else if (voltageLevel <= 11)

                //                        {
                //                            Assign = "JE";
                //                        }

                //                    }
                //                }

                //                else if (input.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                //                {
                //                    Assign = "JE";

                //                }
                //            }
                //            else
                //            {
                //                if (input.EndsWith("KVA", StringComparison.OrdinalIgnoreCase))
                //                {
                //                    string voltagePart = input.Substring(0, input.Length - 3);
                //                    if (int.TryParse(voltagePart, out int voltageLevel))
                //                    {
                //                        if (voltageLevel >= 250 && voltageLevel <= 500)
                //                        {
                //                            Assign = "XEN";
                //                        }
                //                        else if (voltageLevel >= 500)

                //                        {
                //                            Assign = "Admin@123";
                //                        }
                //                        else if (voltageLevel >= 50 && voltageLevel <= 250)
                //                        {
                //                            Assign = "SDO";
                //                        }
                //                        else
                //                        {
                //                            Assign = "JE";
                //                        }
                //                    }

                //                }
                //                else if (input.EndsWith("MVA", StringComparison.OrdinalIgnoreCase))
                //                {
                //                    Assign = "Admin@123";

                //                }

                //            }
                //            if (LineSubstationSupplier.Visible == true)
                //            {
                //                fileExtension = Path.GetExtension(FileUpload1.FileName);

                //                if (fileExtension.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload1.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/"));
                //                        }

                //                        string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/";
                //                        string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/" + fileName);
                //                        FileUpload1.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl = path + fileName;
                //                    }
                //                }
                //                else
                //                {

                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                //                }
                //                fileExtension2 = Path.GetExtension(FileUpload2.FileName);

                //                if (fileExtension2.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload2.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/"));
                //                        }

                //                        string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/";
                //                        string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/" + fileName);
                //                        FileUpload2.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl1 = path + fileName;
                //                    }
                //                }
                //                else
                //                {

                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                //                }
                //            }
                //            if (SupplierSub.Visible == true)
                //            {
                //                fileExtension = Path.GetExtension(FileUpload3.FileName);

                //                if (fileExtension.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload3.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/"));
                //                        }

                //                        string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + id + "/SingleLineDiagramOfLine/";
                //                        string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/" + fileName);
                //                        FileUpload3.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl2 = path + fileName;
                //                    }
                //                }
                //                else
                //                {

                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                //                }
                //            }
                //            if (LinePersonal.Visible == true)
                //            {
                //                fileExtension = Path.GetExtension(FileUpload12.FileName);

                //                if (fileExtension.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload12.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/"));
                //                        }

                //                        string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/DemandNoticeOfLine/";
                //                        string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
                //                        FileUpload12.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl3 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                //                }
                //            }
                //            if (PersonalSub.Visible == true)
                //            {
                //                fileExtension = Path.GetExtension(FileUpload4.FileName);

                //                if (fileExtension.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload4.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
                //                        }

                //                        string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
                //                        string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
                //                        FileUpload4.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl4 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension2 = Path.GetExtension(FileUpload5.FileName);

                //                if (fileExtension2.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload5.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/"));
                //                        }

                //                        string ext = FileUpload5.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/";
                //                        string fileName = "InvoiceOfTransferOfPersonalSubstation" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/" + fileName);
                //                        FileUpload5.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl5 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension3 = Path.GetExtension(FileUpload6.FileName);

                //                if (fileExtension3.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload6.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload6.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/"));
                //                        }

                //                        string ext = FileUpload6.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/";
                //                        string fileName = "ManufacturingTestCertificateOfTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/" + fileName);
                //                        FileUpload6.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl6 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension4 = Path.GetExtension(FileUpload7.FileName);

                //                if (fileExtension4.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload7.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload7.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/"));
                //                        }

                //                        string ext = FileUpload7.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + id + "/SingleLineDiagramofTransformer/";
                //                        string fileName = "SingleLineDiagramofTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/" + fileName);
                //                        FileUpload7.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl7 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension3 = Path.GetExtension(FileUpload8.FileName);

                //                if (fileExtension3.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload8.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload8.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/"));
                //                        }

                //                        string ext = FileUpload8.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/";
                //                        string fileName = "InvoiceoffireExtinguisheratSite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/" + fileName);
                //                        FileUpload8.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl8 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //            }
                //            if (PersonalGenerating.Visible == true)
                //            {
                //                fileExtension = Path.GetExtension(FileUpload9.FileName);

                //                if (fileExtension.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload9.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/"));
                //                        }

                //                        string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/";
                //                        string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
                //                        FileUpload9.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl9 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension2 = Path.GetExtension(FileUpload10.FileName);

                //                if (fileExtension2.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload10.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/"));
                //                        }

                //                        string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/";
                //                        string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/" + fileName);
                //                        FileUpload10.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl10 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension3 = Path.GetExtension(FileUpload13.FileName);

                //                if (fileExtension3.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload13.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
                //                        }

                //                        string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/";
                //                        string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
                //                        FileUpload13.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl11 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //                fileExtension4 = Path.GetExtension(FileUpload11.FileName);

                //                if (fileExtension4.ToLower() == ".pdf")
                //                {
                //                    if (FileUpload11.PostedFile.FileName.Length > 0)
                //                    {
                //                        FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
                //                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/")))
                //                        {
                //                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/"));
                //                        }
                //                        string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
                //                        string path = "";
                //                        path = "/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/";
                //                        string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //                        string filePathInfo2 = "";
                //                        filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
                //                        FileUpload11.PostedFile.SaveAs(filePathInfo2);
                //                        flpPhotourl12 = path + fileName;
                //                    }
                //                }
                //                else
                //                {
                //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                //                }
                //            }
                //            // DateTime myDate = Convert.ToDateTime(txtDate.Text);

                //            CEI.InsertInspectionData(txtContact.Text, id, IntimationId, txtPremises.Text, lblCategory.Text.Trim(), lblCategory.Text.Trim(), lblVoltageLevel.Text.Trim(),
                //                LineLength, flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7, flpPhotourl8,
                //                flpPhotourl9, flpPhotourl10, flpPhotourl11, flpPhotourl12, Assign, District, To, txtRequestDetails.Text, txtDate.Text, CreatedBy);

                //            string generatedId = CEI.InspectionId();
                //            // DataSaved.Visible = true;
                //            Session["PendingPaymentId"] = generatedId;
                //            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);


                //        }
                //    }
                //}
                //else
                //{
                //foreach (GridViewRow row in GridView1.Rows)
                //{

                //    //Label lblCategory = (Label)row.FindControl("lblCategory");
                //    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                //    //if (lblCategory != null && lblCategory.Text == "Supervisor" && chk != null && chk.Checked)
                //    //{
                //    if (chk.Checked == true)
                //    {
                #endregion

                //check is one checkbox is selected?
                bool atLeastOneInspectionChecked = false;
                foreach (GridViewRow rows in GridView1.Rows)
                {

                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                    if (chk != null && chk.Checked)
                    {
                        atLeastOneInspectionChecked = true;
                        break;
                    }
                }
                if (atLeastOneInspectionChecked)
                {
                    string lblCategory = Session["SelectedCategory"].ToString().Trim();
                    string lblApplicant = Session["SelectedApplicant"].ToString().Trim();
                    string lblVoltageLevel = Session["SelectedVoltageLevel"].ToString().Trim();
                    string lblDivision = Session["SelectedDivision"].ToString().Trim();
                    string lblDistrict = Session["SelectedDistrict"].ToString().Trim();
                    string lblNoOfInstallations = Session["SelectedNoOfInstallations"].ToString().Trim();
                    string District = lblDistrict.Trim();
                    string Assign = string.Empty;
                    string To = lblDivision.Trim();
                    string input = lblVoltageLevel.Trim();
                    string CreatedBy = Session["SiteOwnerId"].ToString();
                    string FileName = string.Empty;
                    string flpPhotourl = string.Empty;
                    string flpPhotourl1 = string.Empty;
                    string flpPhotourl2 = string.Empty;
                    string flpPhotourl3 = string.Empty;
                    string flpPhotourl4 = string.Empty;
                    string flpPhotourl5 = string.Empty;
                    string flpPhotourl6 = string.Empty;
                    string flpPhotourl7 = string.Empty;
                    string flpPhotourl8 = string.Empty;
                    string flpPhotourl9 = string.Empty;
                    string flpPhotourl10 = string.Empty;
                    string flpPhotourl11 = string.Empty; 
                    string flpPhotourl12 = string.Empty;
                    string ChallanAttachment = string.Empty;
                    string LineLength = string.Empty;
                    string FeesLeft = string.Empty; 
                    string transcationId = string.Empty;
                    string TranscationDate = string.Empty;
                    int maxFileSize = 1048576;
                    
                    IntimationId = Session["id"].ToString();
                    Count = lblNoOfInstallations.Trim();
                    DataSet ds = new DataSet();
                    ds = CEI.GetData(lblCategory.Trim(), IntimationId, Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (lblCategory.Trim() == "Line")
                        {
                            id = ds.Tables[0].Rows[0]["ID"].ToString();
                            LineLength = ds.Tables[0].Rows[0]["LineLength"].ToString();
                        }
                        else
                        {
                            id = ds.Tables[0].Rows[0]["ID"].ToString();
                        }
                    }
                    #region asign code
                    //if (lblCategory.Trim() == "Line")
                    //{
                    //    if (input.EndsWith("kv", StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        string voltagePart = input.Substring(0, input.Length - 2);
                    //        if (int.TryParse(voltagePart, out int voltageLevel))
                    //        {
                    //            if (voltageLevel >= 11 && voltageLevel <= 33)
                    //            {
                    //                Assign = "SDO";
                    //            }
                    //            else if (voltageLevel >= 33)

                    //            {
                    //                Assign = "Admin@123";
                    //            }
                    //            else if (voltageLevel <= 11)

                    //            {
                    //                Assign = "JE";
                    //            }

                    //        }
                    //    }

                    //    else if (input.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        Assign = "JE";

                    //    }
                    //}
                    //else
                    //{
                    //    if (input.EndsWith("KVA", StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        string voltagePart = input.Substring(0, input.Length - 3);
                    //        if (int.TryParse(voltagePart, out int voltageLevel))
                    //        {
                    //            if (voltageLevel >= 250 && voltageLevel <= 500)
                    //            {
                    //                Assign = "XEN";
                    //            }
                    //            else if (voltageLevel >= 500)

                    //            {
                    //                Assign = "Admin@123";
                    //            }
                    //            else if (voltageLevel >= 50 && voltageLevel <= 250)
                    //            {
                    //                Assign = "SDO";
                    //            }
                    //            else
                    //            {
                    //                Assign = "JE";
                    //            }
                    //        }

                    //    }
                    //    else if (input.EndsWith("MVA", StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        Assign = "Admin@123";

                    //    }

                    //}
                    #endregion


                    if (LineSubstationSupplier.Visible == true)
                    {
                        fileExtension = Path.GetExtension(FileUpload1.FileName);

                        if (fileExtension.ToLower() == ".pdf")
                        {
                            if (FileUpload1.PostedFile.ContentLength <= maxFileSize)

                            {
                                FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/"));
                                }

                                string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/";
                                string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/" + fileName);
                                FileUpload1.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl = path + fileName;
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                        }
                        fileExtension2 = Path.GetExtension(FileUpload2.FileName);

                        if (fileExtension2.ToLower() == ".pdf")
                        {
                            if (FileUpload2.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/"));
                                }

                                string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/";
                                string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/" + fileName);
                                FileUpload2.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl1 = path + fileName;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                        }
                    }
                    if (SupplierSub.Visible == true)
                    {
                        fileExtension = Path.GetExtension(FileUpload3.FileName);

                        if (fileExtension.ToLower() == ".pdf")
                        {
                            if (FileUpload3.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/"));
                                }

                                string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/";
                                string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/" + fileName);
                                FileUpload3.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl2 = path + fileName;
                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                            }
                        }
                    }
                    if (LinePersonal.Visible == true)
                    {
                        fileExtension = Path.GetExtension(FileUpload12.FileName);

                        if (fileExtension.ToLower() == ".pdf")
                        {
                            if (FileUpload12.PostedFile.ContentLength <= maxFileSize)
                            {
                                //FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                                //if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/")))
                                //{
                                //    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/"));
                                //}

                                //string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
                                //string path = "";
                                //path = "/Attachment/" + CreatedBy + "/DemandNoticeOfLine/";
                                //string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                //string filePathInfo2 = "";
                                //filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
                                //FileUpload12.PostedFile.SaveAs(filePathInfo2);
                                //flpPhotourl3 = path + fileName;

                                string fileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                                string directoryPath = Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/");
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                string ext = fileName.Split('.')[1];
                                string uniqueFileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePath = Path.Combine(directoryPath, uniqueFileName);

                                FileUpload12.PostedFile.SaveAs(filePath);
                                flpPhotourl3 = "/Attachment/" + CreatedBy + "/DemandNoticeOfLine/" + uniqueFileName;


                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }

                    }
                    if (PersonalSub.Visible == true)
                    {
                        fileExtension = Path.GetExtension(FileUpload4.FileName);

                        if (fileExtension.ToLower() == ".pdf")
                        {
                            if (FileUpload4.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
                                }

                                string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
                                string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
                                FileUpload4.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl4 = path + fileName;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                        }
                        fileExtension2 = Path.GetExtension(FileUpload5.FileName);

                        if (fileExtension2.ToLower() == ".pdf")
                        {
                            if (FileUpload5.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfTransferOfPersonalSubstation/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfTransferOfPersonalSubstation/"));
                                }

                                string ext = FileUpload5.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/InvoiceOfTransferOfPersonalSubstation/";
                                string fileName = "InvoiceOfTransferOfPersonalSubstation" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfTransferOfPersonalSubstation/" + fileName);
                                FileUpload5.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl5 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }

                        fileExtension3 = Path.GetExtension(FileUpload6.FileName);

                        if (fileExtension3.ToLower() == ".pdf")
                        {
                            if (FileUpload6.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload6.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestCertificateOfTransformer/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestCertificateOfTransformer/"));
                                }

                                string ext = FileUpload6.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/ManufacturingTestCertificateOfTransformer/";
                                string fileName = "ManufacturingTestCertificateOfTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestCertificateOfTransformer/" + fileName);
                                FileUpload6.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl6 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                            }
                        }

                        fileExtension4 = Path.GetExtension(FileUpload7.FileName);

                        if (fileExtension4.ToLower() == ".pdf")
                        {
                            if (FileUpload7.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload7.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramofTransformer/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramofTransformer/"));
                                }

                                string ext = FileUpload7.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/SingleLineDiagramofTransformer/";
                                string fileName = "SingleLineDiagramofTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramofTransformer/" + fileName);
                                FileUpload7.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl7 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                            }
                        }

                        fileExtension3 = Path.GetExtension(FileUpload8.FileName);

                        if (fileExtension3.ToLower() == ".pdf")
                        {
                            if (FileUpload8.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload8.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceoffireExtinguisheratSite/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceoffireExtinguisheratSite/"));
                                }

                                string ext = FileUpload8.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/InvoiceoffireExtinguisheratSite/";
                                string fileName = "InvoiceoffireExtinguisheratSite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceoffireExtinguisheratSite/" + fileName);
                                FileUpload8.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl8 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }

                    }
                    if (PersonalGenerating.Visible == true)
                    {
                        fileExtension = Path.GetExtension(FileUpload9.FileName);

                        if (fileExtension.ToLower() == ".pdf")
                        {
                            if (FileUpload9.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/"));
                                }
                                string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/";
                                string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
                                FileUpload9.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl9 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }
                        else
                        {

                        }

                        fileExtension2 = Path.GetExtension(FileUpload10.FileName);

                        if (fileExtension2.ToLower() == ".pdf")
                        {
                            if (FileUpload10.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/"));
                                }

                                string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/";
                                string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/" + fileName);
                                FileUpload10.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl10 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }

                        fileExtension3 = Path.GetExtension(FileUpload13.FileName);

                        if (fileExtension3.ToLower() == ".pdf")
                        {
                            if (FileUpload13.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
                                }

                                string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/";
                                string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
                                FileUpload13.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl11 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }

                        fileExtension4 = Path.GetExtension(FileUpload11.FileName);

                        if (fileExtension4.ToLower() == ".pdf")
                        {
                            if (FileUpload11.PostedFile.ContentLength <= maxFileSize)
                            {
                                FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/"));
                                }
                                string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/";
                                string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
                                FileUpload11.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl12 = path + fileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                            }
                        }

                    }
                    //DateTime myDate = Convert.ToDateTime(txtDate.Text);

                    if (ChallanDetail.Visible == true)
                    {
                        if (FileUpload14.HasFile && FileUpload14.PostedFile.ContentLength <= 500 * 1024) 
                        {
                            string ext = Path.GetExtension(FileUpload14.PostedFile.FileName).ToLower();

                            if (ext == ".pdf") // Check if the file extension is PDF
                            {
                                FileName = "ChallanReport" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/"));
                                }
                                string path = "/Attachment/" + CreatedBy + "/ChallanReport/";
                                string filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/" + FileName);

                                FileUpload14.SaveAs(filePathInfo2);
                                ChallanAttachment = path + FileName;
                            }
                            else
                            {
                                string alert = "alert('File Format Not Supported. Only PDF files are allowed.');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                                return;
                            }
                        }
                        else
                        {
                            string alert = "alert('File exceeds maximum size limit (500 KB) or no file uploaded.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                            return;
                        }

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

                    //CEI.InsertInspectionData(txtContact.Text, id, ApplicantTypeCode, IntimationId, PremisesType, lblApplicant.Trim(), lblCategory.Trim(), lblVoltageLevel.Trim(),
                    //    LineLength, Count, flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7, flpPhotourl8,
                    //flpPhotourl9, flpPhotourl10, flpPhotourl11, flpPhotourl12,/* Assign,*/ District, To, txtDate.Text, CreatedBy,txtPayment.Text.Trim(), transcationId, TranscationDate,ChallanAttachment);


                    // string generatedId = CEI.InspectionId();                    
                    //  Session["PendingPaymentId"] = generatedId;
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectData();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
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
        protected void ddlDocumentFor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewBind()
        {
            try
            {
                LoginId = Session["SiteOwnerId"].ToString();
                IntimationIds = Session["PendingIntimations"].ToString();  // modeified IntimationId to IntimationIds
                DataSet ds = new DataSet();
                ds = CEI.GetPaymentInformation(LoginId, IntimationIds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    //GridView1.DataSource = null;
                    //string script = "alert(\"Please Fill the Form first for knowing Payment History\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                ds.Dispose();
                string TotalPayment = CEI.GetTotalPaymentInformation(LoginId, IntimationId);
                txtPayment.Text = TotalPayment;
                
                
            }
            catch (Exception ex )
            {
            //
            }
        }

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
    }
} 