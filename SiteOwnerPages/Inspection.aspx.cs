﻿using CEI_PRoject;
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
        DateTime inspectionCreatedDate;
        string voltage = string.Empty;
        string id = string.Empty;
        bool Edit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        id = Session["LineID"].ToString();

                    }
                    else if (Session["SubStationID"] != null && Convert.ToString(Session["SubStationID"]) != "")
                    {
                        id = Session["SubStationID"].ToString();
                    }
                    else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["GeneratingSetId"]) !="")
                    {
                        id = Session["GeneratingSetId"].ToString();
                    }

                    GetDetailsWithId();

                    Session["PreviousPage"] = "";
                    if (Convert.ToString(Session["Type"]) != null && Convert.ToString(Session["Type"]) != "")
                    {
                        if (Convert.ToString(Session["Type"]) == "Line" || Convert.ToString(Session["Type"]) == "Generating Station")
                        {
                            string voltage = txtVoltage.Text;
                            string voltagePart = voltage.Substring(0, voltage.Length - 2);
                            int.TryParse(voltagePart, out int voltageLevel);

                            if (voltageLevel <= 415)
                            {
                                if (DateTime.Now.Subtract(inspectionCreatedDate).TotalDays >= 1095)
                                {
                                    string script = "alert(\" Now You Can edit this inspection because your 3 years time period is complete for update\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = true;
                                    Edit = true;
                                    //RejectedColumn.Visible = true;
                                }
                                else
                                {
                                    string script = "alert(\"You Can't edit this inspection before 3 years\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = false;
                                }
                            }
                            else
                            {
                                if (DateTime.Now.Subtract(inspectionCreatedDate).TotalDays >= 365)
                                {
                                    string script = "alert(\"Now You Can edit this inspection because your annual time period is completed\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = true;
                                    Edit = true;
                                    //RejectedColumn.Visible = true;
                                }
                                else
                                {
                                    string script = "alert(\"You Can't edit this inspection before 1 year\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            if (DateTime.Now.Subtract(inspectionCreatedDate).TotalDays >= 365)
                            {
                                string script = "alert(\"Now You Can edit this inspection because your annual time period is completed\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                btnSubmit.Visible = true;
                                Edit = true;

                            }
                            else
                            {
                                string script = "alert(\"You Can't edit inspection before 1 year\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                btnSubmit.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                        {
                            txtWorkType.Text = "Line";

                        }
                        else if (Session["SubStationID"] != null && Convert.ToString(Session["SubStationID"]) != "")
                        {

                            txtWorkType.Text = "Substation Transformer";

                        }
                        else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["GeneratingSetId"]) != "")
                        {
                            txtWorkType.Text = "Generating Station";

                        }
                    }

                    Visibilty();
                }
            }
            catch (Exception ex)
            {
            //
            }


        }


        public void Visibilty()
        {

            Uploads.Visible = true;
            // Uploads.Visible = true;
            if (txtWorkType.Text.Trim() == "Line")
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
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
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
            else if (txtWorkType.Text.Trim() == "Generating Station")
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
            //if (Session["Approval"].ToString().Trim() != "Initiated" || Session["Approval"].ToString() == "Accept"|| Session["Approval"].ToString() == "InProgress")
            //{
            //    btnBack.Visible = true;
            //}
            //else 
            if (Edit == true)
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
                //btnSubmit.Visible = true;
                btnBack.Visible = true;
            }
            //if (Session["Approval"].ToString().Trim() == "Rejected")
            //{
            //    RejectedColumn.Visible = true;
            //    RejectedColumnData1.Visible = true;
            //    RejectedColumnData2.Visible = true;
            //    RejectedColumnData3.Visible = true;
            //    RejectedColumnData4.Visible = true;
            //    RejectedColumnData5.Visible = true;
            //    RejectedColumnData6.Visible = true;
            //    RejectedColumnData7.Visible = true;
            //    RejectedColumnData8.Visible = true;
            //    RejectedColumnData9.Visible = true;
            //    RejectedColumnData10.Visible = true;
            //    RejectedColumnData11.Visible = true;
            //    RejectedColumnData12.Visible = true;
            //    RejectedColumnData13.Visible = true;
            //    btnSubmit.Visible = true;
            //    btnBack.Visible = true;
            //}
            //else
            //{
            //    RejectedColumn.Visible = false;
            //    RejectedColumnData1.Visible = false;
            //    RejectedColumnData2.Visible = false;
            //    RejectedColumnData3.Visible = false;
            //    RejectedColumnData4.Visible = false;
            //    RejectedColumnData5.Visible = false;
            //    RejectedColumnData6.Visible = false;
            //    RejectedColumnData7.Visible = false;
            //    RejectedColumnData8.Visible = false;
            //    RejectedColumnData9.Visible = false;
            //    RejectedColumnData10.Visible = false;
            //    RejectedColumnData11.Visible = false;
            //    RejectedColumnData12.Visible = false;
            //    RejectedColumnData13.Visible = false;
            //}
        }

        public void GetDetailsWithId()
        {
            try
            {
                if (Session["InspectionId"] != null && Session["InspectionId"] != "")
                {
                    ID = Session["InspectionId"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.InspectionData(ID);
                    txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                    string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                    DateTime.TryParse(createdDate, out inspectionCreatedDate);


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
            }
            catch (Exception ex)
            {
                //
            }
        }
        #region for open document
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
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            Session["InspectionTestReportId"] = txtTestReportId.Text;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
            }
            else if (txtWorkType.Text.Trim() == "Generating Station")
            {
                Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
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
        #endregion

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["PeriodicInspection"] != null)
            {
                Response.Redirect("/SiteOwnerPages/PeroidicInspection.aspx", false);
            }
            else
            {
                Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //bool allFilesArePDF = true;

            //for (int i = 1; i <= 15; i++)
            //{
            //    FileUpload fileUploadControl = (FileUpload)FindControl("FileUpload" + i);

            //    if (fileUploadControl.HasFile)
            //    {
            //        string fileExtension = System.IO.Path.GetExtension(fileUploadControl.FileName);

            //        if (fileExtension.ToLower() != ".pdf")
            //        {
            //            allFilesArePDF = false;
            //            break;

            //        }
            //    }
            //}

            //if (allFilesArePDF)
            //{
            if (Session["SiteOwnerId"] != null)
            {
                string Assign = string.Empty;
                string To = string.Empty;
                string input = txtVoltage.Text;
                string id = Session["LineID"].ToString();
                //string IntimationId = Session["IntimationId"].ToString();
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
                //To = Session["District"].ToString();
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
                #region Upload documents
                if (LineSubstationSupplier.Visible == true)
                {
                    if (FileUpload1.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/"));
                        }

                        string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/RequestLetterFromConcernedOfficer/";
                        string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/" + fileName);
                        FileUpload1.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl = path + fileName;
                    }
                    if (FileUpload2.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/"));
                        }

                        string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/ManufacturingTestReportOfEqipment/";
                        string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/" + fileName);
                        FileUpload2.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl1 = path + fileName;
                    }
                }
                if (SupplierSub.Visible == true)
                {
                    if (FileUpload3.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/"));
                        }

                        string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/SingleLineDiagramOfLine/";
                        string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/" + fileName);
                        FileUpload3.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl2 = path + fileName;
                    }
                }
                if (LinePersonal.Visible == true)
                {
                    if (FileUpload12.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/"));
                        }

                        string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/DemandNoticeOfLine/";
                        string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
                        FileUpload12.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl3 = path + fileName;
                    }
                }
                if (PersonalSub.Visible == true)
                {
                    if (FileUpload4.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
                        }

                        string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
                        string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
                        FileUpload4.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl4 = path + fileName;
                    }
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
                if (PersonalGenerating.Visible == true)
                {
                    if (FileUpload9.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/"));
                        }

                        string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/";
                        string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
                        FileUpload9.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl9 = path + fileName;
                    }
                    if (FileUpload10.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/"));
                        }

                        string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/ManufacturingCerificateOfDGSet/";
                        string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/" + fileName);
                        FileUpload10.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl10 = path + fileName;
                    }
                    if (FileUpload13.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
                        }

                        string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/";
                        string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
                        FileUpload13.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl11 = path + fileName;
                    }
                    if (FileUpload11.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/"));
                        }

                        string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/";
                        string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
                        FileUpload11.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl12 = path + fileName;
                    }
                }
                #endregion

                ID = Session["InspectionId"].ToString();
                CEI.UpdateInspectionData(ID, id, txtPremises.Text, txtApplicantType.Text, txtWorkType.Text, txtVoltage.Text, flpPhotourl, flpPhotourl,
                  flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7, flpPhotourl8,
                  flpPhotourl9, flpPhotourl10, flpPhotourl11, flpPhotourl12, Assign, CreatedBy);

            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
    }
}