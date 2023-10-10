using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class CreateInspectionReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                txtVoltage.Text = Session["Voltage"].ToString();
                txtPremises.Text = Session["InspectionType"].ToString();
                txtApplicantType.Text = Session["ApplicantType"].ToString();
                Visibility();
            }
        }

       

        protected void Visibility()
        {
            Uploads.Visible = true;
            if (txtWorkType.Text == "Line")
            {
                if (txtApplicantType.Text.Trim() == "Supplier")
                {
                    LineSubstationSupplier.Visible = true;
                    SupplierSub.Visible = true;
                }
                else if (txtApplicantType.Text.Trim() == "Private/Personal Installtion")
                {
                    LinePersonal.Visible = true;
                    SupplierSub.Visible = true;
                }
            }
            else if (txtWorkType.Text == "Substation Transformer")
            {
                if (txtApplicantType.Text.Trim() == "Supplier")
                {
                    LineSubstationSupplier.Visible = true;
                }
                else if (txtApplicantType.Text.Trim() == "Private/Personal Installtion")
                {
                    PersonalSub.Visible = true;
                }
            } 
            else if (txtWorkType.Text == "Generating Set")
            {
                 if (txtApplicantType.Text.Trim() == "Private/Personal Installtion")
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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string AssignTo = string.Empty;
            string id = Session["LineID"].ToString();
            string IntimationId = Session["IntimationId"].ToString();
            string CreatedBy = Session["AdminID"].ToString();
            string FileName = string.Empty;
            string flpPhotourl = string.Empty;
            string flpPhotourl1 = string.Empty;
            string flpPhotourl2 = string.Empty;
            string flpPhotourl3 = string.Empty;
            string flpPhotourl4 = string.Empty;
            string flpPhotourl5 = string.Empty;
            string flpPhotourl6 = string.Empty;
            string flpPhotourl7 = string.Empty;
            string flpPhotourl8 = string.Empty;
            string flpPhotourl9 = string.Empty;
            string flpPhotourl10 = string.Empty;
            string flpPhotourl11 = string.Empty;
            string flpPhotourl12 = string.Empty;
            if (FileUpload1.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/"));
                }

                string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/RequestLetterFromConcernedOfficer/";
                string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/PRequestLetterFromConcernedOfficerhoto/" + fileName);
                FileUpload1.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl = path + fileName;
            }
            if (FileUpload2.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/"));
                }

                string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/ManufacturingTestReportOfEqipment/";
                string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/" + fileName);
                FileUpload2.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl1 = path + fileName;
            }
            if (FileUpload3.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/"));
                }

                string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/SingleLineDiagramOfLine/";
                string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/" + fileName);
                FileUpload3.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl2 = path + fileName;
            }  
            if (FileUpload12.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/"));
                }

                string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/DemandNoticeOfLine/";
                string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
                FileUpload12.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl3 = path + fileName;
            }   
            if (FileUpload4.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
                }

                string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
                string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
                FileUpload4.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl4 = path + fileName;
            } 
            if (FileUpload5.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/"));
                }

                string ext = FileUpload5.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/";
                string fileName = "InvoiceOfTransferOfPersonalSubstation" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/" + fileName);
                FileUpload5.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl5 = path + fileName;
            } 
            if (FileUpload6.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload6.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/"));
                }

                string ext = FileUpload6.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/";
                string fileName = "ManufacturingTestCertificateOfTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/" + fileName);
                FileUpload6.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl6 = path + fileName;
            }
            if (FileUpload7.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload7.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/"));
                }

                string ext = FileUpload7.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/SingleLineDiagramofTransformer/";
                string fileName = "SingleLineDiagramofTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/" + fileName);
                FileUpload7.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl7 = path + fileName;
            } 
            if (FileUpload8.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload8.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/"));
                }

                string ext = FileUpload8.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/";
                string fileName = "InvoiceoffireExtinguisheratSite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/" + fileName);
                FileUpload8.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl8 = path + fileName;
            }  
            if (FileUpload9.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/"));
                }

                string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/";
                string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
                FileUpload9.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl9 = path + fileName;
            }
            if (FileUpload10.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/"));
                }

                string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/ManufacturingCerificateOfDGSet/";
                string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/" + fileName);
                FileUpload10.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl10 = path + fileName;
            } 
            if (FileUpload13.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
                }

                string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/";
                string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
                FileUpload13.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl11 = path + fileName;
            }
            if (FileUpload11.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/"));
                }

                string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/";
                string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
                FileUpload11.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl12 = path + fileName;
            }
            CEI.InsertInspectionData(id, IntimationId, txtPremises.Text, txtWorkType.Text, txtVoltage.Text, 
                flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6,flpPhotourl7,flpPhotourl8,
                flpPhotourl9,flpPhotourl10,flpPhotourl11,flpPhotourl12,AssignTo, CreatedBy);
        }
    }
}