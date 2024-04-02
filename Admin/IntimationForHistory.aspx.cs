using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class IntimationForHistory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Line";
                        Id = Session["LineID"].ToString();
                    }
                    else if (Session["SubStationID"] != null && Convert.ToString(Session["LineID"]) != "" )
                    {
                        txtWorkType.Text = "Substation Transformer";
                        Id = Session["SubStationID"].ToString();
                    }
                    else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Generating Station";
                        Id = Session["GeneratingSetId"].ToString();
                    }

                    GetDetailsWithId();
                    Visibilty();
                    BindDropDownToAssign();
                    string Approval = Session["Approval"].ToString();
                    if (Approval.Trim() == "Accepted" || Approval.Trim() == "Rejected")
                    {
                        ApprovalRequired.Visible = true;
                        btnAction.Visible = false;
                        ddlReview.Attributes.Add("disabled", "true");
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Approval));
                        DivToAssign.Visible = false;
                        btnUpdate.Visible = false;
                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private void Visibilty()
        {
            btnUpdate.Visible = false;
            btnAction.Visible = true;
            Uploads.Visible = true;
            Uploads.Visible = true;
            Uploads.Visible = true;
            Uploads.Visible = true;
            if (txtWorkType.Text == "Line")
            {
                if (txtApplicantType.Text.Trim() == "Power Utility")
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
                if (txtApplicantType.Text.Trim() == "Power Utility")
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
            if (Session["Approval"].ToString().Trim() == "Rejected")
            {
                btnBack.Visible = true;
            }
           
        }

        private void GetDetailsWithId()
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

        protected void LinkButton1_Click(object sender, EventArgs e)
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

        protected void lnkDGSetInvoice_Click(object sender, EventArgs e)
        {
            string fileName = Session["InvoiceOfDGSetOfGeneratingSet"].ToString();
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

        protected void lnkManufacturingCertificate_Click(object sender, EventArgs e)
        {
            string fileName = Session["ManufacturingCerificateOfDGSet"].ToString();
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

        protected void lnkInvoice_Click(object sender, EventArgs e)
        {
            string fileName = Session["InvoiceOfExptinguisherOrApparatusAtsite"].ToString();
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

        protected void lnkDocument_Click(object sender, EventArgs e)
        {
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
        }
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            Session["IntimationForHistoryId"] = txtTestReportId.Text;
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

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    bool allFilesArePDF = true;
        //    for (int i = 1; i <= 15; i++)
        //    {
        //        FileUpload fileUploadControl = (FileUpload)FindControl("FileUpload" + i);
        //        if (fileUploadControl.HasFile)
        //        {
        //            string fileExtension = System.IO.Path.GetExtension(fileUploadControl.FileName);
        //            if (fileExtension.ToLower() != ".pdf")
        //            {
        //                allFilesArePDF = false;
        //                break;
        //            }
        //        }
        //    }

        //    if (allFilesArePDF)
        //    {
        //        string Assign = string.Empty;
        //        string To = string.Empty;
        //        string input = txtVoltage.Text;
        //        string id = Session["LineID"].ToString();
        //        string IntimationId = Session["IntimationId"].ToString();
        //        string CreatedBy = Session["SiteOwnerId"].ToString();
        //        string FileName = string.Empty;
        //        string flpPhotourl = string.Empty;
        //        string flpPhotourl1 = string.Empty;
        //        string flpPhotourl2 = string.Empty;
        //        string flpPhotourl3 = string.Empty;
        //        string flpPhotourl4 = string.Empty;
        //        string flpPhotourl5 = string.Empty;
        //        string flpPhotourl6 = string.Empty;
        //        string flpPhotourl7 = string.Empty;
        //        string flpPhotourl8 = string.Empty;
        //        string flpPhotourl9 = string.Empty;
        //        string flpPhotourl10 = string.Empty;
        //        string flpPhotourl11 = string.Empty;
        //        string flpPhotourl12 = string.Empty;
        //        To = Session["District"].ToString();
        //        if (txtWorkType.Text == "Line")
        //        {
        //            if (input.EndsWith("kv", StringComparison.OrdinalIgnoreCase))
        //            {
        //                string voltagePart = input.Substring(0, input.Length - 2);
        //                if (int.TryParse(voltagePart, out int voltageLevel))
        //                {
        //                    if (voltageLevel >= 11 && voltageLevel <= 33)
        //                    {
        //                        Assign = "SDO";
        //                    }
        //                    else if (voltageLevel >= 33)
        //                    {
        //                        Assign = "Admin@123";
        //                    }
        //                    else if (voltageLevel <= 11)
        //                    {
        //                        Assign = "JE";
        //                    }
        //                }
        //            }

        //            else if (input.EndsWith("v", StringComparison.OrdinalIgnoreCase))
        //            {
        //                Assign = "JE";
        //            }
        //        }
        //        else
        //        {
        //            if (input.EndsWith("KVA", StringComparison.OrdinalIgnoreCase))
        //            {
        //                string voltagePart = input.Substring(0, input.Length - 3);
        //                if (int.TryParse(voltagePart, out int voltageLevel))
        //                {
        //                    if (voltageLevel >= 250 && voltageLevel <= 500)
        //                    {
        //                        Assign = "XEN";
        //                    }
        //                    else if (voltageLevel >= 500)
        //                    {
        //                        Assign = "Admin@123";
        //                    }
        //                    else if (voltageLevel <= 250)
        //                    {
        //                        Assign = "SDO";
        //                    }
        //                }
        //            }
        //            else if (input.EndsWith("MVA", StringComparison.OrdinalIgnoreCase))
        //            {
        //                Assign = "Admin@123";
        //            }
        //        }
        //        if (LineSubstationSupplier.Visible == true)
        //        {
        //            if (FileUpload1.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/"));
        //                }
        //                string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/RequestLetterFromConcernedOfficer/";
        //                string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/" + fileName);
        //                FileUpload1.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl = path + fileName;
        //            }
        //            if (FileUpload2.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/"));
        //                }
        //                string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/ManufacturingTestReportOfEqipment/";
        //                string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/" + fileName);
        //                FileUpload2.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl1 = path + fileName;
        //            }
        //        }
        //        if (SupplierSub.Visible == true)
        //        {
        //            if (FileUpload3.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/"));
        //                }
        //                string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/SingleLineDiagramOfLine/";
        //                string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/" + fileName);
        //                FileUpload3.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl2 = path + fileName;
        //            }
        //        }
        //        if (LinePersonal.Visible == true)
        //        {
        //            if (FileUpload12.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/"));
        //                }
        //                string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/DemandNoticeOfLine/";
        //                string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
        //                FileUpload12.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl3 = path + fileName;
        //            }
        //        }
        //        if (PersonalSub.Visible == true)
        //        {
        //            if (FileUpload4.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
        //                }
        //                string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
        //                string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
        //                FileUpload4.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl4 = path + fileName;
        //            }
        //            if (FileUpload5.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/"));
        //                }
        //                string ext = FileUpload5.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/";
        //                string fileName = "InvoiceOfTransferOfPersonalSubstation" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/" + fileName);
        //                FileUpload5.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl5 = path + fileName;
        //            }
        //            if (FileUpload6.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload6.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/"));
        //                }
        //                string ext = FileUpload6.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/";
        //                string fileName = "ManufacturingTestCertificateOfTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/" + fileName);
        //                FileUpload6.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl6 = path + fileName;
        //            }
        //            if (FileUpload7.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload7.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/"));
        //                }
        //                string ext = FileUpload7.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/SingleLineDiagramofTransformer/";
        //                string fileName = "SingleLineDiagramofTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/" + fileName);
        //                FileUpload7.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl7 = path + fileName;
        //            }
        //            if (FileUpload8.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload8.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/"));
        //                }
        //                string ext = FileUpload8.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/";
        //                string fileName = "InvoiceoffireExtinguisheratSite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/" + fileName);
        //                FileUpload8.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl8 = path + fileName;
        //            }
        //        }
        //        if (PersonalGenerating.Visible == true)
        //        {
        //            if (FileUpload9.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/"));
        //                }
        //                string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/";
        //                string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
        //                FileUpload9.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl9 = path + fileName;
        //            }
        //            if (FileUpload10.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/"));
        //                }
        //                string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/ManufacturingCerificateOfDGSet/";
        //                string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/" + fileName);
        //                FileUpload10.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl10 = path + fileName;
        //            }
        //            if (FileUpload13.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
        //                }
        //                string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/";
        //                string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
        //                FileUpload13.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl11 = path + fileName;
        //            }
        //            if (FileUpload11.PostedFile.FileName.Length > 0)
        //            {
        //                FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
        //                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/")))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/"));
        //                }
        //                string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
        //                string path = "";
        //                path = "/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/";
        //                string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
        //                string filePathInfo2 = "";
        //                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
        //                FileUpload11.PostedFile.SaveAs(filePathInfo2);
        //                flpPhotourl12 = path + fileName;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Select PDF Files only')", true);
        //    }
        //}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/IntimationHistoryForAdmin.aspx");
        }
        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("/Admin/IntimationHistoryForAdmin.aspx");
        //}

        protected void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                ApprovalRequired.Visible = true;
                DivToAssign.Visible = true;
                DivAdditionalNote.Visible = true;
                btnUpdate.Visible = true;
                btnAction.Visible = false;

            }

            catch (Exception ex)
            {

            }
        }

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rejection.Visible = false;
            if (ddlReview.SelectedValue == "2")
            {
                Rejection.Visible = true;
            }
            else
            {
                Rejection.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(Session["InspectionId"] != null && Convert.ToString(Session["InspectionId"]) != "")
                {
                    ID = Session["InspectionId"].ToString();
                    CEI.UpdateInspectionDataOnAction(ID, ddlReview.SelectedItem.ToString(), txtRejected.Text, ddlToAssign.SelectedItem.ToString(), txtAdditionalNote.Text);


                    ddlReview.SelectedIndex = 0;
                    txtRejected.Text = string.Empty;
                    ddlToAssign.SelectedIndex = 0;
                    txtAdditionalNote.Text = string.Empty;

                    string script = "alert('Data updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void BindDropDownToAssign()
        {
            try
            {
                DataSet dsAssign = new DataSet();
                dsAssign = CEI.DdlToAssign();
                ddlToAssign.DataSource = dsAssign;
                ddlToAssign.DataTextField = "StaffUserId";
                ddlToAssign.DataValueField = "Id";
                ddlToAssign.DataBind();
                ddlToAssign.Items.Insert(0, new ListItem("Select", "0"));

                Rejection.Visible = ddlReview.SelectedValue == "2";
                dsAssign.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
    }
}