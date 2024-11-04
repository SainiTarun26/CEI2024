using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class InProcessRenewal_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        List<(string InspectionId, string CartId, string Installtypes, string DocumentId, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string, string, string)>();
        private static string IdCart, Voltage, Capacity, TestRportId, IntimationId, InstallationType, VoltageLevel, ApplicantType, District, Division, AssignTo, PaymentMode, Amount, NewInspectionId, type, inspectionCountRes, inspectionIdRes;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        //Session["SiteOwnerId"] = "JVCBN5647K";
                        string CartID = Session["CartID"].ToString();
                        DataSet ds = new DataSet();
                        ds = CEI.GetPeriodicType(CartID);
                        type = ds.Tables[0].Rows[0]["InspectionStatus"].ToString();
                        NewInspectionId = ds.Tables[0].Rows[0]["NewInspectionId"].ToString();
                        if (type != "Returned" && type != null)
                        {
                            getInspectionData();
                        }
                        else
                        {
                            GetInspectionDataIfPeriodicExist();
                            // CEI.GetDocumentsforPeriodicIfExist(NewInspectionId);
                        }
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int NewPara = 0;
            try
            {
                if (Session["SiteOwnerId"] != null)
                {

                    if (HF_para_InspectID.Value != null && HF_para_InspectID.Value != "")
                    {
                        NewPara = Convert.ToInt32(HF_para_InspectID.Value);
                    }

                    bool isValid = true;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                        if (fileUpload != null && !fileUpload.HasFile)
                        {
                            isValid = false;
                            // Add any additional logic here (e.g., display error message)
                            break;
                        }
                    }


                    if (isValid)
                    {
                        string para_CreatedByy = Session["SiteOwnerId"].ToString();

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
                        CEI.InsertPeriodicInspectionData_Industry("Periodic", IdCart, IntimationId, ApplicantType,
                                        InstallationType, VoltageLevel, District, Division, AssignTo,
                                           PaymentMode, Amount, transcationId, TranscationDate,
                                          para_CreatedByy, Capacity, Voltage,"Industry", NewPara);

                        UploadCheckListDocInCollection(para_CreatedByy, NewPara);
                        string generatedIdCombinedDetails = CEI.InspectionId();
                        if (generatedIdCombinedDetails != "")
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                //string generatedIdCombinedDetails = CEI.InspectionId();
                                foreach (var file in uploadedFiles)
                                {
                                    string query = "sp_InsertInspectionAttachmentsForPeriodic";

                                    using (SqlCommand command = new SqlCommand(query, connection))
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
                            }
                        }
                        else
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                //string generatedIdCombinedDetails = CEI.InspectionId();
                                foreach (var file in uploadedFiles)
                                {
                                    string query = "sp_InsertInspectionAttachmentsForPeriodic";

                                    using (SqlCommand command = new SqlCommand(query, connection))
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
                            }
                        }

                        //Session["CartID"] = string.Empty;
                        string CartID = Session["CartID"].ToString();
                        Response.Redirect("/Periodic_Industry/ViewPerodicRequest.aspx", false);
                    }
                    else
                    {
                        // Display error message
                        Response.Write("<script>alert('Please select a file to upload.');</script>");
                    }
                }
            }
            catch (Exception ex)
            { }

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {

                    fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }

        int para_InspectID = 0;

      
        private void GetInspectionDataIfPeriodicExist()
        {
            try
            {
                string IdLogin = Session["SiteOwnerId"].ToString();
                string CartID = Session["CartID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetPeriodicdataAfterCart(CartID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Capacity = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                    Voltage = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                    Amount = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
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
                    AssignTo = ds.Tables[0].Rows[0]["ExistingAssignTo"].ToString();
                    PaymentMode = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
                    GetOtherDetails_ForReturnedInspection(NewInspectionId);

                    para_InspectID = Convert.ToInt32(ds.Tables[0].Rows[0]["InspectionCount"].ToString());
                    HF_para_InspectID.Value = para_InspectID.ToString();

                    //inspectionCountRes = ds.Tables[0].Rows[0]["InspectionCount"].ToString();
                    //inspectionIdRes = ds.Tables[0].Rows[0]["InspectionId"].ToString();


                    DataSet dsDetails = CEI.GetDocumentsforPeriodicIfExist(NewInspectionId);

                    if (dsDetails != null && dsDetails.Tables[0].Rows.Count > 0)
                    {
                        //AddFixedRows(dsDetails);
                        GridView2.DataSource = dsDetails;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void GetOtherDetails_ForReturnedInspection(string newInspectionId)
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
        private void getInspectionData()
        {
            try
            {
                string IdLogin = Session["SiteOwnerId"].ToString();
                string CartID = Session["CartID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetPeriodicdataAfterCart(CartID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Capacity = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                    Voltage = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                    Amount = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
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


                    DataSet dsDetails = CEI.GetDocumentforPeriodic(IdCart);

                    //NewInspectionId = dsDetails.Tables[0].Rows[0]["NewInspectionId"].ToString();
                    //if (NewInspectionId != null)
                    if (dsDetails != null && dsDetails.Tables[0].Rows.Count > 0)
                    {
                        AddFixedRows(dsDetails);
                        GridView1.DataSource = dsDetails;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }

                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void AddFixedRows(DataSet dsDetails)
        {
            try
            {
                DataTable dt = dsDetails.Tables[0];

                DataRow fixedRow1 = dt.NewRow();
                fixedRow1["DocumentName"] = "Tresury Challan";
                dt.Rows.Add(fixedRow1);

                DataRow fixedRow2 = dt.NewRow();
                fixedRow2["DocumentName"] = "Other Document";
                dt.Rows.Add(fixedRow2);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception Ex) { }
        }

        public void UploadCheckListDocInCollection(string CreatedByy, int check_para)
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
                                DocumentId = "19";
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

                        //string TypeOfInspection= string.Empty;
                        string CartId = IdCart;

                        Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                        string InstallTypes = LblInstallationType.Text;

                        Label LblCategory = (Label)row.FindControl("LblCategory");
                        string Categary = LblCategory.Text;
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

                                    string directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    string ext = Path.GetExtension(fileUpload.PostedFile.FileName).ToLower();
                                    string fileName = $"{DocSaveName}{ext}";
                                    string filePath = Path.Combine(directoryPath, fileName);
                                    fileUpload.PostedFile.SaveAs(filePath);

                                    string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName}";
                                    uploadedFiles.Add((InspectionId, CartId, Categary, DocumentId, DocName, fileName, virtualPath));
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
                                DocumentId = "19";
                                break;
                            case "Tresury Challan":
                                DocumentId = "17";
                                break;
                            case "Other Document":
                                DocumentId = "14";
                                break;
                            default:
                                DocumentId = string.Empty;
                                break;
                        }

                        //string TypeOfInspection= string.Empty;
                        string CartId = IdCart;

                        Label LblInstallationType = (Label)row.FindControl("LblInstallationType2");
                        string InstallTypes = LblInstallationType.Text;

                        Label LblCategory = (Label)row.FindControl("LblCategory2");
                        string Categary = LblCategory.Text;
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

                                    string directoryPath = Server.MapPath($"~/Attachment/{CreatedBy}/{InstallTypes}/");
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    string ext = Path.GetExtension(fileUpload2.PostedFile.FileName).ToLower();
                                    string fileName2 = $"{DocSaveName2}{ext}";
                                    string filePath2 = Path.Combine(directoryPath, fileName2);
                                    fileUpload2.PostedFile.SaveAs(filePath2);

                                    string virtualPath = $"/Attachment/{CreatedBy}/{InstallTypes}/{fileName2}";
                                    uploadedFiles.Add((InspectionId, CartId, Categary, DocumentId, DocName2, fileName2, virtualPath));
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
            catch (Exception ex) { }
        }
    }
}