using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;

namespace CEIHaryana.Officers
{
    public partial class Inspection : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        private static string count = "";
        private static string IntimationId = "";
        private static string AcceptorReturn, Reason, StaffId, ApprovedorReject;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetData();
                    Visibility();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected void Visibility()
        {
            Uploads.Visible = true;
            if (txtWorkType.Text == "Line")
            {
                //if (txtApplicantType.Text.Trim() == "Supplier Installation")
                //{
                LineSubstationSupplier.Visible = true;
                SupplierSub.Visible = true;
                //}
                //else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                //{
                LinePersonal.Visible = true;
                SupplierSub.Visible = true;
                //}
            }
            else if (txtWorkType.Text == "Substation Transformer")
            {
                //if (txtApplicantType.Text.Trim() == "Supplier Installation")
                //{
                LineSubstationSupplier.Visible = true;
                ////}
                ////else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                ////{
                //    PersonalSub.Visible = true;

                //}
            }
            else if (txtWorkType.Text == "Generating Set")
            {
                //if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                //{
                PersonalGenerating.Visible = true;
                //}
                //else
                //{
                //    PersonalGenerating.Visible = false;
                //}
            }
            else
            {
                LineSubstationSupplier.Visible = false;
                SupplierSub.Visible = false;
                PersonalGenerating.Visible = false;
            }

        }
        public void GetData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();

                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);

                txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                txtSiteOwnerContact.Text = ds.Tables[0].Rows[0]["SiteownerContactNumber"].ToString();
                txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                txtContractorPhoneNo.Text = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();

                txtContractorEmail.Text = ds.Tables[0].Rows[0]["ContractorEmail"].ToString();
                txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                txtSupervisorEmail.Text = ds.Tables[0].Rows[0]["SupervisorEmail"].ToString();
                txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                count = ds.Tables[0].Rows[0]["TestReportCount"].ToString();           //Added     
                IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();

                //txtAdditionalNotes.Text = ds.Tables[0].Rows[0]["AdditionalNotes"].ToString();
                Session["RequestLetterFromConcernedOfficer"] = ds.Tables[0].Rows[0]["RequestLetterFromConcernedOfficer"].ToString();
                Session["ManufacturingTestReportOfEqipment"] = ds.Tables[0].Rows[0]["ManufacturingTestReportOfEqipment"].ToString();

                Session["SingleLineDiagramOfLine"] = ds.Tables[0].Rows[0]["SingleLineDiagramOfLine"].ToString();

                string DemandNoticeOfLine = ds.Tables[0].Rows[0]["DemandNoticeOfLine"].ToString();
                Session["DemandNoticeOfLine"] = DemandNoticeOfLine;

                Session["CopyOfNoticeIssuedByUHBVNorDHBVN"] = ds.Tables[0].Rows[0]["CopyOfNoticeIssuedByUHBVNorDHBVN"].ToString();
                Session["InvoiceOfTransferOfPersonalSubstation"] = ds.Tables[0].Rows[0]["InvoiceOfTransferOfPersonalSubstation"].ToString();
                Session["ManufacturingTestCertificateOfTransformer"] = ds.Tables[0].Rows[0]["ManufacturingTestCertificateOfTransformer"].ToString();
                Session["SingleLineDiagramofTransformer"] = ds.Tables[0].Rows[0]["SingleLineDiagramofTransformer"].ToString();
                Session["InvoiceoffireExtinguisheratSite"] = ds.Tables[0].Rows[0]["InvoiceoffireExtinguisheratSite"].ToString();

                Session["InvoiceOfDGSetOfGeneratingSet"] = ds.Tables[0].Rows[0]["InvoiceOfDGSetOfGeneratingSet"].ToString();
                Session["ManufacturingCerificateOfDGSet"] = ds.Tables[0].Rows[0]["ManufacturingCerificateOfDGSet"].ToString();

                Session["InvoiceOfExptinguisherOrApparatusAtsite"] = ds.Tables[0].Rows[0]["InvoiceOfExptinguisherOrApparatusAtsite"].ToString();
                Session["StructureStabilityResolvedByAuthorizedEngineer"] = ds.Tables[0].Rows[0]["StructureStabilityResolvedByAuthorizedEngineer"].ToString();
                string Approval = Session["Approval"].ToString();
                if (Approval.Trim() == "Submit")
                {
                    //ApprovalRequired.Visible = true;

                }
                else if (Approval.Trim() == "InProgress")
                {
                    // ApprovedReject.Visible = true;
                    //ApprovalRequired.Visible = false;
                    //string dp_1 = ds.Tables[0].Rows[0]["AcceptedOrRejected"].ToString();
                    //ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(dp_1));
                    //ddlReview.Attributes.Add("disabled", "true");
                    btnBack.Visible = true;
                    btnSubmit.Visible = true;
                }
                else if (Approval.Trim() == "Rejected")
                {
                    //ApprovalRequired.Visible = true;
                    // ApprovedReject.Visible = true;
                    Rejection.Visible = true;

                    string dp_1 = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                    //ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(dp_1));
                    // ddlApprovedReject.SelectedIndex = ddlApprovedReject.Items.IndexOf(ddlApprovedReject.Items.FindByText(dp_1));
                    //ddlApprovedReject.Attributes.Add("disabled", "true");
                    txtRejected.Attributes.Add("disabled", "true");
                    btnBack.Visible = true;
                    btnSubmit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //abc
            }

        }
        #region OpenDocument
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            Session["InspectionTestReportId"] = txtTestReportId.Text;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Redirect("/TestReportModal/LineTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx");
            }

        }
        protected void lnkDocument_Click(object sender, EventArgs e)
        {

            string fileName = Session["DemandNoticeOfLine"].ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else
            {

            }
        }
        protected void lnkInvoiceFire_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Session["InvoiceoffireExtinguisheratSite"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkSingleDiag_Click(object sender, EventArgs e)
        {
            try
            {

                string fileName = Session["SingleLineDiagramofTransformer"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkManufacturing_Click(object sender, EventArgs e)
        {
            try
            {

                string fileName = Session["ManufacturingTestCertificateOfTransformer"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkInvoiceTransformer_Click(object sender, EventArgs e)
        {

            try
            {
                string fileName = Session["InvoiceOfTransferOfPersonalSubstation"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Session["CopyOfNoticeIssuedByUHBVNorDHBVN"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkStructure_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Session["StructureStabilityResolvedByAuthorizedEngineer"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkLetter_Click(object sender, EventArgs e)
        {
            try
            {

                string fileName = Session["RequestLetterFromConcernedOfficer"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnktest_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Session["ManufacturingTestReportOfEqipment"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkDiag_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Session["SingleLineDiagramOfLine"].ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);

                if (File.Exists(filePath))
                {
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Rejection.Visible = false;
                if (RadioButtonList2.SelectedValue == "0")
                {
                    Rejection.Visible = false;
                }
                else if (RadioButtonList2.SelectedValue == "1")
                {
                    Rejection.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //
            }

        }

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlReview.SelectedValue == "2")
            //{
            //    Rejection.Visible = true;
            //}
            //else
            //{
            //    Rejection.Visible = false;
            //}
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InspectionId"].ToString() != null && Session["InspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    StaffId = Session["StaffID"].ToString();
                    ID = Session["InspectionId"].ToString();
                    
                    if (RadioButtonList2.SelectedValue != "" && RadioButtonList2.SelectedValue != null)
                    {
                        AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" : "Return";
                    }
                    
                    Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;
                    CEI.updateInspection(ID,StaffId,IntimationId,count, txtWorkType.Text.Trim(), AcceptorReturn, Reason);                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    if (Session["Area"] != null)
                    {
                        Response.Redirect("/Officers/OfficerDashboard.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Officers/InstallationIntimationDetails.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }

            }
            catch (Exception ex)
            {
                //
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/InstallationIntimationDetails.aspx", false);

        }
    }
}
