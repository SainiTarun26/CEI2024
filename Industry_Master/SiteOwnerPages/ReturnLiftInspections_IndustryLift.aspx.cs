using CEI_PRoject;
using CEIHaryana.Model.Industry;
using CEIHaryana.Officers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class ReturnLiftInspections_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        int InspectionId = 0;
        private int totalQuantity = 0;
        private decimal totalAmountSum = 0;
        string intimationids = string.Empty;
        string generatedIdCombinedDetails_Global = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                FetchDetails();
                GetTestReportDataIfPeriodic();
                GridView7.Visible = true;

            }
        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (status == "RETURN")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
            }
        }
        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                ID = Session["InspectionId_IndustryLift"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetReturnedInspectionData_IndustryLift(int.Parse(ID));
                string TestRportId = string.Empty;
                if (ds != null && ds.Rows.Count > 0)
                {

                    GridView7.DataSource = ds;
                    GridView7.DataBind();
                }
                else
                {
                    GridView7.DataSource = null;
                    GridView7.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex) { }
        }
        public void FetchDetails()
        {
            Session["Verified_IndustryLift"] = "NotVerified";
            //Session["SiteOwnerId"] = "AAAAB3132F";
            InspectionId = int.Parse(Session["InspectionId_IndustryLift"].ToString());
            //Session["ReturnedValue"] = "2";
            if (Session["TypeOfInspection_IndustryLift"].ToString() == "New")
            {

                PaymentGridViewBind(InspectionId);
                getWorkIntimationData(InspectionId);
                HashSet<string> uniqueCategories = new HashSet<string>();
                foreach (GridViewRow currentRow in GridView1.Rows)
                {
                    Label lblCategory = (Label)currentRow.FindControl("lblCategory");
                    Label lblIntimationId = (Label)currentRow.FindControl("lblIntimationId");
                    Session["IntimationId_IndustryLift"] = lblIntimationId.Text.Trim();
                    intimationids = lblIntimationId.Text.Trim();
                    if (lblCategory != null)
                    {
                        string category = lblCategory.Text.Trim();
                        if (!string.IsNullOrEmpty(category)) // Ensure the category is not null or empty
                        {
                            uniqueCategories.Add(category); // Add to HashSet to avoid duplicates
                        }
                    }
                }

                // Join unique categories with '/' delimiter
                string concatenatedCategories = string.Join("_", uniqueCategories);
                //Session["InstalltionType"] = concatenatedCategories.Trim();
                // To ensure uniqueness
                if (Session["ReturnedValue_IndustryLift"].ToString() == "1")
                {

                    GridView1.Columns[6].Visible = true;
                    Grd_Document.Columns[3].Visible = false;
                }
                else
                {
                    Inspection.Visible = true;
                    btnSubmit.Visible = true;
                    Button1.Visible = false;
                    GridView1.Columns[6].Visible = false;
                    Grd_Document.Columns[3].Visible = true;
                }
            }
            else
            {
                PaymentGridViewBindPeriodic(InspectionId);
                getWorkIntimationDataPeriodi(InspectionId);
                GridView2.Visible = true;
                HashSet<string> uniqueCategories = new HashSet<string>();
                foreach (GridViewRow currentRow in GridView2.Rows)
                {
                    Label lblCategory = (Label)currentRow.FindControl("lblCategory");
                    Label lblIntimationId = (Label)currentRow.FindControl("lblIntimationId");
                    Session["IntimationId_IndustryLift"] = lblIntimationId.Text.Trim(); ;
                    intimationids = lblIntimationId.Text.Trim();
                    if (lblCategory != null)
                    {
                        string category = lblCategory.Text.Trim();
                        if (!string.IsNullOrEmpty(category)) // Ensure the category is not null or empty
                        {
                            uniqueCategories.Add(category); // Add to HashSet to avoid duplicates
                        }
                    }
                }

                // Join unique categories with '/' delimiter
                string concatenatedCategories = string.Join("_", uniqueCategories);
                // Session["InstalltionType"] = concatenatedCategories.Trim();
                if (Session["ReturnedValue_IndustryLift"].ToString() == "1")
                {
                    GridView2.Columns[5].Visible = true;
                    Grd_Document.Columns[3].Visible = false;
                }
                else
                {
                    Inspection.Visible = true;
                    btnSubmit.Visible = true;
                    Button1.Visible = false;
                    GridView2.Columns[5].Visible = false;
                    Grd_Document.Columns[3].Visible = true;
                }
            }
            GetData();
            GetDocumentUploadData(InspectionId);
        }

        public void GetData()
        {
            InspectionId = int.Parse(Session["InspectionId_IndustryLift"].ToString());
            DataTable dataTable = new DataTable();
            dataTable = CEI.GetReturnedInspectionData_IndustryLift(InspectionId);
            txttransactionId.Text = dataTable.Rows[0]["TransactionId"].ToString();
            txtReturntransactionDate.Text = dataTable.Rows[0]["TransctionDate"].ToString();
            txtInspectionRemarks.Text = dataTable.Rows[0]["InspectionRemarks"].ToString();
            Session["InstalltionType_IndustryLift"] = dataTable.Rows[0]["InstallationType"].ToString();
            if (Session["ReturnedValue_IndustryLift"].ToString() == "1")
            {
                // txtInspectionRemarks.ReadOnly = true;
                txtReturntransactionDate.ReadOnly = true;
                txttransactionId.ReadOnly = true;
                txtReturntransactionDate.Visible = true;
                txttransactionDate.Visible = false;
            }
            else
            {

            }
            if (Session["Amount_IndustryLift"].ToString() == "0" || Session["Amount_IndustryLift"].ToString() == "0.00")
            {
                PaymentDetails.Visible = false;
                ChallanDetail.Visible = false;
                txttransactionDate.Text = dataTable.Rows[0]["TransctionDate"].ToString();
            }
            else
            {

            }


        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {

                    // fileName = "https://localhost:44393" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                //lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        private void GetDocumentUploadData(int InspectionId)
        {
            DataTable ds = new DataTable();
            ds = CEI.ReturnDocuments_Lift_IndustryLift(InspectionId);
            if (ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                UploadDocuments.Visible = false;
                //string script = "alert(\"No Record Found for document \");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Session["OTP_IndustryLift"] = "0";
                string TypeOfInspection = Session["TypeOfInspection_IndustryLift"].ToString();
                if (e.CommandName == "ViewTestReport")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    if (lblCategory.Text.Trim() == "Lift")
                    {
                        Session["LiftTestReportID_IndustryLift"] = lblTestReportId.Text;
                        Response.Redirect("/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx", false);
                    }
                    else if (lblCategory.Text.Trim() == "Escalator")
                    {
                        Session["EscalatorTestReportID_IndustryLift"] = lblTestReportId.Text;
                        Response.Redirect("/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx", false);
                    }
                }
                else if (e.CommandName == "CreateNew")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                    Label lblCategory = (Label)row.FindControl("lblCategory");

                    if (Session["Verified_IndustryLift"].ToString() != "Verified")
                    {
                        Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                        Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                        Label lblReportType = (Label)row.FindControl("lblReportType");
                        Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                        Label lblTotalNo = (Label)row.FindControl("lblTotalNo");
                        if (lblCategory.Text.Trim() == "Lift" && TypeOfInspection.Trim() == "New")

                        {
                            Session["Application_IndustryLift"] = lblIntimationId.Text.Trim();
                            Session["id_IndustryLift"] = lblIntimationId.Text.Trim();
                            Session["Typs_IndustryLift"] = lblCategory.Text.Trim();
                            Session["NoOfInstallations_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Session["IHID_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Session["TotalInstallation_IndustryLift"] = lblTotalNo.Text.Trim();
                            Session["LiftTestReportID_IndustryLift"] = lblTestReportId.Text;
                            Response.Redirect("/Industry_Master/SiteOwnerPages/LiftDetails_IndustryLift.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Escalator" && TypeOfInspection.Trim() == "New")
                        {

                            Session["Application_IndustryLift"] = lblIntimationId.Text.Trim();
                            Session["id_IndustryLift"] = lblIntimationId.Text.Trim();
                            Session["Typs_IndustryLift"] = lblCategory.Text.Trim();
                            Session["NoOfInstallations_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Session["IHID_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Session["TotalInstallation_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Session["EscalatorTestReportID_IndustryLift"] = lblTestReportId.Text;
                            Response.Redirect("/Industry_Master/SiteOwnerPages/EscalatorDetails_IndustryLift.aspx", false);
                        }
                        else if (TypeOfInspection.Trim() != "New")
                        {
                            Session["RegistrationNosessionPass_IndustryLift"] = lblIntimationId.Text;
                            Session["InstallTypePass_IndustryLift"] = lblCategory.Text;
                            Session["EscalatorTestReportID_IndustryLift"] = lblTestReportId.Text;
                            Response.Redirect("/Industry_Master/SiteOwnerPages/LiftPeriodicRenewal_IndustryLift.aspx", false);
                        }
                    }
                    else
                    {
                        if (Session["TypeOfInspection_IndustryLift"].ToString() == "New")
                        {
                            Label lblTestReportId = (Label)row.FindControl("lblOldTestReportId");
                            if (lblCategory.Text.Trim() == "Lift")
                            {
                                Session["LiftTestReportID_IndustryLift"] = lblTestReportId.Text;
                                Response.Redirect("/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx", false);
                            }
                            else if (lblCategory.Text.Trim() == "Escalator")
                            {

                                Session["EscalatorTestReportID_IndustryLift"] = lblTestReportId.Text;
                                Response.Redirect("/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx", false);
                            }
                        }
                        else
                        {
                            Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                            Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                            Session["TestReportID_IndustryLift"] = lblTestReportId.Text;
                            Session["RegistrationNo_IndustryLift"] = lblIntimationId.Text.Trim();
                            if (lblCategory.Text.Trim() == "Lift")
                            {
                                Response.Redirect("/Industry_Master/TestReportModal/LiftPeriodicTestReportModal_IndustryLift.aspx", false);
                            }
                            else if (lblCategory.Text.Trim() == "Escalator")
                            {
                                Response.Redirect("/Industry_Master/TestReportModal/EscalatorPeriodicTestReportModal_IndustryLift.aspx", false);
                            }
                        }
                    }
                }
                else if (e.CommandName == "ViewPeriodicTestReport")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                    Session["TestReportID_IndustryLift"] = lblTestReportId.Text;
                    Session["RegistrationNo_IndustryLift"] = lblIntimationId.Text.Trim();
                    if (lblCategory.Text.Trim() == "Lift")
                    {
                        Response.Redirect("/Industry_Master/TestReportModal/LiftPeriodicTestReportModal_IndustryLift.aspx", false);
                    }
                    else if (lblCategory.Text.Trim() == "Escalator")
                    {
                        Response.Redirect("/Industry_Master/TestReportModal/EscalatorPeriodicTestReportModal_IndustryLift.aspx", false);
                    }
                }
            }
            catch (Exception)
            {
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

        private void getWorkIntimationData(int InspectionId)
        {

            DataTable ds = new DataTable();
            ds = CEI.ReturnInstallations_Lift_IndustryLift(InspectionId);
            if (ds.Rows.Count > 0 && ds != null)
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
        private void getWorkIntimationDataPeriodi(int InspectionId)
        {

            DataTable ds = new DataTable();
            ds = CEI.ReturnInstallations_LiftPeriodic_IndustryLift(InspectionId);
            if (ds.Rows.Count > 0 && ds != null)
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblOldTestReportId = (Label)e.Row.FindControl("lblOldTestReportId");
                string InspectionIds = Session["InspectionId_IndustryLift"].ToString();

                if (Session["TypeOfInspection_IndustryLift"].ToString() == "New")
                {
                    Label lblTypeofinstallation = (Label)e.Row.FindControl("lblTypeofinstallation");
                    Label lblIntimationId = (Label)e.Row.FindControl("lblIntimationId");
                    Label lblCount = (Label)e.Row.FindControl("lblCount");
                    DataTable dta = new DataTable();

                    dta = CEI.CalculateRows_IndustryLift(lblTypeofinstallation.Text.Trim(), lblIntimationId.Text.Trim(), InspectionIds, lblCount.Text.Trim());
                    string Result = dta.Rows[0]["Result"].ToString();
                    LinkButton linkButton5 = (LinkButton)e.Row.FindControl("LinkButton5");

                    if (Result == "Greater")
                    {
                        if (Session["Verified_IndustryLift"].ToString() != "Verified")
                        {
                            linkButton5.Text = "Created";

                            linkButton5.Enabled = false;
                        }
                        else
                        {
                            linkButton5.Text = "Old Test Report";
                        }
                    }
                    else
                    {
                        // Show LinkButton5 if OldTestReportId is not null or empty
                        linkButton5.Visible = true;
                    }
                }
                else
                {
                    Label lblIntimationId = (Label)e.Row.FindControl("lblIntimationId");
                    Label lblTestReportId = (Label)e.Row.FindControl("lblOldTestReportId");
                    LinkButton linkButton7 = (LinkButton)e.Row.FindControl("LinkButton7");
                    DataTable dta = new DataTable();
                    dta = CEI.PeriodicCalculateRows_IndustryLift(lblIntimationId.Text.Trim(), InspectionIds);
                    string Result = dta.Rows[0]["Result"].ToString();
                    if (Result == "Greater")
                    {
                        if (Session["Verified_IndustryLift"].ToString() != "Verified")
                        {
                            // Hide LinkButton5 if OldTestReportId is null or empty
                            linkButton7.Text = "Created";
                            linkButton7.Enabled = false;
                        }
                        else
                        {
                            linkButton7.Text = "Old Test Report";
                        }
                    }
                    else
                    {
                        // Show LinkButton5 if OldTestReportId is not null or empty
                        linkButton7.Visible = true;
                    }
                }

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
                Session["Amount_IndustryLift"] = totalAmountSum.ToString();
            }
        }
        protected void PaymentGridViewBind(int InspectionId)
        {
            try
            {

                DataTable dsa = new DataTable();
                dsa = CEI.ReturnPayment_Lift_IndustryLift(InspectionId);
                if (dsa.Rows.Count > 0 && dsa != null)
                {
                    GridViewPayment.DataSource = dsa;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Fill the Form first for knowing Payment \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                dsa.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        protected void PaymentGridViewBindPeriodic(int InspectionId)
        {
            try
            {

                DataTable dsa = new DataTable();
                dsa = CEI.ReturnPayment_LiftPeriodic_IndustryLift(InspectionId);
                if (dsa.Rows.Count > 0 && dsa != null)
                {
                    GridViewPayment.DataSource = dsa;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Fill the Form first for knowing Payment \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                dsa.Dispose();
            }
            catch (Exception ex)
            {
            }
        }


        public void UploadCheckListDocInCollection()
        {
            string InspectionId = Session["InspectionId_IndustryLift"].ToString();
            string InstallTypes = Session["InstalltionType_IndustryLift"].ToString();
            intimationids = Session["IntimationId_IndustryLift"].ToString();
            string CreatedByy = Session["SiteOwnerId_IndustryLift"].ToString();
            //SqlTransaction transaction = null;
            try
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
                                //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                //string fileName = DocSaveName + "." + ext;
                                string fileName = DocSaveName + ".pdf";

                                string filePathInfo2 = "";

                                filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId + "/" + InstallTypes + "/" + fileName);

                                fileUpload.PostedFile.SaveAs(filePathInfo2);

                                CEI.UploadDocumentforLiftReturnedInspectionLift_IndustryLift(InspectionId, InstallTypes, DocumentID, DocName, DocSaveName, path + fileName, CreatedBy);
                                // transaction.Commit();
                            }
                            else
                            {
                                // transaction.Rollback();
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
            catch
            {
                throw new Exception("Please Upload Pdf Files Carefully");

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            if (Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != null && Convert.ToString(Session["IntimationId_LiftEscalator_IndustryLift"]) != null)
            {
                string CreatedBy = Session["SiteOwnerId_IndustryLift"].ToString();
                try
                {
                    InspectionId = int.Parse(Session["InspectionId_IndustryLift"].ToString());
                    string date = string.Empty;
                    string Data = string.Empty;
                    if (txtReturntransactionDate.Visible == true || PaymentDetails.Visible == false)
                    {
                        date = txtReturntransactionDate.Text;
                    }
                    else
                    {
                        date = txttransactionDate.Text;
                    }
                    if (date == "" || date == null)
                    {
                        date = "1899-09-09";
                    }
                    DataTable ds = new DataTable();
                    if (Session["TypeOfInspection_IndustryLift"].ToString() == "New" && Session["ReturnedValue_IndustryLift"].ToString() == "1")
                    {

                        ds = CEI.CheckReturnValue_IndustryLift(InspectionId);
                        Data = ds.Rows[0]["Typs"].ToString();
                    }
                    else if (Session["TypeOfInspection_IndustryLift"].ToString() != "New" && Session["ReturnedValue_IndustryLift"].ToString() == "1")
                    {

                        ds = CEI.CheckPeridocReturnValue_IndustryLift(InspectionId);
                        Data = ds.Rows[0]["Typs"].ToString();
                    }

                    if (Data == "Yes" && Session["ReturnedValue_IndustryLift"].ToString() == "1")
                    {
                        InspectionId = int.Parse(Session["InspectionId_IndustryLift"].ToString());
                        if (Grd_Document.Columns[3].Visible == true && Grd_Document.Visible == true)
                        {
                            UploadCheckListDocInCollection();
                        }
                        CEI.UpdateReturnLiftInspection_IndustryLift(InspectionId, txttransactionId.Text, DateTime.Parse(date), txtInspectionRemarks.Text, CreatedBy);

                        if (Session["TypeOfInspection_IndustryLift"].ToString() == "Periodic")
                        {
                            CEI.UpdateReturnLiftInspectionPeriodicStatus_IndustryLift(InspectionId);
                        }
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }

                    else if (Session["ReturnedValue_IndustryLift"].ToString() != "1")
                    {
                        InspectionId = int.Parse(Session["InspectionId_IndustryLift"].ToString());
                        if (Grd_Document.Columns[3].Visible == true)
                        {
                            UploadCheckListDocInCollection();
                        }
                        CEI.UpdateReturnLiftInspection_IndustryLift(InspectionId, txttransactionId.Text, DateTime.Parse(date), txtInspectionRemarks.Text, CreatedBy);

                        if (Session["TypeOfInspection_IndustryLift"].ToString() == "Periodic")
                        {
                            CEI.UpdateReturnLiftInspectionPeriodicStatus_IndustryLift(InspectionId);
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please Fill atleast 1 TestReport First');", true);


                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                    return;
                }

                checksuccessmessage = 1;
                try
                {
                    //string actiontype = para_InspectID == 0 ? "Submit" : "ReSubmit";
                    string actiontype = "Submit";

                    List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(Session["InspectionId_IndustryLift"].ToString()), actiontype, Session["projectid_IndustryLift"].ToString(), Session["Serviceid_IndustryLift"].ToString(), Session["SiteOwnerId_IndustryLift"].ToString());
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

                    //   string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.ResponseBody.ToString() + "')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (Exception ex)
                {

                    //Commented below to raise errors as per backend
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill All details carefully')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                }
                finally
                {
                    if (checksuccessmessage == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }

                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                InspectionId = int.Parse(Session["InspectionId_IndustryLift"].ToString());
                string Data = string.Empty;
                DataTable ds = new DataTable();
                if (Session["TypeOfInspection_IndustryLift"].ToString() == "New" && Session["ReturnedValue_IndustryLift"].ToString() == "1")
                {
                    ds = CEI.CheckReturnValue_IndustryLift(InspectionId);
                    Data = ds.Rows[0]["Typs"].ToString();
                }
                else if (Session["TypeOfInspection_IndustryLift"].ToString() != "New" && Session["ReturnedValue_IndustryLift"].ToString() == "1")
                {

                    ds = CEI.CheckPeridocReturnValue_IndustryLift(InspectionId);
                    Data = ds.Rows[0]["Typs"].ToString();
                }
                if (Data != "" && Data != "No" && Data != null)
                {
                    Button1.Visible = false;
                    Inspection.Visible = true;
                    btnSubmit.Visible = true;
                    Session["Verified_IndustryLift"] = "Verified";
                    if (Session["TypeOfInspection_IndustryLift"].ToString() == "New" && Session["ReturnedValue_IndustryLift"].ToString() == "1")
                    {
                        getWorkIntimationData(InspectionId);
                    }
                    else
                    {
                        getWorkIntimationDataPeriodi(InspectionId);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please Fill atleast 1 TestReport First');", true);

                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please Fill atleast 1 TestReport First');", true);

            }
        }
    }
}