using CEI_PRoject;
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
        //string id = string.Empty;
        string fileExtension = string.Empty;
        string fileExtension2 = string.Empty;
        string fileExtension3 = string.Empty;
        string fileExtension4 = string.Empty;
        string IntimationId = string.Empty;
        // string Count = string.Empty;
        private static string PremisesType, ApplicantTypeCode, id, Category, InstallationTypeId, Count, PaymentMode,
            ApplicantType, InstallationType, AssigDesignation, InspectionType, PlantLocation;
        private static int TotalAmount;
        string LoginId = string.Empty;
        //string id = string.Empty;
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();

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
                    Label lblDesignation = (Label)row.FindControl("lblDesignation");
                    Label lblTypeOfPlant = (Label)row.FindControl("LblTypeofPlant");


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
                    }

                    if (chk.Checked)
                    {
                        TotalPayment.Visible = true;
                        ChallanDetail.Visible = true;

                        txtInspectionDetails.Text = Session["SiteOwnerId"].ToString() + "-" + lblCategory.Text + "-" + lblVoltageLevel.Text;
                        Session["SelectedCategory"] = lblCategory.Text;
                        Session["SelectedApplicant"] = lblApplicant.Text;
                        Session["SelectedVoltageLevel"] = lblVoltageLevel.Text;
                        Session["SelectedDivision"] = lblDivision.Text;
                        Session["SelectedDistrict"] = lblDistrict.Text;
                        Session["SelectedNoOfInstallations"] = lblNoOfInstallations.Text;
                        PremisesType = lblPremises.Text;
                        ApplicantTypeCode = lblApplicantTypeCode.Text;
                        Category = lblCategory.Text;
                        Count = lblNoOfInstallations.Text;

                        ApplicantType = lblApplicant.Text;
                        if (ApplicantType == "Private/Personal Installation")
                        {
                            ApplicantType = "Private And Personal";
                        }
                        InspectionType = "New";
                        AssigDesignation = lblDesignation.Text;
                        PlantLocation = lblTypeOfPlant.Text;

                        UploadDocuments.Visible = true;
                        FeesDetails.Visible = true;
                        PaymentDetails.Visible = true;
                        btnSubmit.Visible = true;
                        btnReset.Visible = true;



                        GetDocumentUploadData(ApplicantType, Category, InspectionType, AssigDesignation, PlantLocation);
                        PaymentGridViewBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //Handle the exception appropriately
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

                    if (ChallanDetail.Visible == true)
                    {
                        //if (FileUpload14.HasFile && FileUpload14.PostedFile.ContentLength <= 500 * 1024)
                        //{
                        //    string ext = Path.GetExtension(FileUpload14.PostedFile.FileName).ToLower();

                        //    if (ext == ".pdf") // Check if the file extension is PDF
                        //    {
                        //        FileName = "ChallanReport" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                        //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/")))
                        //        {
                        //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/"));
                        //        }
                        //        string path = "/Attachment/" + CreatedBy + "/ChallanReport/";
                        //        string filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/" + FileName);

                        //        FileUpload14.SaveAs(filePathInfo2);
                        //        ChallanAttachment = path + FileName;
                        //    }
                        //    else
                        //    {
                        //        string alert = "alert('File Format Not Supported. Only PDF files are allowed.');";
                        //        ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    string alert = "alert('File exceeds maximum size limit (500 KB) or no file uploaded.');";
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                        //    return;
                        //}

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

                    InsertFilesIntoDatabase(CreatedBy, txtContact.Text, id, ApplicantTypeCode, IntimationId, PremisesType, lblApplicant.Trim(), lblCategory.Trim(), lblVoltageLevel.Trim(),
                    LineLength, Count, District, To, PaymentMode, txtDate.Text, CreatedBy, TotalAmount, transcationId, TranscationDate, ChallanAttachment);


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
                if (Req == "1")

                {

                    if (!fileUpload.HasFile && Req == "1")
                    {
                        string message = DocName + " is mandatory to upload.";
                        throw new Exception(message);

                    }

                }


                if (fileUpload.HasFile)
                {
                    string CreatedBy = CreatedByy;
                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")

                    {

                        if (fileUpload.PostedFile.ContentLength <= 2097152)
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
                            string fileName = DocSaveName + "." + ext;

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/" + fileName);

                            fileUpload.PostedFile.SaveAs(filePathInfo2);

                            uploadedFiles.Add((Category, DocumentID, DocName, fileName, path + fileName));

                        }
                        else
                        {
                            throw new Exception("Please Upload Pdf Files Less Than 2 Mb Only");
                        }
                    }
                    else
                    {
                        throw new Exception("Please Upload Pdf Files Only");
                    }
                }

            }

        }

        public void InsertFilesIntoDatabase(string para_CreatedBy, string para_txtContact, string para_id, string para_ApplicantTypeCode, string para_IntimationId, string para_PremisesType, string para_lblApplicant, string para_lblCategory, string para_lblVoltageLevel,
                  string para_LineLength, string para_Count, string para_District, string para_To, string para_PaymentMode, string para_txtDate, string para_CreatedByy, int para_TotalAmount, string para_transcationId, string para_TranscationDate, string para_ChallanAttachment)
        {
            // Insert the uploaded files into the database
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    CEI.InsertInspectionDataNewCode(para_txtContact, para_id, para_ApplicantTypeCode, para_IntimationId, para_PremisesType, para_lblApplicant, para_lblCategory, para_lblVoltageLevel,
                    para_LineLength, para_Count, para_District, para_To, para_PaymentMode, para_txtDate, para_CreatedByy, para_TotalAmount, para_transcationId, para_TranscationDate, para_ChallanAttachment, transaction);

                    string generatedIdCombinedDetails = CEI.InspectionId();
                    string[] SplitResultPartsArray = generatedIdCombinedDetails.Split('|');
                    Session["PendingPaymentId"] = SplitResultPartsArray[0];
                    UploadCheckListDocInCollection(SplitResultPartsArray[2], para_CreatedByy, SplitResultPartsArray[1], SplitResultPartsArray[2], SplitResultPartsArray[3]);

                    
                    foreach (var file in uploadedFiles)
                    {
                        string query = "INSERT INTO tbl_InspectionAttachment (InspectionId,InstallationType,DocumentID,DocumentName,fileName, DocumentPath,CreatedDate,CreatedBy,Status) VALUES (@InspectionId,@InstallationType,@DocumentID,@DocSaveName,@FileName, @FilePath,getdate(),@CreatedBy,1)";

                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@InspectionId", SplitResultPartsArray[0]);
                            command.Parameters.AddWithValue("@InstallationType", null); //file.Installtypes
                            command.Parameters.AddWithValue("@DocumentID", file.DocumentID);
                            command.Parameters.AddWithValue("@DocSaveName", file.DocSaveName);
                            command.Parameters.AddWithValue("@FileName", file.FileName);
                            command.Parameters.AddWithValue("@FilePath", file.FilePath);
                            command.Parameters.AddWithValue("@CreatedBy", para_CreatedBy);
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Request Submitted Successfully')", true);
                    Session["PrintInspectionID"] = id.ToString();
                    //Response.Redirect("/SiteOwnerPages/InspectionRequestPrint.aspx", false);
                    
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Please Upload Pdf Files Only")
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                        return;
                    }
                    else if (ex.Message == "Please Upload Pdf Files Less Than 2 Mb Only")
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

        protected void PaymentGridViewBind()
        {
            try
            {
                if (Category == "Line")
                {
                    InstallationTypeId = "1";
                }
                else if (Category == "Substation Transformer")
                {
                    InstallationTypeId = "2";
                }
                else if (Category == "Generating Set")
                {
                    InstallationTypeId = "3";
                }

                DataTable ds = new DataTable();
                ds = CEI.Payment(id, Count, InstallationTypeId);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    GridViewPayment.DataSource = ds;
                    GridViewPayment.DataBind();
                    TotalAmount = Convert.ToInt32(GridViewPayment.Rows[0].Cells[3].Text);
                    //      txtPayment.Text = Convert.ToString(TotalAmount);
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Fill the Form first for knowing Payment \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
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

        private void GetDocumentUploadData(string ApplicantType, string Category, string InspectionType, string AssigDesignation, string PlantLocation)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlist(ApplicantType, Category, InspectionType, AssigDesignation, PlantLocation);
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
    }
}