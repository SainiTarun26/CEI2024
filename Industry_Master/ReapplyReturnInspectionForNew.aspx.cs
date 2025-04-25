using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class ReapplyReturnInspectionForNew : System.Web.UI.Page
    {
        CEI CEI = new CEI();       
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hnOwnerId.Value = "";
                    hnReturnStatus.Value = "";
                    if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && !string.IsNullOrEmpty(Convert.ToString(Session["SiteOwnerId_Sld_Indus"]).ToString()) && Convert.ToString(Session["InspId"]) != null && !string.IsNullOrEmpty(Convert.ToString(Session["InspId"]).ToString()))
                    {
                        hnOwnerId.Value = Session["SiteOwnerId_Sld_Indus"].ToString();
                        txtInspectionId.Text = Session["InspId"].ToString();
                        GetInspectionDetails(txtInspectionId.Text);
                        GridToViewTRinMultipleCaseNew(txtInspectionId.Text);
                        GridBindDocument(txtInspectionId.Text);
                        GetInspectionData(txtInspectionId.Text);
                        //Session["InspId"] = "";
                        Page.Session["ClickCount"] = "0";
                        Session["LineID"] = "";
                        Session["SubStationID"] = "";
                        Session["GeneratingSetId"] = "";
                    }
                    else
                    {
                        Session["SiteOwnerId_Sld_Indus"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
            }

        }
        private void GetInspectionDetails(string ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionReport_Industry(ID);

                txtInspectionId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                txtMaxVoltage.Text = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                hnApplicationStatus.Value = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();           
                txttransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txttransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
                hnReturnStatus.Value = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                if (hnReturnStatus.Value != null && hnReturnStatus.Value == "1")
                {
                    Grid_MultipleInspectionTR.Columns[5].Visible = false;
                    Grid_MultipleInspectionTR.Columns[6].Visible = false;
                    Grid_MultipleInspectionTR.Columns[7].Visible = false;                   
                }
                else if (hnReturnStatus.Value != null && hnReturnStatus.Value == "2")
                {
                    grd_Documemnts.Columns[3].Visible = false;
                    grd_Documemnts.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void GridToViewTRinMultipleCaseNew(string ID)
        {
            try
            {                
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew_Industry(ID);
                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    Grid_MultipleInspectionTR.DataSource = dsVC;
                    Grid_MultipleInspectionTR.DataBind();
                }
                else
                {
                    Grid_MultipleInspectionTR.DataSource = null;
                    Grid_MultipleInspectionTR.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void GridBindDocument(string ID)
        {
            try
            {              
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments_ForNewIndustry(ID);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void GetInspectionData(string ID)
        {
            try
            {              
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionReport_Industry(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch(Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    LinkButton linkButtonInvoice = (LinkButton)e.Row.FindControl("lnkInstallaionInvoice");
                    LinkButton LinkButtonReport = (LinkButton)e.Row.FindControl("lnkManufacturingReport");
                    FileUpload UploadInstallaionInvoice = (FileUpload)e.Row.FindControl("FileUploadInstallaionInvoice");
                    FileUpload UploadManufacturingReport = (FileUpload)e.Row.FindControl("FileUploadManufacturingReport");
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                        UploadInstallaionInvoice.Visible = false;
                        UploadManufacturingReport.Visible = false;
                        Grid_MultipleInspectionTR.Columns[8].Visible = false;
                        Grid_MultipleInspectionTR.Columns[9].Visible = false;
                    }
                    else
                    {
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                        UploadInstallaionInvoice.Visible = true;
                        UploadManufacturingReport.Visible = true;
                        Grid_MultipleInspectionTR.Columns[8].Visible = true;
                        Grid_MultipleInspectionTR.Columns[9].Visible = true;
                    }
                    var returnedReason = DataBinder.Eval(e.Row.DataItem, "ReturnedReason") as string;

                    var fileUploadInstallaionInvoice = e.Row.FindControl("FileUploadInstallaionInvoice") as FileUpload;
                    var fileUploadManufacturingReport = e.Row.FindControl("FileUploadManufacturingReport") as FileUpload;

                    if (fileUploadInstallaionInvoice != null && fileUploadManufacturingReport != null)
                    {
                        fileUploadInstallaionInvoice.Visible = !string.IsNullOrEmpty(returnedReason);
                        fileUploadManufacturingReport.Visible = !string.IsNullOrEmpty(returnedReason);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) == hnOwnerId.Value)
            {
                Response.Redirect("/Industry_Master/NewInstallationStatus.aspx", false);
            }
            else
            {
                Session["SiteOwnerId_Sld_Indus"] = "";
                Response.Redirect("/Industry_Sessions_Clear.aspx", false);
            }          
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                string fileName = "";
                try
                {
                    if (e.CommandName == "Select")
                    {
                        //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                }
            }
        }

        protected void Grid_MultipleInspectionTR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Count = string.Empty;
            string IntimationId = string.Empty;
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
                Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");
                Count = LblTestReportCount.Text.Trim();

                Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                IntimationId = LblIntimationId.Text.Trim();

                DataSet ds = new DataSet();
                ds = CEI.GetData_Industry(LblInstallationName.Text.Trim(), IntimationId, Count);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Session["Line"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                        Response.Redirect("/TestReportModel_Industry/LineTestReport_Industry.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Substation Transformer")
                    {
                        Session["SubStation"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModel_Industry/SubstationTestReport_Industry.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Generating Set")
                    {
                        Session["GeneratingSet"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModel_Industry/GeneratingSetTestReport_Industry.aspx", false);

                    }
                }
            }

            else if (e.CommandName == "View")
            {
                string fileName = "";
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void btnReSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int Count = Convert.ToInt32(CEI.ToChecktheCountOfReturnedInspection(Convert.ToInt32(txtInspectionId.Text)));
                if (Count == 0)
                {
                    if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) == hnOwnerId.Value && txtInspectionId.Text != null && !string.IsNullOrEmpty(txtInspectionId.Text))
                    {
                        int ClickCount = 0;
                        ClickCount = Convert.ToInt32(Session["ClickCount"]);
                        if (ClickCount < 1)
                        {
                            int checksuccessmessage = 0;
                            string SiteOwnerID = hnOwnerId.Value;

                            if (INgridfileuploadValidation(hnReturnStatus.Value)) //check validation for document
                            {
                                string ReturnType = hnReturnStatus.Value;
                                if (ReturnType == "1")
                                {
                                    foreach (GridViewRow row in grd_Documemnts.Rows)
                                    {
                                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName");

                                        if (lblDocumentName != null && lblDocumentName.Text.Trim() == "Other Document")
                                        {
                                            if (fileUpload != null && fileUpload.HasFile)
                                            {
                                                ValidatePdfFile(fileUpload);
                                            }
                                        }
                                        else
                                        {
                                            if (fileUpload.HasFile)
                                            {
                                                ValidatePdfFile(fileUpload);
                                            }

                                        }
                                    }
                                }
                                else if (ReturnType == "2")
                                {
                                    foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                                    {
                                        FileUpload fileUploadInvoice = (FileUpload)row.FindControl("FileUploadInstallaionInvoice");
                                        FileUpload fileUploadManufacturing = (FileUpload)row.FindControl("FileUploadManufacturingReport");
                                        if (fileUploadInvoice.HasFile && fileUploadManufacturing.HasFile)
                                        {
                                            ValidatePdfFile(fileUploadInvoice);
                                            ValidatePdfFile(fileUploadManufacturing);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (GridViewRow row in grd_Documemnts.Rows)
                                    {
                                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName");

                                        if (lblDocumentName != null && lblDocumentName.Text.Trim() == "Other Document")
                                        {
                                            if (fileUpload != null && fileUpload.HasFile)
                                            {
                                                ValidatePdfFile(fileUpload);
                                            }
                                        }
                                        else
                                        {
                                            if (fileUpload.HasFile)
                                            {
                                                ValidatePdfFile(fileUpload);
                                            }
                                        }
                                    }
                                    foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                                    {
                                        FileUpload fileUploadInvoice = (FileUpload)row.FindControl("FileUploadInstallaionInvoice");
                                        FileUpload fileUploadManufacturing = (FileUpload)row.FindControl("FileUploadManufacturingReport");
                                        if (fileUploadInvoice.HasFile && fileUploadManufacturing.HasFile)
                                        {
                                            ValidatePdfFile(fileUploadInvoice);
                                            ValidatePdfFile(fileUploadManufacturing);
                                        }
                                    }
                                }
                                SqlTransaction transaction = null;
                                try
                                {
                                    ClickCount = ClickCount + 1;
                                    Session["ClickCount"] = ClickCount;
                                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                    {
                                        connection.Open();
                                        transaction = connection.BeginTransaction();

                                        CEI.UpdateReturnedInspectionReportIndustry(txtInspectionId.Text, SiteOwnerID, transaction);
                                        if (Convert.ToString(ReturnType) == "1") //Update Checklist Documents
                                        {

                                            foreach (GridViewRow row in grd_Documemnts.Rows)
                                            {
                                                Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                                                Label LblDocumentID = (Label)row.FindControl("LblDocumentID");
                                                Label LblDocumentName = (Label)row.FindControl("LblDocumentName");
                                                Label LblFileName = (Label)row.FindControl("LblFileName");
                                                Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");
                                                string fileName = LblFileName.Text;
                                                string fileNameWithoutExtension = fileName;
                                                int index = fileName.IndexOf(".pdf");
                                                if (index > 0)
                                                {
                                                    fileNameWithoutExtension = fileName.Substring(0, index);
                                                }
                                                if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                                {
                                                    //FileUpload1
                                                    string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                                                    FileUpload fileUploadDoc = row.FindControl("FileUpload1") as FileUpload;

                                                    if ((fileUploadDoc != null && fileUploadDoc.HasFile))
                                                    {
                                                        //string FileName1 = Path.GetFileName(fileUploadDoc.PostedFile.FileName);

                                                        if (!Directory.Exists(Server.MapPath("/Attachment/" + SiteOwnerID + "/" + txtInspectionId.Text + "/" + "CheckListDocuments" + "/")))
                                                        {
                                                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + txtInspectionId.Text + "/" + "CheckListDocuments" + "/")); //removed fileNameWithoutExtension + "/"
                                                        }
                                                        string path = "";
                                                        path = "/Attachment/" + SiteOwnerID + "/" + txtInspectionId.Text + "/" + "CheckListDocuments";  //+ "/" + fileNameWithoutExtension
                                                        string fileName1 = fileNameWithoutExtension + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                        string filePathInfo = "";
                                                        filePathInfo = Server.MapPath(path + "/" + fileName1);
                                                        fileUploadDoc.PostedFile.SaveAs(filePathInfo);
                                                        CEI.UploadDocumentforReturnedInspection_Industry(txtInspectionId.Text, LblInstallationType.Text, LblDocumentID.Text, LblDocumentName.Text, LblFileName.Text, path + "/" + fileName1, SiteOwnerID, transaction);

                                                    }
                                                    else
                                                    {
                                                        //throw new Exception("Please Upload  Files in upload section and in .pdf format.");
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents for rows with a Returned Reason.');", true);
                                                        return;
                                                    }
                                                }


                                            }

                                        }
                                        else if (Convert.ToString(ReturnType) == "2" && Convert.ToString(ReturnType) != null) //Update TestReport Documents
                                        {
                                            foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                                            {

                                                Label LblRowid = (Label)row.FindControl("LblRowid");
                                                Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                                                Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
                                                Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");
                                                Label LblInspectionId = (Label)row.FindControl("LblInspectionId");
                                                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                                                Label LblinstallaionInvoicePath = (Label)row.FindControl("LblinstallaionInvoicePath");
                                                Label LblManufacturingReportPath = (Label)row.FindControl("LblManufacturingReportPath");

                                                Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");
                                                if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                                {
                                                    string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
                                                    FileUpload fileUploadInvoice = row.FindControl("FileUploadInstallaionInvoice") as FileUpload;
                                                    FileUpload fileUploadReport = row.FindControl("FileUploadManufacturingReport") as FileUpload;

                                                    if ((fileUploadInvoice != null && fileUploadInvoice.HasFile) && (fileUploadReport != null && fileUploadReport.HasFile))
                                                    {
                                                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + LblInspectionId.Text + "/" + "TestReportDocuments" + "/")))
                                                        {
                                                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + LblInspectionId.Text + "/" + "TestReportDocuments" + "/"));
                                                        }
                                                        string path = "";
                                                        path = "/Attachment/" + SiteOwnerID + "/" + LblInspectionId.Text + "/" + "TestReportDocuments";//one "/" removed from here
                                                        string fileName1 = "InstallaionInvoice" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                        string fileName2 = "ManufacturingReport" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                        string filePathInfo = "";
                                                        string filePatnInfo1 = "";
                                                        filePathInfo = Server.MapPath(path + "/" + fileName1);
                                                        fileUploadInvoice.PostedFile.SaveAs(filePathInfo);
                                                        filePatnInfo1 = Server.MapPath(path + "/" + fileName2);
                                                        fileUploadReport.PostedFile.SaveAs(filePatnInfo1);
                                                        CEI.InsertReturnedInspectionTestReportAttachments_Industry(LblRowid.Text, txtInspectionId.Text, path + "/" + fileName1, path + "/" + fileName2, LblInstallationName.Text, SiteOwnerID, transaction);
                                                    }
                                                    else
                                                    {
                                                        //throw new Exception("Please Upload  Files in upload section and in .pdf format.");
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents.');", true);
                                                        return;
                                                    }
                                                }

                                            }

                                        }
                                        else if (Convert.ToString(ReturnType) == "3" && Convert.ToString(ReturnType) != null) //Update both Documents
                                        {
                                            foreach (GridViewRow row in grd_Documemnts.Rows)
                                            {
                                                Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                                                Label LblDocumentID = (Label)row.FindControl("LblDocumentID");
                                                Label LblDocumentName = (Label)row.FindControl("LblDocumentName");
                                                Label LblFileName = (Label)row.FindControl("LblFileName");
                                                Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");
                                                string fileName = LblFileName.Text;
                                                string fileNameWithoutExtension = fileName;
                                                int index = fileName.IndexOf(".pdf");
                                                if (index > 0)
                                                {
                                                    fileNameWithoutExtension = fileName.Substring(0, index);
                                                }
                                                if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                                {
                                                    string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                                                    FileUpload fileUploadDoc = row.FindControl("FileUpload1") as FileUpload;

                                                    if ((fileUploadDoc != null && fileUploadDoc.HasFile))
                                                    {
                                                        //string FileName1 = Path.GetFileName(fileUploadDoc.PostedFile.FileName);

                                                        if (!Directory.Exists(Server.MapPath("/Attachment/" + SiteOwnerID + "/" + txtInspectionId.Text + "/" + "CheckListDocuments" + "/")))
                                                        {
                                                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + txtInspectionId.Text + "/" + "CheckListDocuments" + "/")); //removed fileNameWithoutExtension + "/"
                                                        }
                                                        string path = "";
                                                        path = "/Attachment/" + SiteOwnerID + "/" + txtInspectionId.Text + "/" + "CheckListDocuments";  //+ "/" + fileNameWithoutExtension
                                                        string fileName1 = fileNameWithoutExtension + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                        string filePathInfo = "";
                                                        //string filePathInfo1 = "";
                                                        filePathInfo = Server.MapPath(path + "/" + fileName1);
                                                        fileUploadDoc.PostedFile.SaveAs(filePathInfo);
                                                        CEI.UploadDocumentforReturnedInspection_Industry(txtInspectionId.Text, LblInstallationType.Text, LblDocumentID.Text, LblDocumentName.Text, LblFileName.Text, path + "/" + fileName1, SiteOwnerID, transaction);
                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents.');", true);
                                                        return; // Stops further processing if validation fails
                                                    }
                                                }
                                            }

                                            // Process the second GridView
                                            foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                                            {
                                                Label LblRowid = (Label)row.FindControl("LblRowid");
                                                Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                                                Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
                                                Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");
                                                Label LblInspectionId = (Label)row.FindControl("LblInspectionId");
                                                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                                                Label LblinstallaionInvoicePath = (Label)row.FindControl("LblinstallaionInvoicePath");
                                                Label LblManufacturingReportPath = (Label)row.FindControl("LblManufacturingReportPath");

                                                Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");

                                                if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                                {
                                                    string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
                                                    FileUpload fileUploadInvoice = row.FindControl("FileUploadInstallaionInvoice") as FileUpload;
                                                    FileUpload fileUploadReport = row.FindControl("FileUploadManufacturingReport") as FileUpload;

                                                    if ((fileUploadInvoice != null && fileUploadInvoice.HasFile) && (fileUploadReport != null && fileUploadReport.HasFile))
                                                    {
                                                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + LblInspectionId.Text + "/" + "TestReportDocuments" + "/")))
                                                        {
                                                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + LblInspectionId.Text + "/" + "TestReportDocuments" + "/"));
                                                        }
                                                        string path = "";
                                                        path = "/Attachment/" + SiteOwnerID + "/" + LblInspectionId.Text + "/" + "TestReportDocuments";//one "/" removed from here
                                                        string fileName1 = "InstallaionInvoice" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                        string fileName2 = "ManufacturingReport" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                        string filePathInfo = "";
                                                        string filePathInfo1 = "";
                                                        filePathInfo = Server.MapPath(path + "/" + fileName1);
                                                        fileUploadInvoice.PostedFile.SaveAs(filePathInfo);
                                                        filePathInfo1 = Server.MapPath(path + "/" + fileName2);
                                                        fileUploadReport.PostedFile.SaveAs(filePathInfo1);
                                                        CEI.InsertReturnedInspectionTestReportAttachments_Industry(LblRowid.Text, txtInspectionId.Text, path + "/" + fileName1, path + "/" + fileName2, LblInstallationName.Text, SiteOwnerID, transaction);
                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents.');", true);
                                                        return; // Stops further processing if validation fails
                                                    }
                                                }
                                            }
                                        }

                                        transaction.Commit();
                                        string ActionStatus = hnApplicationStatus.Value;
                                        checksuccessmessage = 1;
                                        try
                                        {
                                            //string actiontype = para_InspectID == 0 ? "Submit" : "ReSubmit";
                                            string actiontype = "ReSubmit";

                                            List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(txtInspectionId.Text), actiontype, Session["projectid_New_Temp"].ToString(), Session["Serviceid_New_Temp"].ToString(), hnOwnerId.Value);
                                            foreach (var ApiPostformatresult in ApiPostformatResults)
                                            {
                                                if (ApiPostformatresult.PremisesType == "Industry")
                                                {
                                                    // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                                    string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                                    // string accessToken = "dfsfdsfsfsdf";

                                                    logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                                                  "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                                                  new Industry_Inspection_StageWise_JsonDataFormat_Model
                                                                  {
                                                                      actionTaken = ApiPostformatresult.ActionTaken,
                                                                      commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                                                      //commentDate = ApiPostformatresult.CommentDate,
                                                                      commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                                                      comments = ApiPostformatresult.Comments,
                                                                      id = ApiPostformatresult.Id,
                                                                      projectid = ApiPostformatresult.ProjectId,
                                                                      serviceid = ApiPostformatresult.ServiceId
                                                                      //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                                                      //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                                                  }, ApiPostformatresult, accessToken);

                                                    if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                                                    {
                                                        throw new Exception(logDetails.ErrorMessage);
                                                    }


                                                    CEI.LogToIndustryApiSuccessDatabase(
                                                    logDetails.Url,
                                                    logDetails.Method,
                                                    logDetails.RequestHeaders,
                                                    logDetails.ContentType,
                                                    logDetails.RequestBody,
                                                    logDetails.ResponseStatusCode,
                                                    logDetails.ResponseHeaders,
                                                    logDetails.ResponseBody,

                                                    new Industry_Api_Post_DataformatModel
                                                    {
                                                        InspectionId = ApiPostformatresult.InspectionId,
                                                        InspectionLogId = ApiPostformatresult.InspectionLogId,
                                                        IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                                        ActionTaken = ApiPostformatresult.ActionTaken,
                                                        CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                                        CommentDate = ApiPostformatresult.CommentDate,

                                                        Comments = ApiPostformatresult.Comments,
                                                        Id = ApiPostformatresult.Id,
                                                        ProjectId = ApiPostformatresult.ProjectId,
                                                        ServiceId = ApiPostformatresult.ServiceId,
                                                    }

                                                );

                                                }
                                            }
                                        }
                                        catch (TokenManagerException ex)
                                        {
                                            CEI.LogToIndustryApiErrorDatabase(
                                                ex.RequestUrl,
                                                ex.RequestMethod,
                                                ex.RequestHeaders,
                                                ex.RequestContentType,
                                                ex.RequestBody,
                                                ex.ResponseStatusCode,
                                                ex.ResponseHeaders,
                                                ex.ResponseBody,
                                                new Industry_Api_Post_DataformatModel
                                                {
                                                    InspectionId = ex.InspectionId,
                                                    InspectionLogId = ex.InspectionLogId,
                                                    IncomingJsonId = ex.IncomingJsonId,
                                                    ActionTaken = ex.ActionTaken,
                                                    CommentByUserLogin = ex.CommentByUserLogin,
                                                    CommentDate = ex.CommentDate,
                                                    Comments = ex.Comments,
                                                    Id = ex.Id,
                                                    ProjectId = ex.ProjectId,
                                                    ServiceId = ex.ServiceId,
                                                }
                                            );
                                            string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                                            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                                        }
                                        catch (IndustryApiException ex)
                                        {
                                            CEI.LogToIndustryApiErrorDatabase(
                                                ex.RequestUrl,
                                                ex.RequestMethod,
                                                ex.RequestHeaders,
                                                ex.RequestContentType,
                                                ex.RequestBody,
                                                ex.ResponseStatusCode,
                                                ex.ResponseHeaders,
                                                ex.ResponseBody,
                                                new Industry_Api_Post_DataformatModel
                                                {
                                                    InspectionId = ex.InspectionId,
                                                    InspectionLogId = ex.InspectionLogId,
                                                    IncomingJsonId = ex.IncomingJsonId,
                                                    ActionTaken = ex.ActionTaken,
                                                    CommentByUserLogin = ex.CommentByUserLogin,
                                                    CommentDate = ex.CommentDate,

                                                    Comments = ex.Comments,
                                                    Id = ex.Id,
                                                    ProjectId = ex.ProjectId,
                                                    ServiceId = ex.ServiceId,
                                                }
                                            );
                                        }
                                        finally
                                        {
                                            if (checksuccessmessage == 1)
                                            {
                                                string script = $"alert('Inspection Request Re-Submitted Successfully, forwarding to concerned officer..'); window.location='/Industry_Master/NewInstallationStatus.aspx';";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertRedirect", script, true);

                                            }

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                    transaction.Rollback();
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents.');", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='NewInstallationStatus.aspx'", true);
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId_Sld_Indus"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your inspection is not in Return status, so you can't allow to Re-submit the inspection.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private bool INgridfileuploadValidation(string ReturnType)
        {
            int flag = 0;
            if (Convert.ToString(ReturnType) != null && Convert.ToString(ReturnType) == "1")
            {
                foreach (GridViewRow row in grd_Documemnts.Rows)
                {
                    string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                    //string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
                    FileUpload fileUploadControl = row.FindControl("FileUpload1") as FileUpload;

                    if (!string.IsNullOrEmpty(returnedReason) && (fileUploadControl == null || !fileUploadControl.HasFile))
                    {
                        flag = 1;
                        break;
                    }
                }
            }
            else
            if (Convert.ToString(ReturnType) != null && Convert.ToString(ReturnType) == "2")
            {
                foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                {
                    string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                    FileUpload fileUploadInvoice = row.FindControl("FileUploadInstallaionInvoice") as FileUpload;
                    FileUpload fileUploadReport = row.FindControl("FileUploadManufacturingReport") as FileUpload;

                    if (!string.IsNullOrEmpty(returnedReason) &&
                        ((fileUploadInvoice == null || !fileUploadInvoice.HasFile) ||
                         (fileUploadReport == null || !fileUploadReport.HasFile)))
                    {
                        flag = 1;
                        break;
                    }
                }
            }
            else
            if (Convert.ToString(ReturnType) != null && Convert.ToString(ReturnType) == "3")
            {
                foreach (GridViewRow row in grd_Documemnts.Rows)
                {
                    string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                    //string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
                    FileUpload fileUploadControl = row.FindControl("FileUpload1") as FileUpload;

                    if (!string.IsNullOrEmpty(returnedReason) && (fileUploadControl == null || !fileUploadControl.HasFile))
                    {
                        flag = 1;
                        break;
                    }
                }
                foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                {
                    string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                    //string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
                    FileUpload fileUploadInvoice = row.FindControl("FileUploadInstallaionInvoice") as FileUpload;
                    FileUpload fileUploadReport = row.FindControl("FileUploadManufacturingReport") as FileUpload;

                    if (!string.IsNullOrEmpty(returnedReason) &&
                        ((fileUploadInvoice == null || !fileUploadInvoice.HasFile) ||
                         (fileUploadReport == null || !fileUploadReport.HasFile)))
                    {

                        flag = 1;
                        break;
                    }
                }
            }
            else
            {
                flag = 1;
            }

            if (flag == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ValidatePdfFile(FileUpload fileUpload)
        {

            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            if (fileExtension != ".pdf")
            {
                throw new Exception("Please upload PDF files only.");

            }

            if (fileUpload.PostedFile.ContentLength > 1048576)
            {
                throw new Exception("Please upload PDF files less than 1 MB only.");

            }
        }
        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var returnedReason = DataBinder.Eval(e.Row.DataItem, "ReturnedReason") as string;

                var fileUpload = e.Row.FindControl("FileUpload1") as FileUpload;

                if (fileUpload != null)
                {
                    fileUpload.Visible = !string.IsNullOrEmpty(returnedReason);
                }
            }
        }
    }
}