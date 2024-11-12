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
using CEI_PRoject;
using CEIHaryana.Officers;
using Pipelines.Sockets.Unofficial.Arenas;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ReapplyReturnINspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string InspectionID, ReturnType;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["InspectionId"] != null && !string.IsNullOrEmpty(Session["InspectionId"].ToString()) && Session["SiteOwnerId"] != null)
                {
                    GetInspectionDetails();
                    GridToViewTRinMultipleCaseNew();
                    GridBindDocument();
                    GetInspectionData();
                }
            }
            catch (Exception ex)
            { }
        }
        private void GetInspectionDetails()
        {
            try
            {
                InspectionID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionReport(InspectionID);

                txtInspectionId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                txtMaxVoltage.Text = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                txttransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txttransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
                ReturnType = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();

                Session["ReturnType"] = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();

                if (ReturnType != null && ReturnType == "1")
                {
                    Grid_MultipleInspectionTR.Columns[5].Visible = false;
                    Grid_MultipleInspectionTR.Columns[6].Visible = false;
                    Grid_MultipleInspectionTR.Columns[7].Visible = false;
                    //Grid_MultipleInspectionTR.Columns[8].Visible = false;
                }
                else if (ReturnType != null && ReturnType == "2")
                {
                    grd_Documemnts.Columns[3].Visible = false;
                    grd_Documemnts.Columns[4].Visible = false;
                }

            }
            catch (Exception ex)
            { }
        }
        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                InspectionID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(InspectionID);

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
            { }
        }
        protected void GridBindDocument()
        {
            try
            {
                InspectionID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(InspectionID);
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
            { }
        }
        private void GetInspectionData()
        {
            try
            {
                InspectionID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionReport(InspectionID);
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
            catch { }
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
                    }
                    else
                    {
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                        UploadInstallaionInvoice.Visible = true;
                        UploadManufacturingReport.Visible = true;
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
            { }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/ReturnInspections.aspx", false);
        }
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                string fileName = "";
                try
                {
                    if (e.CommandName == "Select")
                    {
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                }
                catch (Exception ex)
                { }
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
                ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Session["LineID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                        Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Substation Transformer")
                    {
                        Session["SubStationID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Generating Set")
                    {
                        Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                    }
                }
            }

            else if (e.CommandName == "View")
            {
                string fileName = "";
                //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != "" && Session["SiteOwnerId"] != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    InspectionID = Session["InspectionId"].ToString();
                    string SiteOwnerID = Session["SiteOwnerId"].ToString();

                    if (INgridfileuploadValidation()) //check validation for document
                    {
                        SqlTransaction transaction = null;
                        try
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                transaction = connection.BeginTransaction();

                                CEI.UpdateReturnedInspectionReport(InspectionID, transaction);
                                if (Convert.ToString(Session["ReturnType"]) == "1") //Update Checklist Documents
                                {

                                    foreach (GridViewRow row in grd_Documemnts.Rows)
                                    {
                                        Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                                        Label LblDocumentID = (Label)row.FindControl("LblDocumentID");
                                        Label LblDocumentName = (Label)row.FindControl("LblDocumentName");
                                        Label LblFileName = (Label)row.FindControl("LblFileName");
                                        Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");

                                        if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                        {
                                            //FileUpload1
                                            string returnedReason = (row.FindControl("LblReturnedReason") as Label)?.Text;
                                            FileUpload fileUploadDoc = row.FindControl("FileUpload1") as FileUpload;

                                            if ((fileUploadDoc != null && fileUploadDoc.HasFile))
                                            {
                                                string FileName1 = Path.GetFileName(fileUploadDoc.PostedFile.FileName);

                                                if (!Directory.Exists(Server.MapPath("/Attachment/" + SiteOwnerID + "/" + LblInstallationType.Text + "/")))
                                                {
                                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + LblInstallationType.Text + "/"));
                                                }
                                                string path = "";
                                                path = "/Attachment/" + SiteOwnerID + "/" + LblInstallationType.Text + "/";
                                                string fileName1 = FileName1 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                string filePathInfo = "";
                                                filePathInfo = Server.MapPath(path + "/" + fileName1);
                                                fileUploadDoc.PostedFile.SaveAs(filePathInfo);
                                                CEI.UploadDocumentforReturnedInspection(InspectionID, LblInstallationType.Text, LblDocumentID.Text, LblDocumentName.Text, LblFileName.Text, path + "/" + fileName1, SiteOwnerID, transaction);

                                            }
                                            else
                                            {
                                                //throw new Exception("Please Upload  Files in upload section and in .pdf format.");
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents for rows with a Returned Reason.');", true);
                                            }
                                        }
                                        else
                                        {
                                            //Remark is Blank
                                        }

                                    }

                                }
                                else if (Convert.ToString(Session["ReturnType"]) == "2" && Convert.ToString(Session["ReturnType"]) != null) //Update TestReport Documents
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

                                                string CreatedBy = Session["SiteOwnerId"].ToString();
                                                string FileName1 = Path.GetFileName(fileUploadInvoice.PostedFile.FileName);
                                                string FileName2 = Path.GetFileName(fileUploadReport.PostedFile.FileName);

                                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + LblIntimationId.Text + "/" + LblInstallationName.Text + "/" + LblTestReportCount.Text + "/")))
                                                {
                                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + LblIntimationId.Text + "/" + LblInstallationName.Text + "/" + LblTestReportCount.Text + "/"));
                                                }
                                                string path = "";
                                                path = "/Attachment/" + CreatedBy + "/" + LblIntimationId.Text + "/" + LblInstallationName.Text + "/" + LblTestReportCount.Text;//one "/" removed from here
                                                string fileName1 = FileName1 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                string fileName2 = FileName2 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                                string filePathInfo = "";
                                                filePathInfo = Server.MapPath(path + "/" + fileName1);
                                                fileUploadInvoice.PostedFile.SaveAs(filePathInfo);
                                                filePathInfo = Server.MapPath(path + "/" + fileName2);
                                                fileUploadInvoice.PostedFile.SaveAs(filePathInfo);
                                                CEI.InsertReturnedInspectionTestReportAttachments(LblRowid.Text, InspectionID, path + "/" + fileName1, path + "/" + fileName2, LblInstallationName.Text, SiteOwnerID, transaction);
                                            }
                                            else
                                            {
                                                //throw new Exception("Please Upload  Files in upload section and in .pdf format.");
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents for rows with a Returned Reason.');", true);
                                            }
                                        }
                                        else
                                        {
                                            //Remark is Blank
                                        }

                                    }

                                }
                                else if (Convert.ToString(Session["ReturnType"]) == "3" && Convert.ToString(Session["ReturnType"]) != null) //Update both Documents
                                {
                                    foreach (GridViewRow row in grd_Documemnts.Rows)
                                    {
                                        Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                                        Label LblDocumentID = (Label)row.FindControl("LblDocumentID");
                                        Label LblDocumentName = (Label)row.FindControl("LblDocumentName");
                                        Label LblFileName = (Label)row.FindControl("LblFileName");
                                        Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");

                                        if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                        {
                                            FileUpload fileUploadDoc = row.FindControl("FileUpload1") as FileUpload;

                                            if (fileUploadDoc != null && fileUploadDoc.HasFile)
                                            {
                                                string fileName = Path.GetFileName(fileUploadDoc.PostedFile.FileName);
                                                string directoryPath = Server.MapPath($"~/Attachment/{SiteOwnerID}/{LblInstallationType.Text}/");

                                                if (!Directory.Exists(directoryPath))
                                                {
                                                    Directory.CreateDirectory(directoryPath);
                                                }

                                                string uniqueFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                                                string filePath = Path.Combine(directoryPath, uniqueFileName);
                                                fileUploadDoc.PostedFile.SaveAs(filePath);

                                                string relativePath = $"/Attachment/{SiteOwnerID}/{LblInstallationType.Text}/{uniqueFileName}";
                                                CEI.UploadDocumentforReturnedInspection(InspectionID, LblInstallationType.Text, LblDocumentID.Text, LblDocumentName.Text, LblFileName.Text, relativePath, SiteOwnerID, transaction);
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents for rows with a Returned Reason.');", true);
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
                                        Label LblReturnedReason = (Label)row.FindControl("LblReturnedReason");

                                        if (!string.IsNullOrEmpty(LblReturnedReason.Text))
                                        {
                                            FileUpload fileUploadInvoice = row.FindControl("FileUploadInstallaionInvoice") as FileUpload;
                                            FileUpload fileUploadReport = row.FindControl("FileUploadManufacturingReport") as FileUpload;

                                            if (fileUploadInvoice != null && fileUploadInvoice.HasFile && fileUploadReport != null && fileUploadReport.HasFile)
                                            {
                                                string createdBy = Session["SiteOwnerId"].ToString();
                                                string fileName1 = Path.GetFileName(fileUploadInvoice.PostedFile.FileName);
                                                string fileName2 = Path.GetFileName(fileUploadReport.PostedFile.FileName);

                                                string directoryPath = Server.MapPath($"~/Attachment/{createdBy}/{LblIntimationId.Text}/{LblInstallationName.Text}/{LblTestReportCount.Text}/");

                                                if (!Directory.Exists(directoryPath))
                                                {
                                                    Directory.CreateDirectory(directoryPath);
                                                }

                                                string uniqueFileName1 = $"{fileName1}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                                                string uniqueFileName2 = $"{fileName2}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                                                fileUploadInvoice.PostedFile.SaveAs(Path.Combine(directoryPath, uniqueFileName1));
                                                fileUploadReport.PostedFile.SaveAs(Path.Combine(directoryPath, uniqueFileName2));

                                                string relativePath1 = $"/Attachment/{createdBy}/{LblIntimationId.Text}/{LblInstallationName.Text}/{LblTestReportCount.Text}/{uniqueFileName1}";
                                                string relativePath2 = $"/Attachment/{createdBy}/{LblIntimationId.Text}/{LblInstallationName.Text}/{LblTestReportCount.Text}/{uniqueFileName2}";
                                                CEI.InsertReturnedInspectionTestReportAttachments(LblRowid.Text, InspectionID, relativePath1, relativePath2, LblInstallationName.Text, SiteOwnerID, transaction);
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload both the Installation Invoice and Manufacturing Report for rows with a Returned Reason.');", true);
                                                return; // Stops further processing if validation fails
                                            }
                                        }
                                    }
                                }

                                transaction.Commit();

                                Response.Redirect("/SiteOwnerPages/ReturnInspections.aspx", false);
                            }
                        }
                        catch (Exception ex)
                        {

                            transaction.Rollback();
                        }
                    }
                    else
                    {
                        // Response.Write("<script>alert('Please upload all required documents for rows with a Returned Reason.');</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please upload all required documents for rows with a Returned Reason.');", true);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }


        private bool INgridfileuploadValidation()
        {
            int flag = 0;
            if (Convert.ToString(Session["ReturnType"]) != null && Convert.ToString(Session["ReturnType"]) == "1")
            {
                foreach (GridViewRow row in grd_Documemnts.Rows)
                {
                    string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
                    FileUpload fileUploadControl = row.FindControl("FileUpload1") as FileUpload;

                    if (!string.IsNullOrEmpty(returnedReason) && (fileUploadControl == null || !fileUploadControl.HasFile))
                    {
                        flag = 1;
                        break;
                    }
                }
            }
            else
            if (Convert.ToString(Session["ReturnType"]) != null && Convert.ToString(Session["ReturnType"]) == "2")
            {
                foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                {
                    string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
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
            if (Convert.ToString(Session["ReturnType"]) != null && Convert.ToString(Session["ReturnType"]) == "3")
            {
                foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                {
                    string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
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
                foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                {
                    string returnedReason = (row.FindControl("ReturnedReason") as Label)?.Text;
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