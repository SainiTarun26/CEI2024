using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        string Id, StaffTo, AssignFrom;
        string Type = string.Empty;

        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
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
                    else if (Session["SubStationID"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Substation Transformer";
                        Id = Session["SubStationID"].ToString();
                    }
                    else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Generating Station";
                        Id = Session["GeneratingSetId"].ToString();
                    }
                    else if (Session["PeriodicMultiple"] != null && Convert.ToString(Session["PeriodicMultiple"]) != "")
                    {
                        txtWorkType.Text = "Multiple";
                        Id = Session["PeriodicMultiple"].ToString();
                    }
                   
                    GetDetailsWithId();
                    GetTestReportData();

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }
        }


        private void BindDivisions(string District)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDivisionData(District);
            ddlDivisions.DataSource = ds;
            ddlDivisions.DataTextField = "HeadOffice";
            ddlDivisions.DataValueField = "HeadOffice";
            ddlDivisions.DataBind();
            ddlDivisions.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }
        private void GetDetailsWithId()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Type = ds.Tables[0].Rows[0]["IType"].ToString();

                    if (Type == "New")
                    {
                        txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        if (txtWorkType.Text == "Line")
                        {
                            Capacity.Visible = false;
                            LineVoltage.Visible = true;
                            txtLineVoltage.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                        }
                        else
                        {
                            LineVoltage.Visible = false;
                            Capacity.Visible = true;
                            txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                        }
                        txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                        txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();

                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                        count = Convert.ToInt32(ds.Tables[0].Rows[0]["TestReportCount"].ToString());           //Added     
                        IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                    }
                    else if (Type == "Periodic")
                    {
                        if (txtWorkType.Text != "Multiple")
                        {
                            txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                            txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                            txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                            txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                            if (txtWorkType.Text == "Line")
                            {
                                Capacity.Visible = false;
                            }
                            else
                            {
                                Capacity.Visible = true;
                                txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                            }
                            txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                            txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                            txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                            ContractorName.Visible = false;
                            SupervisorName.Visible = false;
                            LineVoltage.Visible = false;

                            txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                            txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                            txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                            TypeOfInspection.Visible = false;

                        }
                        else
                        {
                            txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                            txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                            txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                            txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                            txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                            txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                            txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                            ContractorName.Visible = false;
                            SupervisorName.Visible = false;
                            LineVoltage.Visible = false;

                            txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                            txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                            txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                            TypeOfInspection.Visible = false;

                        }
                        TRAttached.Visible = false;
                        TRAttachedGrid.Visible = false;
                        IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();                        
                        grd_Documemnts.Columns[1].Visible = true;
                    }
                    GridBindDocument();
                    BindDivisions(txtDistrict.Text.Trim());

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptMessage", "alert('Data Not found For this inspection');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
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
            Session["InspectionId"] = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InspectionId"] != null && Convert.ToString(Session["InspectionId"]) != "" && Session["AdminID"] != null)
                {
                    ID = Session["InspectionId"].ToString();
                    AssignFrom = Session["AdminID"].ToString();
                    if (RadioButtonAction.SelectedValue != "" && RadioButtonAction.SelectedValue != null)
                    {
                        if (RadioButtonAction.SelectedValue == "0")
                        {
                            AcceptorReturn = RdbtnAccptReturn.SelectedValue == "0" ? "Accepted" : "Return";
                            Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;

                            CEI.updateInspectionCEI(ID, AssignFrom, IntimationId, count, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
                            if (AcceptorReturn == "Accepted")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                                return;
                            }
                            else
                            {
                                if (ddlReasonType.SelectedItem.Value == "0") //Based On Test Report Returned
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                    return;
                                }
                                if (ddlReasonType.SelectedItem.Value == "1") //Based On Documents Returned 
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (ddlToAssign.SelectedValue != null && ddlToAssign.SelectedValue != "0")
                            {
                                StaffTo = ddlToAssign.SelectedValue;
                                CEI.UpdateInspectionDataOnAction(ID, StaffTo, AssignFrom);

                                ddlDivisions.SelectedIndex = 0;
                                ddlToAssign.SelectedIndex = 0;
                                //string script =  $"alert('Inspection sent to {StaffTo} successfully.');";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                                //Response.Redirect("IntimationHistoryForAdmin.aspx",true);
                                string script = $"alert('Inspection sent to {StaffTo} successfully.'); window.location='IntimationHistoryForAdmin.aspx';";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                            }
                            else
                            {
                                ddlToAssign.Focus();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", "alert('Select Staff before save');", true);
                            }
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select the Process or Transfer');", true);
                    }


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.Replace("'", "\\'") + "');", true);
                return;
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ID = Session["InspectionId"].ToString();

                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
            }
        }
        private void BindDropDownToAssign(string Division)
        {
            try
            {
                DataSet dsAssign = new DataSet();
                dsAssign = CEI.DdlToStaffAssign(Division);
                ddlToAssign.DataSource = dsAssign;
                ddlToAssign.DataTextField = "Staff";
                ddlToAssign.DataValueField = "StaffUserId";
                ddlToAssign.DataBind();
                ddlToAssign.Items.Insert(0, new ListItem("Select", "0"));
                dsAssign.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisions.SelectedValue != "" && ddlDivisions.SelectedValue != null)
            {
                BindDropDownToAssign(ddlDivisions.SelectedValue);
            }
        }

        protected void RdbtnAccptReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            Return.Visible = false;
            if (RdbtnAccptReturn.SelectedValue == "1")
            {
                Return.Visible = true;
                btnUpdate.Visible = true;
            }

        }

        protected void RadioButtonAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonAction.SelectedValue == "1")
            {
                // BindDivisions();
                TransferButton.Visible = true;
                btnUpdate.Visible = true;
                Action.Visible = false;
                Return.Visible = false;
                //btnAction.Visible = false;
            }
            else
            {
                TransferButton.Visible = false;
                Action.Visible = true;
                Return.Visible = false;
                btnUpdate.Visible = true;
            }

        }

        protected void GridBindDocument()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found for document\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private void GetTestReportData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
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
            catch (Exception ex) { }
        }
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Session["InspectionTestReportId"] = btn.CommandArgument; //txtTestReportId.Text;

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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

                //e.Row.Cells[2].BackColor = System.Drawing.Color.Blue;
                e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
            }
        }
    }
}