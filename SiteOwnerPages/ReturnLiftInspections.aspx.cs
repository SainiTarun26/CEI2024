using CEI_PRoject;
using CEIHaryana.Officers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ReturnLiftInspections : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int InspectionId = 0;
        private int totalQuantity = 0;
        private decimal totalAmountSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                FetchDetails();
            }
        }
        public void FetchDetails()
        {
            //Session["SiteOwnerId"] = "AAAAB3132F";
            InspectionId = int.Parse(Session["InspectionId"].ToString());
            //Session["ReturnedValue"] = "2";
            if (Session["TypeOfInspection"].ToString() == "New")
            {

                PaymentGridViewBind(InspectionId);
                getWorkIntimationData(InspectionId);
                HashSet<string> uniqueCategories = new HashSet<string>();
                foreach (GridViewRow currentRow in GridView1.Rows)
                {
                    Label lblCategory = (Label)currentRow.FindControl("lblCategory");
                    Label lblIntimationId = (Label)currentRow.FindControl("lblIntimationId");
                    Session["IntimationId"] = lblIntimationId.ToString();
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
                Session["InstalltionType"] = concatenatedCategories.Trim();
                // To ensure uniqueness
                if (Session["ReturnedValue"].ToString() == "1")
                {
                    GridView1.Columns[6].Visible = true;
                    Grd_Document.Columns[3].Visible = false;
                }
                else
                {
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
                    Session["IntimationId"] = lblIntimationId.ToString();
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
                Session["InstalltionType"] = concatenatedCategories.Trim();
                if (Session["ReturnedValue"].ToString() == "1")
                {
                    GridView2.Columns[5].Visible = true;
                    Grd_Document.Columns[3].Visible = false;
                }
                else
                {
                    GridView2.Columns[5].Visible = false;
                    Grd_Document.Columns[3].Visible = true;
                }
            }

            GetDocumentUploadData(InspectionId);
        }
            protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {

                    fileName = "https://localhost:44393" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                //lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        private void GetDocumentUploadData( int InspectionId)
        {
            DataTable ds = new DataTable();
            ds = CEI.ReturnDocuments_Lift(InspectionId);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string TypeOfInspection = Session["TypeOfInspection"].ToString();
                if (e.CommandName == "ViewTestReport")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    if (lblCategory.Text.Trim() == "Lift")
                    {
                        Session["LiftTestReportID"] = lblTestReportId.Text;
                        Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                    }
                    else if (lblCategory.Text.Trim() == "Escalator")
                    {
                        Session["EscalatorTestReportID"] = lblTestReportId.Text;
                        Response.Redirect("/TestReportModal/EscalatorTestReportModal.aspx", false);
                    }
                }
                else if (e.CommandName == "CreateNew")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");

                    Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                    Label lblReportType = (Label)row.FindControl("lblReportType");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    if (lblCategory.Text.Trim() == "Lift" && TypeOfInspection.Trim() == "New")

                    {
                        Session["Application"] = lblIntimationId.Text.Trim();
                        Session["id"] = lblIntimationId.Text.Trim();
                        Session["Typs"] = lblCategory.Text.Trim();
                        Session["NoOfInstallations"] = lblNoOfInstallations.Text.Trim();
                        Session["IHID"] = lblNoOfInstallations.Text.Trim();
                        Session["TotalInstallation"] = lblNoOfInstallations.Text.Trim();
                        Session["LiftTestReportID"] = lblTestReportId.Text;
                        Response.Redirect("/SiteOwnerPages/LiftDetails.aspx", false);
                    }
                    else if (lblCategory.Text.Trim() == "Escalator" && TypeOfInspection.Trim() == "New")
                    {

                        Session["Application"] = lblIntimationId.Text.Trim();
                        Session["id"] = lblIntimationId.Text.Trim();
                        Session["Typs"] = lblCategory.Text.Trim();
                        Session["NoOfInstallations"] = lblNoOfInstallations.Text.Trim();
                        Session["IHID"] = lblNoOfInstallations.Text.Trim();
                        Session["TotalInstallation"] = lblNoOfInstallations.Text.Trim();
                        Session["EscalatorTestReportID"] = lblTestReportId.Text;
                        Response.Redirect("/SiteOwnerPages/EscalatorDetails.aspx", false);
                    }
                    else if (TypeOfInspection.Trim() != "New")
                    {
                        Session["EscalatorTestReportID"] = lblTestReportId.Text;
                        Response.Redirect("/SiteOwnerPages/LiftPeriodicRenewal.aspx", false);
                    }

                }
                else if (e.CommandName == "ViewPeriodicTestReport")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                    Session["TestReportID"] = lblTestReportId.Text;
                    Session["RegistrationNo"] = lblIntimationId.Text.Trim();
                    if (lblCategory.Text.Trim() == "Lift")
                    {
                        Response.Redirect("/TestReportModal/LiftPeriodicTestReportModal.aspx", false);
                    }
                    else if (lblCategory.Text.Trim() == "Escalator")
                    {
                        Response.Redirect("/TestReportModal/EscalatorPeriodicTestReportModal.aspx", false);
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
            ds = CEI.ReturnInstallations_Lift(InspectionId);
            if(ds.Rows.Count > 0 && ds != null)
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
            ds = CEI.ReturnInstallations_LiftPeriodic(InspectionId);
            if(ds.Rows.Count > 0 && ds != null)
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

                if (Session["TypeOfInspection"].ToString() == "New")
                {
                    LinkButton linkButton5 = (LinkButton)e.Row.FindControl("LinkButton5");
                    if (lblOldTestReportId != null&& lblOldTestReportId.Text != "")
                    {
                        // Hide LinkButton5 if OldTestReportId is null or empty
                        linkButton5.Text = "Created";
                        linkButton5.Enabled = false;
                    }
                    else
                    {
                        // Show LinkButton5 if OldTestReportId is not null or empty
                        linkButton5.Visible = true;
                    }
                }
                else
                {
                    LinkButton linkButton7 = (LinkButton)e.Row.FindControl("LinkButton7");
                    if (lblOldTestReportId != null && lblOldTestReportId.Text != "")
                    {
                        // Hide LinkButton5 if OldTestReportId is null or empty
                        linkButton7.Text = "Created";
                        linkButton7.Enabled = false;
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
                Session["Amount"] = totalAmountSum.ToString();
            }
        }
        protected void PaymentGridViewBind( int InspectionId)
        {
            try
            {

                DataTable dsa = new DataTable();
                dsa = CEI.ReturnPayment_Lift(InspectionId);
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

        protected void PaymentGridViewBindPeriodic( int InspectionId)
        {
            try
            {

                DataTable dsa = new DataTable();
                dsa = CEI.ReturnPayment_LiftPeriodic(InspectionId);
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
           string InspectionId = Session["InspectionId"].ToString();
            string InstallTypes = Session["InstalltionType"].ToString();
            string intimationids = Session["IntimationId"].ToString();
            string CreatedByy = Session["SiteOwnerId"].ToString();
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

                                CEI.UploadDocumentforLiftReturnedInspection(InspectionId, InstallTypes, DocumentID, DocSaveName, fileName, path + fileName, CreatedBy);
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
                //transaction.Rollback();

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["IntimationId_LiftEscalator"]) != null)
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
                try
                {
                    InspectionId = int.Parse(Session["InspectionId"].ToString());
                    DataTable ds = new DataTable();
                    if (Session["TypeOfInspection"].ToString() == "New")
                    {
                       
                        ds = CEI.CheckReturnValue(InspectionId);
                    }
                    else
                    {
                     
                        ds = CEI.CheckPeridocReturnValue(InspectionId);
                    }
                   string Data = ds.Rows[0]["Typs"].ToString();
                    if (Data== "Yes" && Session["ReturnedValue"].ToString() == "1")
                    {
                        InspectionId = int.Parse(Session["InspectionId"].ToString());
                        CEI.UpdateReturnLiftInspection(InspectionId, txttransactionId.Text, DateTime.Parse(txttransactionDate.Text), txtInspectionRemarks.Text, CreatedBy);
                        if (Grd_Document.Columns[3].Visible == true) {
                            UploadCheckListDocInCollection();
                        }
                        if (Session["TypeOfInspection"].ToString() == "Periodic")
                        {
                            CEI.UpdateReturnLiftInspectionPeriodicStatus(InspectionId);
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }
                
                else if(Session["ReturnedValue"].ToString() != "1")
                {
                        InspectionId = int.Parse(Session["InspectionId"].ToString());
                        CEI.UpdateReturnLiftInspection(InspectionId, txttransactionId.Text, DateTime.Parse(txttransactionDate.Text), txtInspectionRemarks.Text, CreatedBy);
                        if (Grd_Document.Columns[3].Visible == true)
                        {
                            UploadCheckListDocInCollection();
                        }
                        if (Session["TypeOfInspection"].ToString() == "Periodic")
                        {
                            CEI.UpdateReturnLiftInspectionPeriodicStatus(InspectionId);
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
            }

        }
    }
}