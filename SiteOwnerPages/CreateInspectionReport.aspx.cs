﻿using CEI_PRoject;
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
        string id = string.Empty;
        string fileExtension= string.Empty;
        string fileExtension2= string.Empty;
        string fileExtension3= string.Empty;
        string fileExtension4= string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    if (Session["LineID"] != null)
                    {
                        txtWorkType.Text = "Line";
                        txtLineLength.Text = Session["LineLength"].ToString();
                        id = Session["LineID"].ToString();
                        
                    }
                    else if (Session["SubStationID"] != null)
                    {

                        txtWorkType.Text = "Substation Transformer";
                        id = Session["SubStationID"].ToString();
                    }
                    else if (Session["GeneratingSetId"] != null)
                    {
                        txtWorkType.Text = "Generating Set";
                        id = Session["GeneratingSetId"].ToString();
                    }
                    Session["Data1"] = txtWorkType.Text;
                    txtVoltage.Text = Session["Voltage"].ToString();
                    Session["Data2"] = txtVoltage.Text;
                    txtPremises.Text = Session["InspectionType"].ToString();
                    txtApplicantType.Text = Session["ApplicantType"].ToString();
                    txtContact.Text = Session["ContactNo"].ToString();
                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    Visibility();
                }
            }
            catch
            {
                Response.Redirect("/SiteOwnerLogout.aspx");
            }
        }



        protected void Visibility()
        {
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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
              
                    string Assign = string.Empty;
                string To = string.Empty;
                string input = txtVoltage.Text;
                string IntimationId = Session["IntimationId"].ToString();
                string CreatedBy = Session["SiteOwnerId"].ToString();
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
                string District = string.Empty;
                string FeesLeft = string.Empty;
                District = Session["District"].ToString();
                To = Session["Division"].ToString() ;
                if (Session["LineID"] != null)
                {
                    txtWorkType.Text = "Line";
                    txtLineLength.Text = Session["LineLength"].ToString();
                    id = Session["LineID"].ToString();
                }
                else if (Session["SubStationID"] != null)
                {

                    txtWorkType.Text = "Substation Transformer";
                    id = Session["SubStationID"].ToString();
                }
                else if (Session["GeneratingSetId"] != null)
                {
                    txtWorkType.Text = "Generating Set";
                    id = Session["GeneratingSetId"].ToString();
                }
                if (txtWorkType.Text == "Line")
                {
                    if (input.EndsWith("kv", StringComparison.OrdinalIgnoreCase))
                    {
                        string voltagePart = input.Substring(0, input.Length - 2);
                        if (int.TryParse(voltagePart, out int voltageLevel))
                        {
                            if (voltageLevel >= 11 && voltageLevel <= 33)
                            {
                                Assign = "SDO";
                            }
                            else if (voltageLevel >= 33)

                            {
                                Assign = "Admin@123";
                            }
                            else if (voltageLevel <= 11)

                            {
                                Assign = "JE";
                            }

                        }
                    }

                    else if (input.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                    {
                        Assign = "JE";

                    }
                }
                else
                {
                    if (input.EndsWith("KVA", StringComparison.OrdinalIgnoreCase))
                    {
                        string voltagePart = input.Substring(0, input.Length - 3);
                        if (int.TryParse(voltagePart, out int voltageLevel))
                        {
                            if (voltageLevel >= 250 && voltageLevel <= 500)
                            {
                                Assign = "XEN";
                            }
                            else if (voltageLevel >= 500)

                            {
                                Assign = "Admin@123";
                            }
                            else if (voltageLevel <= 250)
                            {
                                Assign = "SDO";
                            }
                        }

                    }
                    else if (input.EndsWith("MVA", StringComparison.OrdinalIgnoreCase))
                    {
                        Assign = "Admin@123";

                    }

                }
                if (LineSubstationSupplier.Visible == true)
                {
                     fileExtension = Path.GetExtension(FileUpload1.FileName);

                    if (fileExtension.ToLower() == ".pdf")
                    {
                        if (FileUpload1.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/"));
                            }

                            string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/";
                            string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/RequestLetterFromConcernedOfficer/" + fileName);
                            FileUpload1.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl = path + fileName;
                        }
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                    }
                     fileExtension2 = Path.GetExtension(FileUpload2.FileName);

                    if (fileExtension2.ToLower() == ".pdf")
                    {
                        if (FileUpload2.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/"));
                            }

                            string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/";
                            string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingTestReportOfEqipment/" + fileName);
                            FileUpload2.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl1 = path + fileName;
                        }
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                    }
                }
                if (SupplierSub.Visible == true)
                {
                     fileExtension = Path.GetExtension(FileUpload3.FileName);

                    if (fileExtension.ToLower() == ".pdf")
                    {
                        if (FileUpload3.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/"));
                            }

                            string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + id + "/SingleLineDiagramOfLine/";
                            string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/SingleLineDiagramOfLine/" + fileName);
                            FileUpload3.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl2 = path + fileName;
                        }
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                    }
                }
                if (LinePersonal.Visible == true)
                {
                    fileExtension = Path.GetExtension(FileUpload12.FileName);

                    if (fileExtension.ToLower() == ".pdf")
                    {
                        if (FileUpload12.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/DemandNoticeOfLine/"));
                            }

                            string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/DemandNoticeOfLine/";
                            string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
                            FileUpload12.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl3 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                    }
                }
                if (PersonalSub.Visible == true)
                {
                    fileExtension = Path.GetExtension(FileUpload4.FileName);

                    if (fileExtension.ToLower() == ".pdf")
                    {
                        if (FileUpload4.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
                            }

                            string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
                            string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
                            FileUpload4.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl4 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension2 = Path.GetExtension(FileUpload5.FileName);

                    if (fileExtension2.ToLower() == ".pdf")
                    {
                        if (FileUpload5.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/"));
                            }

                            string ext = FileUpload5.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/";
                            string fileName = "InvoiceOfTransferOfPersonalSubstation" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/" + fileName);
                            FileUpload5.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl5 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension3 = Path.GetExtension(FileUpload6.FileName);

                    if (fileExtension3.ToLower() == ".pdf")
                    {
                        if (FileUpload6.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload6.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/"));
                            }

                            string ext = FileUpload6.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/";
                            string fileName = "ManufacturingTestCertificateOfTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/" + fileName);
                            FileUpload6.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl6 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension4 = Path.GetExtension(FileUpload7.FileName);

                    if (fileExtension4.ToLower() == ".pdf")
                    {
                        if (FileUpload7.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload7.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/"));
                            }

                            string ext = FileUpload7.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + id + "/SingleLineDiagramofTransformer/";
                            string fileName = "SingleLineDiagramofTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/" + fileName);
                            FileUpload7.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl7 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension3 = Path.GetExtension(FileUpload8.FileName);

                    if (fileExtension3.ToLower() == ".pdf")
                    {
                        if (FileUpload8.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload8.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/"));
                            }

                            string ext = FileUpload8.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/";
                            string fileName = "InvoiceoffireExtinguisheratSite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/" + fileName);
                            FileUpload8.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl8 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                }
                if (PersonalGenerating.Visible == true)
                {
                    fileExtension = Path.GetExtension(FileUpload9.FileName);

                    if (fileExtension.ToLower() == ".pdf")
                    {
                        if (FileUpload9.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/"));
                            }

                            string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/";
                            string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
                            FileUpload9.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl9 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension2 = Path.GetExtension(FileUpload10.FileName);

                    if (fileExtension2.ToLower() == ".pdf")
                    {
                        if (FileUpload10.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/"));
                            }

                            string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/";
                            string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ManufacturingCerificateOfDGSet/" + fileName);
                            FileUpload10.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl10 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension3 = Path.GetExtension(FileUpload13.FileName);

                    if (fileExtension3.ToLower() == ".pdf")
                    {
                        if (FileUpload13.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
                            }

                            string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/";
                            string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
                            FileUpload13.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl11 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                    fileExtension4 = Path.GetExtension(FileUpload11.FileName);

                    if (fileExtension4.ToLower() == ".pdf")
                    {
                        if (FileUpload11.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/"));
                            }
                            string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/";
                            string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
                            FileUpload11.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl12 = path + fileName;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);

                    }
                }
                // DateTime myDate = Convert.ToDateTime(txtDate.Text);

                //CEI.InsertInspectionData(txtContact.Text, id, IntimationId, txtPremises.Text, txtApplicantType.Text, txtWorkType.Text, txtVoltage.Text,
                //    txtLineLength.Text,flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7, flpPhotourl8,
                //    flpPhotourl9, flpPhotourl10, flpPhotourl11, flpPhotourl12, Assign, District, To, txtRequestDetails.Text, txtDate.Text, CreatedBy);

                string generatedId = CEI.InspectionId();
              // DataSaved.Visible = true;
                Session["PendingPaymentId"] = generatedId;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

             
            }
            catch
            { }
        }

    }
}