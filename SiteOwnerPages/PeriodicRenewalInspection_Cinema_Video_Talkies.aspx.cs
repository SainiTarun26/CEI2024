using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class PeriodicRenewalInspection_Cinema_Video_Talkies : System.Web.UI.Page
    {
        //Cretaed By Neha 23-May-2025
        CEI CEI = new CEI();
        //region Gurmeet changed on 23-May-2025
        string IntimationId,District, ApplicantTypeCode, ApplicantType, Division, CreatedBy, transcationId, InstallationTypeID, IntstallationType , TranscationDate, AssignedOfficer, PaymentMode = string.Empty;
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        String ownerID = Convert.ToString(Session["SiteOwnerId"]);
                        HFOwnerID.Value = ownerID;
                        BindAddress(ownerID);
                    }
                    else
                    {
                        Response.Redirect("LogOut.aspx", false);
                    }
                }
            }
            catch
            {
                Response.Redirect("LogOut.aspx", false);
            }
        }

        private void BindAddress(string ownerID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetSiteAddress_ForCinemaTalkies(ownerID);
                ddlAddress.DataSource = ds;
                ddlAddress.DataTextField = "Address";
                ddlAddress.DataValueField = "Address";
                ddlAddress.DataBind();
                ddlAddress.Items.Insert(0, new ListItem("Select", "0"));
                ds.Clear();
            }
            catch (Exception)
            {
                Response.Redirect("LogOut.aspx", false);
            }
        }
        protected void ddlAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.Visible = true;
            GridViewBind();          
            //Changed By Gurmeet 23-May-2025
           // PaymentDetails.Visible = true;
        }
        private void GridViewBind()
        {
            string OwnerId = HFOwnerID.Value;
            string Address = ddlAddress.SelectedItem.Text;
            DataSet ds = new DataSet();
            ds = CEI.GetDetails_ForCinemaTalkies(Address, OwnerId);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
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
                    //Changed By Gurmeet 23-May-2025
                    Session["CinemaAmount"] = ds.Rows[0]["TotalAmount"].ToString();
                    GridViewPayment.DataSource = ds;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Check atleast one CheckBox. \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
        //protected void GridViewPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
        //        decimal totalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
        //        // Update the footer totals
        //        totalQuantity += quantity;
        //        totalAmountSum += totalAmount;
        //    }
        //    // Check if the row is a footer row to display the totals
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        Label lblFooterQuantity = (Label)e.Row.FindControl("lblFooterQuantity");
        //        Label lblFooterAmount = (Label)e.Row.FindControl("lblFooterAmount");

        //        lblFooterQuantity.Text = totalQuantity.ToString();
        //        lblFooterAmount.Text = totalAmountSum.ToString();
        //        Session["CinemaAmount"] = totalAmountSum.ToString();
        //    }
        //}
        #region Gurmeet 23-May-2025
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox lastCheckedBox = null;
                bool atLeastOneChecked = false;
                bool multipleIntimationIDSelected = false;
                string selectedIntimationValue = null;
                int CinemaCount = 0;
                string ApplicantTypeCode=string.Empty;
                foreach (GridViewRow rows in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                    if (chk != null && chk.Checked)
                    {
                        CinemaCount++;
                    }
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                    Label LblIntimationId = (Label)row.FindControl("LblIntimationId") as Label;
                    Label LblApplicantTypeCode = (Label)row.FindControl("LblApplicantTypeCode") as Label;
                    if (chk != null && LblIntimationId != null)
                    {
                        string IbtimationIDValue = LblIntimationId.Text.Trim();
                        if (chk.Checked)
                        {
                            atLeastOneChecked = true;
                            lastCheckedBox = chk;
                            if (selectedIntimationValue == null)
                            {
                                selectedIntimationValue = IbtimationIDValue;
                                ApplicantTypeCode = LblApplicantTypeCode.Text;
                            }
                            if (IbtimationIDValue != selectedIntimationValue)
                            {
                                multipleIntimationIDSelected = true;
                                break;
                            }
                        }
                    }
                }
                if (multipleIntimationIDSelected)
                {
                    if (lastCheckedBox != null)
                    {
                        lastCheckedBox.Checked = false;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select only checkboxes for the same IntimationId');", true);
                    return;
                }
                string InspectionType = "Periodic";
                PaymentDetails.Visible = true;
                Div_feesDetails.Visible = true;
                PaymentGridViewBind(InspectionType, CinemaCount);
                GetDocumentUploadData(ApplicantTypeCode, InspectionType);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void GetDocumentUploadData(string ApplicantType, string InspectionType)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlistfornewInspection_Cinema(ApplicantType, 19, InspectionType, 0);
            if (ds.Rows.Count > 0)
            {
                UploadDocuments.Visible = true;
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                UploadDocuments.Visible = false;
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
            string TestReportId = LblTestReportId.Text;

            Session["TestReportId"] = TestReportId;
            //Only link change by navneet 2-July-2025
            Response.Write("<script>window.open('/TestReportModal/Cinema_Video_Talkies_TestReport_Modal_Periodic.aspx','_blank');</script>");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["IntimationId_LiftEscalator"]) != null)
                {
                    CreatedBy = Convert.ToString(Session["SiteOwnerId"]);
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        Label LblIntimationId = (Label)row.FindControl("LblIntimationId") ;                                                                                      
                        if (chk != null && LblIntimationId != null)
                        {
                            string IbtimationIDValue = LblIntimationId.Text.Trim();
                            if (chk.Checked)
                            {
                                Label LblApplicantType = (Label)row.FindControl("LblApplicantType");
                                Label LblApplicantTypeCode = (Label)row.FindControl("LblApplicantTypeCode") as Label;
                                Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                                Label LblDistrict = (Label)row.FindControl("LblDistrict");
                                Label LblDivision = (Label)row.FindControl("LblDivision");
                                ApplicantType = LblApplicantType.Text;
                                ApplicantTypeCode = LblApplicantTypeCode.Text;
                                District = LblDistrict.Text;
                                Division = LblDivision.Text;
                                IntimationId = lblIntimationId.Text;
                                break;
                            }
                        }
                    }
                    decimal TotalAmount = Convert.ToDecimal(Session["CinemaAmount"]);                    
                    //assigned officer changes by navneet on instructions of vinod sir
                    AssignedOfficer = "CEI";

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
                    if (RadioButtonList2.SelectedValue != null)
                    {
                        PaymentMode = RadioButtonList2.SelectedItem.ToString();
                    }
                    InstallationTypeID = "19";
                    IntstallationType = "Cinema_Videos Talkies";
                    InsertFilesIntoDatabase(InstallationTypeID, ApplicantTypeCode, IntimationId, ApplicantType, IntstallationType,
                    District, Division, PaymentMode, CreatedBy, TotalAmount, AssignedOfficer, transcationId, TranscationDate);
                }
                else
                {
                    Response.Redirect("LogOut.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertFilesIntoDatabase(string InstallationTypeID,  string para_ApplicantTypeCode, string para_IntimationId, string para_lblApplicant, string IntstallationType,
         string para_District, string Division, string para_PaymentMode,  string para_CreatedByy, decimal para_TotalAmount, string para_Assigned, string para_transcationId, string para_TranscationDate
        )
        {
            bool isInsertSuccessful = true;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {                   
                    CEI.InsertInspectionDataNewCode_CinemaVideoTalkis(para_ApplicantTypeCode, para_IntimationId, para_lblApplicant, IntstallationType,
                    para_District, Division, para_PaymentMode, para_CreatedByy, para_TotalAmount, para_Assigned, para_transcationId, para_TranscationDate, transaction);
                    string generatedIdCombinedDetails = CEI.InspectionId();
                    string[] SplitResultPartsArray = generatedIdCombinedDetails.Split('|');
                    string NewInspectionId = SplitResultPartsArray[0]; // Extract the first value
                    //Session["PrintInspectionID"] = InspectionId;
                    //Insert the uploaded files into the database
                    UploadCheckListDocInCollection(para_CreatedByy, SplitResultPartsArray[1], IntstallationType, NewInspectionId);
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
                                command.Parameters.AddWithValue("@CreatedBy", para_CreatedByy);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Please Upload Pdf Files");
                    }

                   string OldInspectionId = "";
                   foreach (GridViewRow rows in GridView1.Rows)
                   {
                       CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");
                       if (chk != null && chk.Checked)
                       {
                           Label lblIntimationId = (Label)rows.FindControl("lblIntimationId");
                           Label lblInspectionId = (Label)rows.FindControl("lblInspectionId"); 
                           Label lblTestReportCount = (Label)rows.FindControl("LblTestReportCount");
                           OldInspectionId = lblInspectionId.Text;
                           CEI.UpdateInstallationHistory_ForPeriodicCinema(lblTestReportCount.Text,OldInspectionId, lblIntimationId.Text, para_CreatedByy, NewInspectionId);
                       }
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
        public void UploadCheckListDocInCollection(string CreatedBy, string intimationids, string InstallTypes, string InspectionId)
        {
            foreach (GridViewRow row in Grd_Document.Rows)
            {
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                string Req = ((HtmlInputHidden)row.FindControl("Req")).Value.Replace("\r\n", "");
                string DocSaveName = ((HtmlInputHidden)row.FindControl("DocumentShortName")).Value.Replace("\r\n", "");
                string DocumentID = ((HtmlInputHidden)row.FindControl("DocumentID")).Value.Replace("\r\n", "");
                string DocName = row.Cells[1].Text.Replace("\r\n", "");
                //if (Convert.ToInt32(InspectionIdClientSideCheckedRow.Value) == 0)
                //{
                    if (Req == "1")
                    {
                        if (!fileUpload.HasFile && Req == "1")
                        {
                            string message = DocName + " is mandatory to upload.";
                            throw new Exception(message);
                        }
                    }
                //}
                if (fileUpload.HasFile)
                {                   
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
        #endregion

    }
}