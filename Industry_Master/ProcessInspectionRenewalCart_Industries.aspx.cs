using CEI_PRoject;
using CEIHaryana.Model.Industry;
using CEIHaryana.Officers;
using iText.Commons.Bouncycastle.Cert.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Util;
using System.Xml.Linq;

namespace CEIHaryana.Industry_Master
{
    public partial class ProcessInspectionRenewalCart_Industries : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        List<(string InspectionId, string CartId, string Installtypes, string DocumentId, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string, string, string)>();
        private static string IdCart, Voltage, Capacity, TestRportId, IntimationId, InstallationType, VoltageLevel, ApplicantType, District, Division, AssignTo, PaymentMode, Amount, NewInspectionId, type, inspectionCountRes, inspectionIdRes;
        int para_InspectID = 0;
        string CartID = string.Empty;
        string generatedIdCombinedDetails = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_Industry"] != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                    {
                        hfOwner.Value = Convert.ToString(Session["SiteOwnerId_Industry"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["IDCart_Industry"])))
                        {
                            CartID = Convert.ToString(Session["IDCart_Industry"]);
                        }
                        else
                        {
                            CartID = Convert.ToString(Session["CartID_Industry"]);
                        }
                        Page.Session["ClickCount"] = "0";
                        DataSet ds = new DataSet();
                        ds = CEI.GetPeriodicType_Industries(CartID);
                        type = ds.Tables[0].Rows[0]["InspectionStatus"].ToString();
                        NewInspectionId = ds.Tables[0].Rows[0]["NewInspectionId"].ToString();
                        if (type != "Returned" && type != null)
                        {
                            getInspectionData();
                        }
                        else
                        {
                            GetInspectionDataIfPeriodicExist();


                            InspectionDetails.Visible = true;
                            InspectionDetailsHeading.Visible = true;

                            ToViewInspectionDetails(NewInspectionId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }
        }

        private void ToViewInspectionDetails(string newInspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.ToViewInspectionDetails_InIndustry(NewInspectionId);
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex) { }
        }

        private void GetInspectionDataIfPeriodicExist()
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                {
                    if (hfOwner.Value == Convert.ToString(Session["SiteOwnerId_Industry"]))
                    {
                        string IdLogin = Session["SiteOwnerId_Industry"].ToString();
                        string CartID = string.Empty;
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["IDCart_Industry"])))
                        {
                            CartID = Convert.ToString(Session["IDCart_Industry"]);
                        }
                        else
                        {
                            CartID = Convert.ToString(Session["CartID_Industry"]);
                        }
                        DataSet ds = new DataSet();
                        ds = CEI.GetPeriodicdataAfterCart_Industries(CartID);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            Capacity = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                            Voltage = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                            Amount = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                            LblAmount.Text = Amount;

                            int TotalCalAmount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalAmount"]);
                            if (TotalCalAmount == 0)
                            {
                                challanDetailsDiv.Visible = false;
                            }
                            else
                            {
                                challanDetailsDiv.Visible = true;
                            }

                            LblVoltage.Text = Voltage;
                            LblCapacity.Text = Capacity;
                            IdCart = ds.Tables[0].Rows[0]["CartId"].ToString();

                            TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                            IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                            VoltageLevel = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                            ApplicantType = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                            InstallationType = ds.Tables[0].Rows[0]["InstallationType"].ToString();

                            District = ds.Tables[0].Rows[0]["District"].ToString();
                            Division = ds.Tables[0].Rows[0]["Division"].ToString();
                            AssignTo = ds.Tables[0].Rows[0]["ExistingAssignTo"].ToString();
                            PaymentMode = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
                            GetOtherDetails_ForReturnedInspection(NewInspectionId);

                            para_InspectID = Convert.ToInt32(ds.Tables[0].Rows[0]["InspectionCount"].ToString());
                            HF_para_InspectID.Value = para_InspectID.ToString();

                            //inspectionCountRes = ds.Tables[0].Rows[0]["InspectionCount"].ToString();
                            //inspectionIdRes = ds.Tables[0].Rows[0]["InspectionId"].ToString();
                            int ServiceType = 0;
                            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["ServiceType"] != DBNull.Value)
                            {
                                ServiceType = Convert.ToInt32(ds.Tables[0].Rows[0]["ServiceType"]);
                                Session["ServiceType"] = ServiceType;
                            }
                            DataSet dsDetails = CEI.GetDocumentsforPeriodicIfExist(NewInspectionId);

                            if (dsDetails != null && dsDetails.Tables[0].Rows.Count > 0)
                            {
                                //AddFixedRows(dsDetails);
                                GridView2.DataSource = dsDetails;
                                GridView2.DataBind();
                            }
                            else
                            {
                                dsDetails = CEI.GetDocumentforPeriodic_Industries(IdCart);

                                if (dsDetails != null && dsDetails.Tables[0].Rows.Count > 0)
                                {

                                    if (TotalCalAmount == 0)
                                    {
                                        AddFixedRowsIfAmountZero(dsDetails);
                                        challanDetailsDiv.Visible = false;
                                    }
                                    else
                                    {
                                        AddFixedRows(dsDetails);
                                        challanDetailsDiv.Visible = true;
                                    }

                                    //AddFixedRows(dsDetails);
                                    GridView1.DataSource = dsDetails;
                                    GridView1.DataBind();
                                }
                                else
                                {
                                    GridView1.DataSource = null;
                                    btnSubmit.Enabled = false;
                                }
                                //GridView2.DataSource = null;
                                //GridView2.DataBind();
                            }
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId_Industry"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void AddFixedRowsIfAmountZero(DataSet dsDetails)
        {
            try
            {
                DataTable dt = dsDetails.Tables[0];

                DataRow fixedRow1 = dt.NewRow();
                fixedRow1["DocumentName"] = "Other Document";
                dt.Rows.Add(fixedRow1);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void GetOtherDetails_ForReturnedInspection(string newInspectionId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                string query = "Sp_GetOtherDetails_ForReturnedInspection";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InspectionId", NewInspectionId);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtTransactionId.Text = reader["TransactionId"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void getInspectionData()
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                {
                    if (hfOwner.Value == Convert.ToString(Session["SiteOwnerId_Industry"]))
                    {
                        string IdLogin = Session["SiteOwnerId_Industry"].ToString();

                        string CartID = Session["CartID_Industry"].ToString();
                        DataSet ds = new DataSet();
                        ds = CEI.GetPeriodicdataAfterCart_Industries(CartID);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            Capacity = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                            Voltage = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                            Amount = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                            int TotalCalculatedAmount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalAmount"]);
                            if (TotalCalculatedAmount == 0)
                            {
                                challanDetailsDiv.Visible = false;
                            }
                            else
                            {
                                challanDetailsDiv.Visible = true;
                            }

                            LblAmount.Text = Amount;
                            LblVoltage.Text = Voltage;
                            LblCapacity.Text = Capacity;
                            IdCart = ds.Tables[0].Rows[0]["CartId"].ToString();

                            TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                            IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                            VoltageLevel = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                            ApplicantType = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                            InstallationType = ds.Tables[0].Rows[0]["InstallationType"].ToString();

                            District = ds.Tables[0].Rows[0]["District"].ToString();
                            Division = ds.Tables[0].Rows[0]["Division"].ToString();
                            AssignTo = ds.Tables[0].Rows[0]["AssignTo"].ToString();
                            PaymentMode = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
                            //TypeOfInspection = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                            int ServiceType = 0;
                            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["ServiceType"] != DBNull.Value)
                            {
                                ServiceType = Convert.ToInt32(ds.Tables[0].Rows[0]["ServiceType"]);
                                Session["ServiceType"] = ServiceType;
                            }

                            DataSet dsDetails = CEI.GetDocumentforPeriodic(IdCart);

                            //NewInspectionId = dsDetails.Tables[0].Rows[0]["NewInspectionId"].ToString();
                            //if (NewInspectionId != null)
                            if (dsDetails != null && dsDetails.Tables[0].Rows.Count > 0)
                            {
                                if (TotalCalculatedAmount == 0)
                                {
                                    AddFixedRowsIfAmountZero(dsDetails);
                                    challanDetailsDiv.Visible = false;
                                }
                                else
                                {
                                    AddFixedRows(dsDetails);
                                    challanDetailsDiv.Visible = true;
                                }
                                //AddFixedRows(dsDetails);
                                GridView1.DataSource = dsDetails;
                                GridView1.DataBind();
                            }
                            else
                            {
                                btnSubmit.Enabled = false;
                                GridView1.DataSource = null;
                                // GridView1.DataBind();
                            }
                        }

                        else
                        {
                            btnSubmit.Enabled = false;
                            GridView1.DataSource = null;
                            //GridView1.DataBind();
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId_Industry"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }
                else
                {
                    Session["SiteOwnerId_Industry"] = "";
                    Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        private void AddFixedRows(DataSet dsDetails)
        {
            try
            {
                DataTable dt = dsDetails.Tables[0];

                DataRow fixedRow1 = dt.NewRow();
                fixedRow1["DocumentName"] = "Treasury Challan";
                dt.Rows.Add(fixedRow1);

                DataRow fixedRow2 = dt.NewRow();
                fixedRow2["DocumentName"] = "Other Document";
                dt.Rows.Add(fixedRow2);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        //public void UploadCheckListDocInCollection(string CreatedByy, int check_para, string CartID)
        //{
        //    try
        //    {
        //        if (check_para == 0)
        //        {
        //            foreach (GridViewRow row in GridView1.Rows)
        //            {
        //                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
        //                Label lblDocumentName = (Label)row.FindControl("lblDocumentName");
        //                string DocSaveName = lblDocumentName.Text;
        //                string DocName = lblDocumentName.Text;

        //                string DocumentId = string.Empty;
        //                switch (DocName)
        //                {
        //                    case "Previous Inspection Report":
        //                        DocumentId = "9";
        //                        break;
        //                    case "Treasury Challan":
        //                        DocumentId = "17";
        //                        break;
        //                    case "Other Document":
        //                        DocumentId = "14";
        //                        break;
        //                    default:
        //                        DocumentId = string.Empty;
        //                        break;
        //                }

        //                string TypeOfInspection = string.Empty;
        //                string CartId = IdCart;

        //                Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
        //                string InstallTypes = LblInstallationType.Text;

        //                Label LblCategory = (Label)row.FindControl("LblCategory");
        //                string Categary = LblInstallationType.Text;
        //                Label LblInspectionId = (Label)row.FindControl("LblInspectionId");
        //                string InspectionId = LblInspectionId.Text;

        //                if (fileUpload.HasFile)
        //                {
        //                    string CreatedBy = CreatedByy;
        //                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")
        //                    {
        //                        if (fileUpload.PostedFile.ContentLength <= 1048576)
        //                        {
        //                            string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);
        //                            string directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
        //                            if (!Directory.Exists(directoryPath))
        //                            {
        //                                Directory.CreateDirectory(directoryPath);
        //                            }

        //                            string ext = Path.GetExtension(fileUpload.PostedFile.FileName).ToLower();
        //                            string ext = ".pdf";
        //                            string fileName = $"{DocSaveName}{ext}";
        //                            string filePath = Path.Combine(directoryPath, fileName);
        //                            fileUpload.PostedFile.SaveAs(filePath);

        //                            string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName}";
        //                            uploadedFiles.Add((InspectionId, CartId, Categary, DocumentId, DocName, fileName, virtualPath));
        //                            string fileName = DocSaveName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
        //                            string filePath = Path.Combine(directoryPath, fileName);
        //                            fileUpload.PostedFile.SaveAs(filePath);

        //                            string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName}";
        //                            uploadedFiles.Add((InspectionId, CartID, Categary, DocumentId, DocName, fileName, virtualPath));
        //                        }
        //                        else
        //                        {
        //                            throw new Exception("Please Upload Pdf Files Less Than 1 MB Only");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Please Upload Pdf Files Only");
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (GridViewRow row in GridView2.Rows)
        //            {
        //                FileUpload fileUpload2 = (FileUpload)row.FindControl("FileUpload2");
        //                Label lblDocumentName2 = (Label)row.FindControl("lblDocumentName2");
        //                string DocSaveName2 = lblDocumentName2.Text;
        //                string DocName2 = lblDocumentName2.Text;

        //                string DocumentId = string.Empty;
        //                switch (DocName2)
        //                {
        //                    case "Previous Inspection Report":
        //                        DocumentId = "9";
        //                        break;
        //                    case "Treasury Challan":
        //                        DocumentId = "17";
        //                        break;
        //                    case "Other Document":
        //                        DocumentId = "14";
        //                        break;
        //                    default:
        //                        DocumentId = string.Empty;
        //                        break;
        //                }

        //                string TypeOfInspection = string.Empty;
        //                string CartId = IdCart;

        //                Label LblInstallationType = (Label)row.FindControl("LblInstallationType2");
        //                string InstallTypes = LblInstallationType.Text;

        //                Label LblCategory = (Label)row.FindControl("LblCategory2");
        //                string Categary = LblInstallationType.Text;
        //                Label LblInspectionId = (Label)row.FindControl("LblInspectionId2");
        //                string InspectionId = LblInspectionId.Text;

        //                if (fileUpload2.HasFile)
        //                {
        //                    string CreatedBy = CreatedByy;
        //                    if (Path.GetExtension(fileUpload2.FileName).ToLower() == ".pdf")
        //                    {
        //                        if (fileUpload2.PostedFile.ContentLength <= 1048576)
        //                        {
        //                            string FileName = Path.GetFileName(fileUpload2.PostedFile.FileName);

        //                            string directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
        //                            if (!Directory.Exists(directoryPath))
        //                            {
        //                                Directory.CreateDirectory(directoryPath);
        //                            }

        //                            string fileName2 = DocSaveName2 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

        //                            string filePath2 = Path.Combine(directoryPath, fileName2);
        //                            fileUpload2.PostedFile.SaveAs(filePath2);

        //                            string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName2}";
        //                            uploadedFiles.Add((InspectionId, CartID, Categary, DocumentId, DocName2, fileName2, virtualPath));
        //                        }
        //                        else
        //                        {
        //                            throw new Exception("Please Upload Pdf Files Less Than 1 MB Only");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Please Upload Pdf Files Only");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)

        //    {
        //        Response.Write(ex.Message);
        //    }
        //}
        public void UploadCheckListDocInCollection(string CreatedByy, int check_para, string CartID)
        {
            try
            {
                if (check_para == 0)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName");
                        string DocSaveName = lblDocumentName.Text;
                        string DocName = lblDocumentName.Text;

                        string DocumentId = string.Empty;
                        switch (DocName)
                        {
                            case "Previous Inspection Report":
                                DocumentId = "9";
                                break;
                            case "Treasury Challan":
                                DocumentId = "17";
                                break;
                            case "Other Document":
                                DocumentId = "14";
                                break;
                            default:
                                DocumentId = string.Empty;
                                break;
                        }

                        Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                        string InstallTypes = LblInstallationType.Text;

                        //Label LblCategory = (Label)row.FindControl("LblCategory");
                        string Categary = LblInstallationType.Text;
                        Label LblInspectionId = (Label)row.FindControl("LblInspectionId");
                        string InspectionId = LblInspectionId.Text;

                        if (fileUpload.HasFile)
                        {
                            string CreatedBy = CreatedByy;
                            if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")
                            {
                                if (fileUpload.PostedFile.ContentLength <= 1048576)
                                {
                                    string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);

                                    //string directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
                                    string directoryPath;
                                    if (DocName == "Treasury Challan" || DocName == "Other Document")
                                    {
                                        directoryPath = Server.MapPath($"~/Attachment/SiteOwner/{CreatedBy}/");
                                    }
                                    else
                                    {
                                        directoryPath = Server.MapPath($"~/Attachment/SiteOwner/{CreatedBy}/{InstallTypes}/");
                                    }

                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    // string ext = Path.GetExtension(fileUpload.PostedFile.FileName).ToLower();
                                    //string ext = ".pdf";
                                    //string fileName = $"{DocSaveName}{ext}";
                                    string fileName = DocSaveName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                    string filePath = Path.Combine(directoryPath, fileName);
                                    fileUpload.PostedFile.SaveAs(filePath);

                                    //string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName}";
                                    string virtualPath;
                                    if (DocName == "Treasury Challan" || DocName == "Other Document")
                                    {
                                        virtualPath = $"/Attachment/SiteOwner/{CreatedBy}/{fileName}";
                                    }
                                    else
                                    {
                                        virtualPath = $"/Attachment/SiteOwner/{CreatedBy}/{InstallTypes}/{fileName}";
                                    }

                                    uploadedFiles.Add((InspectionId, CartID, Categary, DocumentId, DocName, fileName, virtualPath));
                                }
                                else
                                {
                                    throw new Exception("Please Upload Pdf Files Less Than 1 MB Only");
                                }
                            }
                            else
                            {
                                throw new Exception("Please Upload Pdf Files Only");
                            }
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow row in GridView2.Rows)
                    {
                        FileUpload fileUpload2 = (FileUpload)row.FindControl("FileUpload2");
                        Label lblDocumentName2 = (Label)row.FindControl("lblDocumentName2");
                        string DocSaveName2 = lblDocumentName2.Text;
                        string DocName2 = lblDocumentName2.Text;

                        string DocumentId = string.Empty;
                        switch (DocName2)
                        {
                            case "Previous Inspection Report":
                                DocumentId = "9";
                                break;
                            case "Treasury Challan":
                                DocumentId = "17";
                                break;
                            case "Other Document":
                                DocumentId = "14";
                                break;
                            default:
                                DocumentId = string.Empty;
                                break;
                        }

                        Label LblInstallationType = (Label)row.FindControl("LblInstallationType2");
                        string InstallTypes = LblInstallationType.Text;

                        //Label LblCategory = (Label)row.FindControl("LblCategory2");
                        string Categary = LblInstallationType.Text;
                        Label LblInspectionId = (Label)row.FindControl("LblInspectionId2");
                        string InspectionId = LblInspectionId.Text;

                        if (fileUpload2.HasFile)
                        {
                            string CreatedBy = CreatedByy;
                            if (Path.GetExtension(fileUpload2.FileName).ToLower() == ".pdf")
                            {
                                if (fileUpload2.PostedFile.ContentLength <= 1048576)
                                {
                                    string FileName = Path.GetFileName(fileUpload2.PostedFile.FileName);

                                    //string directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
                                    string directoryPath;
                                    if (DocName2 == "Treasury Challan" || DocName2 == "Other Document")
                                    {
                                       // directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/");
                                        directoryPath = Server.MapPath($"~/Attachment/SiteOwner/{CreatedBy}/");
                                    }
                                    else
                                    {
                                        //directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
                                        directoryPath = Server.MapPath($"~/Attachment/SiteOwner/{CreatedBy}/{InstallTypes}/");

                                    }

                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    //string ext = Path.GetExtension(fileUpload2.PostedFile.FileName).ToLower();
                                    //string fileName2 = $"{DocSaveName2}{ext}";
                                    string fileName2 = DocSaveName2 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                                    string filePath2 = Path.Combine(directoryPath, fileName2);
                                    fileUpload2.PostedFile.SaveAs(filePath2);

                                    //string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName2}";
                                    string virtualPath;
                                    if (DocName2 == "Treasury Challan" || DocName2 == "Other Document")
                                    {
                                        virtualPath = $"/Attachment/SiteOwner/{CreatedBy}/{fileName2}";
                                    }
                                    else
                                    {
                                        virtualPath = $"/Attachment/SiteOwner/{CreatedBy}/{InstallTypes}/{fileName2}";
                                    }

                                    uploadedFiles.Add((InspectionId, CartID, Categary, DocumentId, DocName2, fileName2, virtualPath));
                                }
                                else
                                {
                                    throw new Exception("Please Upload Pdf Files Less Than 1 MB Only");
                                }
                            }
                            else
                            {
                                throw new Exception("Please Upload Pdf Files Only");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                Response.Write(ex.Message);
            }
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (NewInspectionId == null)
        //        {
        //            LinkButton LnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
        //            string commandArgument = LnkDocumemtPath.CommandArgument;
        //            if (string.IsNullOrEmpty(commandArgument))
        //            {
        //                // Get the index of the column containing the LinkButton
        //                int columnIndex = GetColumnIndexByHeaderText(GridView1, "Uploaded Documents");
        //                // Hide the column containing the LinkButton
        //                e.Row.Cells[columnIndex].Visible = false;
        //                // Find and hide the header cell of the column
        //                GridViewRow headerRow = GridView1.HeaderRow;
        //                if (headerRow != null && headerRow.Cells.Count > columnIndex)
        //                {
        //                    headerRow.Cells[columnIndex].Visible = false;
        //                }
        //            }
        //        }
        //        //this code will work in case of already uploaded documents
        //        if (NewInspectionId != null)
        //        {
        //            LinkButton LnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
        //            string commandArgument1 = LnkDocumemtPath.CommandArgument;
        //            if (string.IsNullOrEmpty(commandArgument1))
        //            {
        //                // Disable the LinkButton
        //                LnkDocumemtPath.Enabled = false;
        //            }
        //        }
        //    }
        //}
        //private int GetColumnIndexByHeaderText(GridView gridView1, string headerText)
        //{
        //    for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
        //    {
        //        if (GridView1.HeaderRow.Cells[i].Text == headerText)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected bool CheckAttachment(int check_para)
        {
            int Flag = 0;
            if (check_para == 0)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label DocName = (Label)row.FindControl("lblDocumentName");
                    if (DocName.Text != "Other Document")
                    {
                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                        if (fileUpload == null || !fileUpload.HasFile)
                        {
                            Flag = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (GridViewRow row in GridView2.Rows)
                {
                    Label DocName = (Label)row.FindControl("lblDocumentName2");
                    if (DocName.Text != "Other Document")
                    {
                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload2");
                        if (fileUpload == null || !fileUpload.HasFile)
                        {
                            Flag = 1;
                            break;
                        }
                    }
                }
            }

            if (Flag == 0)
                return true;
            else
                return false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ClickCount = 0;
            ClickCount = Convert.ToInt32(Session["ClickCount"]);
            if (ClickCount < 1)
            {

                int checksuccessmessage = 0;
                int NewPara = 0;

                if (HF_para_InspectID.Value != null && HF_para_InspectID.Value != "")
                {
                    NewPara = Convert.ToInt32(HF_para_InspectID.Value);
                }
                if (hfOwner.Value == Convert.ToString(Session["SiteOwnerId_Industry"]))
                {
                    if (Check.Checked == true)
                    {
                        if (CheckAttachment(NewPara))
                        {
                            try
                            {
                                /// Added By Aslam to Check Attachment type which was missing not handled earlier was submiting first correct attachment.
                                //16 apl 2025 

                                if (NewPara == 0)
                                {
                                    foreach (GridViewRow row in GridView1.Rows)
                                    {
                                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName");

                                        if (lblDocumentName != null && lblDocumentName.Text.Trim() == "Other Document")
                                        {
                                            if (fileUpload != null && fileUpload.HasFile)
                                            {
                                                ValidatePdfFile(fileUpload);
                                            }
                                        }
                                        else
                                        {
                                            ValidatePdfFile(fileUpload);
                                        }

                                    }
                                }
                                else
                                {
                                    foreach (GridViewRow row in GridView2.Rows)
                                    {
                                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload2");
                                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName2");

                                        if (lblDocumentName != null && lblDocumentName.Text.Trim() == "Other Document")
                                        {
                                            if (fileUpload != null && fileUpload.HasFile)
                                            {
                                                ValidatePdfFile(fileUpload);
                                            }
                                        }
                                        else
                                        {
                                            ValidatePdfFile(fileUpload);
                                        }
                                    }
                                }

                                /// Added By Aslam to Check Attachment type which was missing not handled earlier was submiting first correct attachment.
                                //16 apl 2025 
                                ///



                                bool isValid1 = true;
                                bool isValid2 = true;
                                string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
                                if (serverStatus != "Server is reachable.")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                                    return;
                                }

                                if (!string.IsNullOrEmpty(Convert.ToString(Session["IDCart_Industry"])))
                                {
                                    CartID = Convert.ToString(Session["IDCart_Industry"]);
                                }
                                else
                                {
                                    CartID = Convert.ToString(Session["CartID_Industry"]);
                                }
                                if (CartID == null || CartID == "")
                                {
                                    isValid1 = false;
                                }

                                if (isValid1 == true)
                                {

                                    ClickCount = ClickCount + 1;
                                    Session["ClickCount"] = ClickCount;
                                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                                    {
                                        SqlTransaction transaction = null;
                                        try
                                        {
                                            connection.Open();
                                            string para_CreatedByy = Session["SiteOwnerId_Industry"].ToString();
                                            string transcationId = string.Empty;
                                            string TranscationDate = string.Empty;
                                            /* int para_InspectID = 0; */   //////////
                                                                            //string TransactionId = txtTransactionId.Text;
                                                                            //string TransctionDate = txtTransactiondate.Text;
                                            if (txtTransactionId.Text != "")
                                            {
                                                transcationId = txtTransactionId.Text.Trim();
                                                TranscationDate = string.IsNullOrEmpty(txtTransactiondate.Text) ? null : txtTransactiondate.Text;
                                            }
                                            else
                                            {
                                                txtTransactiondate.Focus();
                                                txtTransactionId.Focus();
                                                return;
                                            }

                                            //string NewInspID = 
                                            transaction = connection.BeginTransaction();

                                            CEI.InsertPeriodicInspectionData_Industries("Periodic", CartID, transcationId, TranscationDate,
                                                               para_CreatedByy, NewPara, transaction);

                                            //IntimationId, ApplicantType,
                                            //            InstallationType, VoltageLevel, District, Division, AssignTo,
                                            //               PaymentMode, Amount, Capacity, Voltage,


                                            UploadCheckListDocInCollection(para_CreatedByy, NewPara, CartID);
                                            generatedIdCombinedDetails = CEI.InspectionId();
                                            if (uploadedFiles != null && uploadedFiles.Count > 0)
                                            {
                                                if (generatedIdCombinedDetails != "")
                                                {
                                                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                                                    //using (SqlConnection connection = new SqlConnection(connectionString))
                                                    //{
                                                    //connection.Open();
                                                    //string generatedIdCombiedDetails = CEI.InspectionId();  
                                                    foreach (var file in uploadedFiles)
                                                    {
                                                        string query = "sp_InsertInspectionAttachmentsForPeriodic_Industries";

                                                        using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
                                                        {
                                                            command.CommandType = CommandType.StoredProcedure;
                                                            command.Parameters.AddWithValue("@InspectionId", generatedIdCombinedDetails);
                                                            command.Parameters.AddWithValue("@CartId", file.CartId);
                                                            command.Parameters.AddWithValue("@InstallationType", file.Installtypes);
                                                            command.Parameters.AddWithValue("@DocumentID", file.DocumentId);
                                                            command.Parameters.AddWithValue("@DocSaveName", file.DocSaveName);
                                                            command.Parameters.AddWithValue("@FileName", file.FileName);
                                                            command.Parameters.AddWithValue("@FilePath", file.FilePath);
                                                            command.Parameters.AddWithValue("@CreatedBy", para_CreatedByy);
                                                            command.ExecuteNonQuery();
                                                        }
                                                    }
                                                    //}
                                                }
                                                else
                                                {
                                                    //string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                                                    //using (SqlConnection connection = new SqlConnection(connectionString))
                                                    //{
                                                    //connection.Open();
                                                    //string generatedIdCombinedDetails = CEI.InspectionId();
                                                    foreach (var file in uploadedFiles)
                                                    {
                                                        string query = "sp_InsertInspectionAttachmentsForPeriodic_Industries";

                                                        using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
                                                        {
                                                            command.CommandType = CommandType.StoredProcedure;
                                                            command.Parameters.AddWithValue("@InspectionId", file.InspectionId);
                                                            command.Parameters.AddWithValue("@CartId", file.CartId);
                                                            command.Parameters.AddWithValue("@InstallationType", file.Installtypes);
                                                            command.Parameters.AddWithValue("@DocumentID", file.DocumentId);
                                                            command.Parameters.AddWithValue("@DocSaveName", file.DocSaveName);
                                                            command.Parameters.AddWithValue("@FileName", file.FileName);
                                                            command.Parameters.AddWithValue("@FilePath", file.FilePath);
                                                            command.Parameters.AddWithValue("@CreatedBy", para_CreatedByy);
                                                            command.ExecuteNonQuery();
                                                        }
                                                    }
                                                    //}
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Upload Pdf Files.');", true);
                                                return;
                                                //throw new Exception("Please Upload Pdf Files");
                                            }

                                            transaction.Commit();
                                            Session["CartID_Industry"] = string.Empty;
                                            checksuccessmessage = 1;
                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Submitted Successfully !!!'); window.location='/Industry_Master/InspectionHistory_Industry.aspx';", true);
                                            Session["ServiceType"] = string.Empty;
                                            // Response.Redirect("/SiteOwnerPages/InspectionRenewalCart.aspx", false);
                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Submitted Successfully !!!'); window.location='/Industry_Master/InspectionHistory_Industry.aspx';", true);
                                        }
                                        catch (Exception ex)
                                        {
                                            transaction?.Rollback();
                                            string errorMessage = ex.Message.Replace("'", "\\'");
                                            ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                                            return;
                                        }
                                        finally
                                        {
                                            transaction?.Dispose();
                                            connection.Close();
                                        }

                                        try
                                        {

                                            // string actiontype = AcceptorReturn == "Accepted" ? "InProgress" : "Return";
                                            //commented on 10 nov 2024 aslam 
                                            //Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(generatedIdCombinedDetails), "Submit");
                                            List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(generatedIdCombinedDetails), "Submit", Session["projectid_pd_Indus"].ToString(), Session["Serviceid_pd_Indus"].ToString(), Session["SiteOwnerId_Industry"].ToString());
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
                                                                      commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                                                      comments = ApiPostformatresult.Comments,
                                                                      id = ApiPostformatresult.Id,
                                                                      projectid = ApiPostformatresult.ProjectId,
                                                                      serviceid = ApiPostformatresult.ServiceId
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
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                                            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
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

                                            string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);

                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                                        }

                                        catch (Exception ex)
                                        {
                                            // Rollback the transaction if an error occurs
                                            //transaction.Rollback();
                                            // Handle the exception, log it, etc.
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An error occurred.');", true);
                                        }

                                        finally
                                        {

                                            if (checksuccessmessage == 1)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Submitted Successfully !!!'); window.location='InspectionHistory_Industry.aspx'", true);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // Display error message
                                    Response.Write("<script>alert('Please select a file to upload.');</script>");
                                }

                            }
                            catch (Exception ex)
                            {
                                //string message = "alert(Error :'" + ex.Message + "')";
                                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                //Commented by Aslam on 16 apl 2025 because alert was not showing when i added my function and returned the message.
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Please upload mandatory files.');</script>");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                    }
                }
                else
                {
                    Session["SiteOwnerId_Industry"] = "";
                    Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='InspectionHistory_Industry.aspx'", true);
            }
        }

        private void ValidatePdfFile(FileUpload fileUpload)
        {

            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            if (fileExtension != ".pdf")
            {
                throw new Exception("Please upload PDF files only.");
            }

            if (fileUpload.PostedFile.ContentLength > 1048576)
            {
                throw new Exception("Please upload PDF files less than 1 MB only.");
            }
        }
    }
}