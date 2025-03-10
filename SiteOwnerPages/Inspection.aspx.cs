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
using System.Diagnostics;
using System.Drawing;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Inspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id = string.Empty;
        DateTime inspectionCreatedDate;
        string voltage = string.Empty;
        string id = string.Empty;
        string CartId = string.Empty;
        string ReturnedBased = string.Empty;
        private static string IType = string.Empty;
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
                    else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["GeneratingSetId"]) != "")
                    {
                        id = Session["GeneratingSetId"].ToString();
                    }
                    else if (Session["SwitchingSubstationId"] != null && Convert.ToString(Session["SwitchingSubstationId"]) != "")
                    {
                        id = Session["SwitchingSubstationId"].ToString();
                    }

                    GetDetailsWithId();
                    GridBind();

                    if (IType == "New")
                    {
                        GetTestReportData();
                    }
                    else if (IType == "Periodic")
                    {
                        GetTestReportDataIfPeriodic();
                    }

                    //GetTestReportData();

                    Session["PreviousPage"] = "";
                    if (Convert.ToString(Session["Type"]) != null && Convert.ToString(Session["Type"]) != "")
                    {
                        if (Convert.ToString(Session["Type"]) == "Line" || Convert.ToString(Session["Type"]) == "Generating Set")
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
                            txtWorkType.Text = "Generating Set";

                        }
                        else if (Session["SwitchingSubstationId"] != null && Convert.ToString(Session["SwitchingSubstationId"]) != "")
                        {
                            txtWorkType.Text = "Switching Station";
                        }
                    }

                    // Visibilty();
                }
            }
            catch (Exception ex)
            {
                //
            }


        }

        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodic(ID);
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

        public void GetDetailsWithId()
        {
            try
            {
                if (Session["InspectionId"] != null && !string.IsNullOrEmpty(Session["InspectionId"].ToString()))
                {
                    ID = Session["InspectionId"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.InspectionData(ID);

                    IType = ds.Tables[0].Rows[0]["IType"].ToString();

                    if (IType == "New")
                    {
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();

                        string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                        DateTime.TryParse(createdDate, out inspectionCreatedDate);
                        string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();

                        voltagelevel.Visible = true;
                        Type.Visible = true;
                        txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        txtInspectionType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();

                        string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        if (Status == "Rejected")
                        {
                            Rejection.Visible = true;
                            txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                            ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));

                            ddlReview.Attributes.Add("disabled", "true");
                            txtRejected.Attributes.Add("disabled", "true");
                            btnBack.Visible = true;
                            btnSubmit.Visible = false;
                        }
                        if (Status == "Return")
                        {
                            ApprovalRequired.Visible = false;
                            btnSubmit.Visible = false;

                            //buttonSubmit.Visible = true;
                            //Remarks.Visible = true;

                            //Rejection.Visible = true;
                            //txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                            //ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                            //ApprovedReject.Visible = true;
                            //ApprovalRequired.Visible = false;
                            ddlReview.Attributes.Add("disabled", "true");
                            //txtRejected.Attributes.Add("disabled", "true");
                        }
                        string Reason = ds.Tables[0].Rows[0]["ReasonType"].ToString();

                        GridToViewTRinMultipleCaseNew();

                        Div1.Visible = true;
                        DivViewTRinMultipleCaseNew.Visible = true;

                        //if (Reason == "1")
                        //{
                        //    buttonSubmit.Visible = false;
                        //    Remarks.Visible = false;

                        //}
                        //if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RemarkForContractor"].ToString()))
                        //{
                        //    // If not null or empty, disable the textbox
                        //    txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
                        //    txtOwnerRemarks.Enabled = false;
                        //    buttonSubmit.Visible = false;
                        //}
                    }
                    else if (IType == "Periodic")
                    {
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();

                        ReturnedBased = ds.Tables[0].Rows[0]["ReasonType"].ToString();

                        string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                        DateTime.TryParse(createdDate, out inspectionCreatedDate);
                        string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();

                        voltagelevel.Visible = false;
                        Type.Visible = false;
                        GridView2.Columns[3].Visible = false;
                        GridView2.Columns[5].Visible = false;

                        DivViewCart.Visible = true;
                        GridToViewCart();

                        string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        if (Status == "Rejected")
                        {
                            Rejection.Visible = true;
                            txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                            ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                            ddlReview.Attributes.Add("disabled", "true");
                            txtRejected.Attributes.Add("disabled", "true");
                            btnBack.Visible = true;
                            btnSubmit.Visible = false;
                        }
                        if (Status == "Return")
                        {
                            ApprovalRequired.Visible = false;
                            btnSubmit.Visible = false;

                            //buttonSubmit.Visible = true;
                            //Remarks.Visible = true;
                            ddlReview.Attributes.Add("disabled", "true");

                            if (ReturnedBased == "1")
                            {
                                btnResubmit.Visible = true;
                            }
                            else
                            {
                                btnResubmit.Visible = false;
                            }
                        }
                        string Reason = ds.Tables[0].Rows[0]["ReasonType"].ToString();
                        //if (Reason == "1")
                        //{
                        //    buttonSubmit.Visible = false;
                        //    Remarks.Visible = false;

                        //}
                        //if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RemarkForContractor"].ToString()))
                        //{
                        //    txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
                        //    txtOwnerRemarks.Enabled = false;
                        //    buttonSubmit.Visible = false;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GridToViewCart()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewCart(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = dsVC;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton lnkRedirect = (LinkButton)sender;
            string testReportId = lnkRedirect.CommandArgument;
            //Session["InspectionTestReportId"] = testReportId;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Session["LineID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Session["GeneratingSetId"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Switching Station")
            {
                Session["SwitchingSubstationId"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SwitchingSubstationTestReportModal.aspx','_blank');</script>");
            }

        }
        #region
        //protected void lnkDocument_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["DemandNoticeOfLine"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {

        //    }
        //}
        //protected void lnkInvoiceFire_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["InvoiceoffireExtinguisheratSite"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {
        //    }
        //}
        //protected void lnkSingleDiag_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["SingleLineDiagramofTransformer"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {
        //    }
        //}
        //protected void lnkManufacturing_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["ManufacturingTestCertificateOfTransformer"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {
        //    }
        //}
        //protected void lnkInvoiceTransformer_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["InvoiceOfTransferOfPersonalSubstation"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {
        //    }
        //}
        //protected void lnkCopy_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["CopyOfNoticeIssuedByUHBVNorDHBVN"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {
        //    }
        //}
        //protected void lnkStructure_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["StructureStabilityResolvedByAuthorizedEngineer"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {

        //    }
        //}
        //protected void lnkLetter_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["RequestLetterFromConcernedOfficer"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {

        //    }
        //}
        //protected void lnktest_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["ManufacturingTestReportOfEqipment"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {

        //    }
        //}
        //protected void lnkDiag_Click(object sender, EventArgs e)
        //{

        //    string fileName = Session["SingleLineDiagramOfLine"].ToString();
        //    string folderPath = Server.MapPath(fileName);
        //    string filePath = Path.Combine(folderPath);

        //    if (File.Exists(filePath))
        //    {
        //        string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

        //    }
        //    else
        //    {

        //    }
        //}
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
                //if (LineSubstationSupplier.Visible == true)
                //{
                //    if (FileUpload1.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/"));
                //        }

                //        string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/RequestLetterFromConcernedOfficer/";
                //        string fileName = "RequestLetterFromConcernedOfficer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/RequestLetterFromConcernedOfficer/" + fileName);
                //        FileUpload1.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl = path + fileName;
                //    }
                //    if (FileUpload2.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/"));
                //        }

                //        string ext = FileUpload2.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/ManufacturingTestReportOfEqipment/";
                //        string fileName = "ManufacturingTestReportOfEqipment" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestReportOfEqipment/" + fileName);
                //        FileUpload2.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl1 = path + fileName;
                //    }
                //}
                //if (SupplierSub.Visible == true)
                //{
                //    if (FileUpload3.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/"));
                //        }

                //        string ext = FileUpload3.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/SingleLineDiagramOfLine/";
                //        string fileName = "SingleLineDiagramOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramOfLine/" + fileName);
                //        FileUpload3.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl2 = path + fileName;
                //    }
                //}
                //if (LinePersonal.Visible == true)
                //{
                //    if (FileUpload12.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload12.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/"));
                //        }

                //        string ext = FileUpload12.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/DemandNoticeOfLine/";
                //        string fileName = "DemandNoticeOfLine" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/DemandNoticeOfLine/" + fileName);
                //        FileUpload12.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl3 = path + fileName;
                //    }
                //}
                //if (PersonalSub.Visible == true)
                //{
                //    if (FileUpload4.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/"));
                //        }

                //        string ext = FileUpload4.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/";
                //        string fileName = "CopyOfNoticeIssuedByUHBVNorDHBVN" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/CopyOfNoticeIssuedByUHBVNorDHBVN/" + fileName);
                //        FileUpload4.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl4 = path + fileName;
                //    }
                //    if (FileUpload5.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/"));
                //        }

                //        string ext = FileUpload5.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/";
                //        string fileName = "InvoiceOfTransferOfPersonalSubstation" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfTransferOfPersonalSubstation/" + fileName);
                //        FileUpload5.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl5 = path + fileName;
                //    }
                //    if (FileUpload6.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload6.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/"));
                //        }

                //        string ext = FileUpload6.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/";
                //        string fileName = "ManufacturingTestCertificateOfTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingTestCertificateOfTransformer/" + fileName);
                //        FileUpload6.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl6 = path + fileName;
                //    }
                //    if (FileUpload7.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload7.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/"));
                //        }

                //        string ext = FileUpload7.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/SingleLineDiagramofTransformer/";
                //        string fileName = "SingleLineDiagramofTransformer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/SingleLineDiagramofTransformer/" + fileName);
                //        FileUpload7.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl7 = path + fileName;
                //    }
                //    if (FileUpload8.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload8.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/"));
                //        }

                //        string ext = FileUpload8.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/";
                //        string fileName = "InvoiceoffireExtinguisheratSite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceoffireExtinguisheratSite/" + fileName);
                //        FileUpload8.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl8 = path + fileName;
                //    }
                //}
                //if (PersonalGenerating.Visible == true)
                //{
                //    if (FileUpload9.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload9.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/"));
                //        }

                //        string ext = FileUpload9.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/";
                //        string fileName = "InvoiceOfDGSetOfGeneratingSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfDGSetOfGeneratingSet/" + fileName);
                //        FileUpload9.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl9 = path + fileName;
                //    }
                //    if (FileUpload10.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload10.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/"));
                //        }

                //        string ext = FileUpload10.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/ManufacturingCerificateOfDGSet/";
                //        string fileName = "ManufacturingCerificateOfDGSet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ManufacturingCerificateOfDGSet/" + fileName);
                //        FileUpload10.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl10 = path + fileName;
                //    }
                //    if (FileUpload13.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload13.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/"));
                //        }

                //        string ext = FileUpload13.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/";
                //        string fileName = "InvoiceOfExptinguisherOrApparatusAtsite" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/InvoiceOfExptinguisherOrApparatusAtsite/" + fileName);
                //        FileUpload13.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl11 = path + fileName;
                //    }
                //    if (FileUpload11.PostedFile.FileName.Length > 0)
                //    {
                //        FileName = Path.GetFileName(FileUpload11.PostedFile.FileName);
                //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/")))
                //        {
                //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/"));
                //        }

                //        string ext = FileUpload11.PostedFile.FileName.Split('.')[1];
                //        string path = "";
                //        path = "/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/";
                //        string fileName = "StructureStabilityResolvedByAuthorizedEngineer" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //        string filePathInfo2 = "";
                //        filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/StructureStabilityResolvedByAuthorizedEngineer/" + fileName);
                //        FileUpload11.PostedFile.SaveAs(filePathInfo2);
                //        flpPhotourl12 = path + fileName;
                //    }
                //}
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
        protected void GridBind()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds.Tables.Count > 0)
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
            catch (Exception ex)
            {
                //throw;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ID = Session["InspectionId"].ToString();
                    if (e.CommandName == "Select")
                    {
                       // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        //lblerror.Text = fileName;
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
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
                    //TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
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
                //Session["TestRportId"] = TestRportId;
                ds.Dispose();
            }
            catch { }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            string TestReportId = Session["TestReport"].ToString();
            ID = Session["InspectionId"].ToString();
            DataSet ds = new DataSet();
            ////if (IType == "New")
            ////{
            ////    ds = CEI.ContractorRemarks(ID, TestReportId, txtOwnerRemarks.Text.Trim());
            ////}
            ////else if (IType == "Periodic")
            ////{
            ////    ds = CEI.ContractorRemarksInPeriodic(ID, txtOwnerRemarks.Text.Trim());
            ////}
            //txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata1();", true);
        }
        protected void lnkRedirect1_Click1(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                LinkButton lnkRedirect1 = (LinkButton)sender;
                string testReportId = lnkRedirect1.CommandArgument;

                Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Line")
                {
                    Session["LineID"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
                }
                else if (installationName == "Substation Transformer")
                {
                    Session["SubStationID"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");

                }
                else if (installationName == "Generating Set")
                {
                    Session["GeneratingSetId"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
                }
                else if (installationName == "Switching Station")
                {
                    Session["SwitchingSubstationId"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/SwitchingSubstationTestReportModal.aspx','_blank');</script>");
                }
            }
            catch (Exception ex) { }
        }

        protected void btnResubmit_Click(object sender, EventArgs e)
        {
            ID = Session["InspectionId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetDetailsToViewCart(ID);

            CartId = ds.Tables[0].Rows[0]["CartId"].ToString();
            Session["IDCart"] = CartId;
            Session["CartID"] = string.Empty;
            Response.Redirect("/SiteOwnerPages/ProcessInspectionRenewalCart.aspx", false);
        }

        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(ID);

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
            {
                // Log or handle the exception as needed
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
                //IntimationId = Session["id"].ToString();
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
               // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                //lblerror.Text = fileName;
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }


        }

        protected void lnkRedirectTR_Click1(object sender, EventArgs e)
        {

            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();

                Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Line")
                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                }
                else if (installationName == "Substation Transformer")
                {
                    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                }
                else if (installationName == "Generating Set")
                {
                    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                }
                else if (installationName == "Switching Station")
                {
                    
                    Response.Write("<script>window.open('/TestReportModal/SwitchingSubstationTestReportModal.aspx','_blank');</script>");
                }
            }
            catch (Exception ex) { }
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
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Grid_MultipleInspectionTR.Columns[5].Visible = false;
                        Grid_MultipleInspectionTR.Columns[6].Visible = false;
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                    }
                    else
                    {
                        Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}