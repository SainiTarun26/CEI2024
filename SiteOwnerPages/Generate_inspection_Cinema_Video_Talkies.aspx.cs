using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Generate_inspection_Cinema_Video_Talkies : System.Web.UI.Page
    {
        //Created By  gurmeet  23-May-2025
        CEI CEI = new CEI();
        int inspectionIdRes,inspectionCountRes = 0;       
        private static string ApplicantTypeCode, id, Category, Count, PaymentMode, InstallationId, IntstallationType,
        ApplicantType, InspectionType, district;
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();
        
        string TestReportId = string.Empty;
        string IntimationId = string.Empty;
        private int totalQuantity = 0;
        private decimal totalAmountSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    Session["CinemaAmount"] = "";                    
                    if (Convert.ToString(Session["IntimationId_Cinema"]) != null && Convert.ToString(Session["IntimationId_Cinema"]) != "")
                    {
                        getWorkIntimationData(Convert.ToString(Session["IntimationId_Cinema"]));
                    }
                    //getWorkIntimationData();
                    Session["PreviousPage"] = Request.Url.ToString();
                    Grd_Document.RowDataBound += Grd_Document_RowDataBound;
                    //GetDocumentUploadData("","",0);
                }
                else
                {
                    Response.Redirect("~/LogOut.aspx", false);
                }
            }
        }
        private void getWorkIntimationData(string IntimationId)
        {           
            DataSet ds = new DataSet();
            //ds = CEI.SiteOwnerInstallations_Lift(IntimationId);
            ds = CEI.SiteOwnerInstallations_Cinema(IntimationId);
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
        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int CinemaCount = 0;
                foreach (GridViewRow rows in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                    if (chk != null && chk.Checked)
                    {
                        CinemaCount++;
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
                    Label lblApplicantTypeCode = (Label)row.FindControl("lblApplicantTypeCode");
                    Label lblTypeOfPlant = (Label)row.FindControl("LblTypeofPlant");
                    Label lblReportType = (Label)row.FindControl("lblReportType");
                    Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                    //Session["lblIntimationId"] = lblIntimationId.Text;
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    TestReportId = lblTestReportId.Text;
                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");                  

                    inspectionCountRes = Convert.ToInt32(((HtmlInputHidden)row.FindControl("InspectionCount")).Value.Replace("\r\n", ""));
                    inspectionIdRes = Convert.ToInt32(((HtmlInputHidden)row.FindControl("InspectionId")).Value.Replace("\r\n", ""));
                    
                    string CreatedBy = Session["SiteOwnerId"].ToString();                    
                    HdnApplicantType.Value = lblApplicant.Text;
                    HdnDivision.Value = lblDivision.Text;
                    HdnDistrict.Value = lblDistrict.Text;
                    ApplicantTypeCode = lblApplicantTypeCode.Text;
                    Category = lblCategory.Text;
                    Hdn_IntimationID.Value = lblIntimationId.Text;
                    Hdn_ApplicantTypeCode.Value = lblIntimationId.Text;

                    if (Session["Duplicacy"].ToString().Trim() == "0")
                    {
                        CEI.DeleteduplicateHistory(lblIntimationId.Text, CreatedBy);
                        Session["Duplicacy"] = "1";
                    }
                    else
                    {

                    }
                    //id = Session["lblIntimationId"].ToString();
                    //DataTable dt = new DataTable();
                    //dt = CEI.GetApplicantCode(lblCategory.Text);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    InstallationId = dt.Rows[0]["Id"].ToString();
                    //}
                    //else
                    //{

                    //}

                    if (chk.Checked)
                    {
                        //CEI.InsertPaymentHistory_Lift(id, int.Parse(lblNoOfInstallations.Text), 11,//int.Parse(InstallationId),
                        //    CreatedBy);
                        CEI.InsertPaymentHistory_Lift(lblIntimationId.Text, int.Parse(lblNoOfInstallations.Text), 11,//int.Parse(InstallationId),
                            CreatedBy);
                    }
                    else
                    {
                        //CEI.DeletePaymentHistory(id, int.Parse(lblNoOfInstallations.Text), int.Parse(InstallationId), CreatedBy);
                        CEI.DeletePaymentHistory(lblIntimationId.Text, int.Parse(lblNoOfInstallations.Text), 11, CreatedBy);
                    }
                    InspectionType = "New";                           
                    UploadDocuments.Visible = true;
                    FeesDetails.Visible = true;
                    PaymentDetails.Visible = true;
                    btnSubmit.Visible = true;
                    
                    Declaration.Visible = true;                    
                    GetDocumentUploadData(ApplicantTypeCode, InspectionType, inspectionIdRes);
                    
                    PaymentGridViewBind("New", CinemaCount);
                    string Installationtypes = string.Empty;                                       
                    hdnInstallationType.Value = Installationtypes;
                    //GetOtherDetails_ForReturnedInspection(inspectionIdRes);
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
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    //if (lblCategory.Text.Trim() == "Lift")
                    //{
                    Session["TestReportId"] = lblTestReportId.Text;
                    Response.Redirect("/SiteOwnerPages/Cinema_Video_Talkies_TestReport_Modal.aspx", false);
                    //}                    
                }
            }
            catch (Exception)
            {
            }
        }
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
        private void GetDocumentUploadData(string ApplicantType, string InspectionType, int inspectionIdPrm)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlistfornewInspection_Cinema(ApplicantType, 11, "New", inspectionIdPrm);
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
                        //customFile.Visible = true;
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
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
                        if (Check.Checked == true)
                        {
                            string District = HdnDistrict.Value;
                            string AssignedOfficer = "";
                            DataTable dt = new DataTable();
                            dt = CEI.FetchOfficerFor_Accidental(District, "XEN");
                            if (dt == null || dt.Rows.Count < 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('please Contact Team');", true);
                                return;
                            }
                            AssignedOfficer = dt.Rows[0]["StaffUserID"].ToString();
                            
                            
                            ApplicantType = HdnApplicantType.Value;
                            string Division = HdnDivision.Value;
                            string transcationId = string.Empty;
                            string TranscationDate = string.Empty;
                            decimal TotalAmount = Convert.ToDecimal(Session["CinemaAmount"]);                           
                            string InstallationTypeID = string.Empty;
                            IntimationId = Hdn_IntimationID.Value;
                            ApplicantTypeCode = Hdn_ApplicantTypeCode.Value;
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

                            InstallationTypeID = "11";
                            IntstallationType = "Cinema_Videos Talkies";
                            InsertFilesIntoDatabase(InstallationTypeID, CreatedBy, txtContact.Text, ApplicantTypeCode, IntimationId, ApplicantType, IntstallationType,
                            District, Division, PaymentMode, txtInspectionRemarks.Text.Trim(), CreatedBy, TotalAmount, AssignedOfficer, transcationId, TranscationDate, Convert.ToInt32(InspectionIdClientSideCheckedRow.Value) );
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please accept declaration first to proceed')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please First tick the any one installation for inspection')", true);
                    }
                }
                catch (Exception ex)
                {
                 throw;
                }
            }
            else
            {
                Response.Redirect("~/LogOut.aspx", false);
            }
        }
        public void UploadCheckListDocInCollection( string CreatedBy, string intimationids, string InstallTypes, string InspectionId)
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
                   // string CreatedBy = CreatedByy;
                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")
                    {
                        if (fileUpload.PostedFile.ContentLength <= 1048576)
                        {
                            string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId + "/" + InstallTypes + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId + "/" + InstallTypes + "/"));
                            }
                            string ext = fileUpload.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId + "/" + InstallTypes + "/";                          
                            string fileName = DocSaveName + ".pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId + "/" + InstallTypes + "/" + fileName);
                            fileUpload.PostedFile.SaveAs(filePathInfo2);
                            uploadedFiles.Add((InstallTypes, DocumentID, DocName, fileName, path + fileName));
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

        protected void PaymentGridViewBind(string InspectionType, int CinemaCount)
        {
            try
            {
                DataTable ds = new DataTable();
                //ds = CEI.Payment_Lift(selectedType, LiftCount, EscaltorCount);
                ds = CEI.Payment_CinemaInspection(InspectionType, CinemaCount);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    GridViewPayment.DataSource = ds;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Check atleast one CheckBox. \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                    UploadDocuments.Visible = false;
                    FeesDetails.Visible = false;
                    PaymentDetails.Visible = false;
                    btnSubmit.Visible = false;
                    //btnReset.Visible = false;
                    Declaration.Visible = false;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
        protected void GridViewPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                decimal totalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                // Update the footer totals
                totalQuantity += quantity;
                totalAmountSum += totalAmount;
            }
            // Check if the row is a footer row to display the totals
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblFooterQuantity = (Label)e.Row.FindControl("lblFooterQuantity");
                Label lblFooterAmount = (Label)e.Row.FindControl("lblFooterAmount");

                lblFooterQuantity.Text = totalQuantity.ToString();
                lblFooterAmount.Text = totalAmountSum.ToString();
                Session["CinemaAmount"] = totalAmountSum.ToString();
            }
        }
        public void InsertFilesIntoDatabase(string InstallationTypeID, string para_CreatedBy, string para_txtContact, string para_ApplicantTypeCode, string para_IntimationId, string para_lblApplicant, string IntstallationType,
          string para_District, string para_To, string para_PaymentMode, string para_txtInspectionRemarks, string para_CreatedByy, decimal para_TotalAmount, string para_Assigned, string para_transcationId, string para_TranscationDate, int para_InspectID
          )
        {
            bool isInsertSuccessful = true;           
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    Session["Duplicacy"] = "2";
                    CEI.InsertInspectionDataNewCode_CinemaVideoTalkis(para_txtContact, para_ApplicantTypeCode, para_IntimationId, para_lblApplicant, IntstallationType,
                    para_District, para_To, para_PaymentMode, para_txtInspectionRemarks, para_CreatedByy, para_TotalAmount, para_Assigned, para_transcationId, para_TranscationDate, para_InspectID, transaction);
                    string generatedIdCombinedDetails = CEI.InspectionId();
                    string[] SplitResultPartsArray = generatedIdCombinedDetails.Split('|');                   
                    string InspectionId = SplitResultPartsArray[0]; // Extract the first value
                    Session["PrintInspectionID"] = InspectionId;
                    //Insert the uploaded files into the database
                    UploadCheckListDocInCollection(para_CreatedByy, SplitResultPartsArray[1], IntstallationType, InspectionId);
                    if (uploadedFiles != null && uploadedFiles.Count > 0)
                    {
                        foreach (var file in uploadedFiles)
                        {
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
                    }
                    else
                    {
                        throw new Exception("Please Upload Pdf Files");
                    }
                    transaction.Commit();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

                }
                catch (Exception ex)
                {
                    isInsertSuccessful = false;
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                }
                finally
                {
                    connection.Close();
                }                
            }
        }
    }   
}