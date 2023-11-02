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


namespace CEIHaryana.SiteOwnerPages
{
    public partial class Inspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Session["LineID"].ToString();
                if (Session["LineID"] != null)
                {
                    txtWorkType.Text = "Line";

                }
                else if (Session["SubStationID"] != null)
                {

                    txtWorkType.Text = "Substation Transformer";

                }
                else if (Session["GeneratingSetId"] != null)
                {
                    txtWorkType.Text = "Generating Station";

                }
                GetDetailsWithId();
               Visibilty();
            }


        }


        public void Visibilty()
        {
            Uploads.Visible = true;
            Uploads.Visible = true;
            if (txtWorkType.Text == "Line")
            {
                if (txtApplicantType.Text.Trim() == "Supplier Installation")
                {
                    LineSubstationSupplier.Visible = true;
                    SupplierSub.Visible = true;
                }
                else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                {
                    LinePersonal.Visible = true;
                    SupplierSub.Visible = true;
                }
            }
            else if (txtWorkType.Text == "Substation Transformer")
            {
                if (txtApplicantType.Text.Trim() == "Supplier Installation")
                {
                    LineSubstationSupplier.Visible = true;
                }
                else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                {
                    PersonalSub.Visible = true;
                }
            }
            else if (txtWorkType.Text == "Generating Set")
            {
                if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
                {
                    PersonalGenerating.Visible = true;
                }
                else
                {
                    PersonalGenerating.Visible = false;
                }
            }
            else
            {
                LineSubstationSupplier.Visible = false;
                SupplierSub.Visible = false;
                PersonalGenerating.Visible = false;
            }
            if (Session["Approval"].ToString() == "Initiated" || Session["Approval"].ToString() == "Accept"|| Session["Approval"].ToString() == "InProgress")
            {
                btnBack.Visible = true;
            }
            else if(Session["Approval"].ToString().Trim() == "Rejected")
            {
                RejectedColumn.Visible = true;
                RejectedColumnData1.Visible = true;
                RejectedColumnData2.Visible = true;
                RejectedColumnData3.Visible = true;
                RejectedColumnData4.Visible = true;
                RejectedColumnData5.Visible = true;
                RejectedColumnData6.Visible = true;
                RejectedColumnData7.Visible = true;
                RejectedColumnData8.Visible = true;
                RejectedColumnData9.Visible = true;
                RejectedColumnData10.Visible = true;
                RejectedColumnData11.Visible = true;
                RejectedColumnData12.Visible = true;
                RejectedColumnData13.Visible = true;
            }
            else
            {
                RejectedColumn.Visible = false;
                RejectedColumnData1.Visible = false;
                RejectedColumnData2.Visible = false;
                RejectedColumnData3.Visible = false;
                RejectedColumnData4.Visible = false;
                RejectedColumnData5.Visible = false;
                RejectedColumnData6.Visible = false;
                RejectedColumnData7.Visible = false;
                RejectedColumnData8.Visible = false;
                RejectedColumnData9.Visible = false;
                RejectedColumnData10.Visible = false;
                RejectedColumnData11.Visible = false;
                RejectedColumnData12.Visible = false;
                RejectedColumnData13.Visible = false;
            }
        }

        public void GetDetailsWithId()
        {
            try
            {
                ID = Session["InspectionId"].ToString();

                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);
                txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
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
               
            }
            catch
            {

            }



        }

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            Session["InspectionTestReportId"] = txtTestReportId.Text;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Redirect("/TestReportModal/LineTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Redirect("TestReportModal/SubstationTransformerTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Generating Station")
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
        protected void lnkSingleDiag_Click(object sender, EventArgs e)
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
        protected void lnkManufacturing_Click(object sender, EventArgs e)
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
        protected void lnkInvoiceTransformer_Click(object sender, EventArgs e)
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
        protected void lnkCopy_Click(object sender, EventArgs e)
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
        protected void lnkStructure_Click(object sender, EventArgs e)
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
        protected void lnkLetter_Click(object sender, EventArgs e)
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
        protected void lnktest_Click(object sender, EventArgs e)
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

        protected void lnkDiag_Click(object sender, EventArgs e)
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx");
        }
    }
}