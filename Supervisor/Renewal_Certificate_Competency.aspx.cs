using CEI_PRoject;
using iText.Forms.Form.Element;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class Renewal_Certificate_Competency : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string userID = "";
        string Category = "";
        //page created by kalpana 18-Aug-2025

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Renwal"]) != "" && Convert.ToString(Session["Renwal"]) != null)
            {
                this.Page.MasterPageFile = "~/Supervisor/Supervisor_Renewal.Master";

                Session["double_Clickbutton"] = "1";
            }
            else
            {
                this.Page.MasterPageFile = "~/Supervisor/Supervisor.Master";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {

                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        Category = "Supervisor";
                        userID = Session["SupervisorID"].ToString();
                        HdnUserId.Value = userID;
                        HdnUserType.Value = "Supervisor";
                        GetRenewalData(userID);
                        GetSupervisorDetails(userID);

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        public void GetRenewalData(string userID)
        {
            try
            {
                DataTable ds = new DataTable();

                ds = CEI.GetRenewalData(userID);
                if (ds.Rows.Count > 0)
                {
                    Response.Redirect("/Supervisor/RenewalHistory.aspx", false);
                }
                else
                {
                    return;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
        public void GetSupervisorDetails(string userID)
        {
            //string UserID = Session["SupervisorID"].ToString();
            DataTable dt = new DataTable();
            dt = CEI.GetSuperviserDetailsforRenewal(userID);
            txtname.Text = dt.Rows[0]["Name"].ToString();
            txtage.Text = dt.Rows[0]["Age"].ToString();
            string age = txtage.Text.ToString();
            int ageValue;
            if (int.TryParse(age, out ageValue))
            {
                if (ageValue >= 55)
                {
                    Ifage55.Visible = true;
                    MedicalCertificate.Visible = true;
                }
                else
                {
                    Ifage55.Visible = false;
                    MedicalCertificate.Visible = false;
                }
            }
            else
            {
                Ifage55.Visible = false;
            }

            txtage55.Text = dt.Rows[0]["DateTurned55"].ToString();
            txtaddress.Text = dt.Rows[0]["Address"].ToString();
            txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
            txtDOB.Text = dt.Rows[0]["DOB"].ToString();
            txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtcertificatenoNEW.Text = dt.Rows[0]["CertificateNew"].ToString();
            txtcertificatenoOLD.Text = dt.Rows[0]["CertificateOld"].ToString();
            txtexpirydate.Text = dt.Rows[0]["DateofExpiry"].ToString();
            txtDistrict.Text = dt.Rows[0]["District"].ToString();
            int belated = Convert.ToInt32(dt.Rows[0]["BelatedRenewal"]);
            if (belated == 1)
            {
                rblbelated.Text = "Yes";

                days.Visible = true;
            }
            else
            {
                rblbelated.Text = "No";
                days.Visible = false;
            }
            txtdays.Text = dt.Rows[0]["NoOfDays"].ToString();
            if (dt.Rows[0]["AnyContractor"].ToString() == "No")
            {
                NameContractor.Visible = false;
                LicensenContractor.Visible = false;
                AddressContractor.Visible = false;
            }
            else
            {

                NameContractor.Visible = true;
                LicensenContractor.Visible = true;
                AddressContractor.Visible = true;
                txtNameofEmployer.Text = dt.Rows[0]["ContractorName"].ToString();
                txtNameofEmployer.ReadOnly = true;
                txtLicenseno.Text = dt.Rows[0]["Licence"].ToString();
                txtLicenseno.ReadOnly = true;
                txtaddressofEmployer.Text = dt.Rows[0]["ContractorAddress"].ToString();
                txtaddressofEmployer.ReadOnly = true;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {


            try
            {
                if (Convert.ToString(Session["double_Clickbutton"]) == "1")
                {
                    if (chkDeclaration.Checked == true && chkdeclaration2.Checked == true)
                    {
                        string CreatedBy = HdnUserId.Value;
                        string MedicalFitnessfp = "";
                        int maxFileSize = 1024 * 1024; // 1MB

                        string CertificateofCompetency = SaveFile(Certificate.PostedFile, "Certificate", "Certificate", CreatedBy, maxFileSize);
                        string PresentworkingStatusfp = SaveFile(PresentworkingStatus.PostedFile, "WorkStatus", "WorkStatus", CreatedBy, maxFileSize);
                        string Undertakingfp = SaveFile(Undertaking.PostedFile, "Undertaking", "Undertaking", CreatedBy, maxFileSize);

                        if (MedicalCertificate.Visible == true)
                        {
                            MedicalFitnessfp = SaveFile(MedicalFitness.PostedFile, "Medical", "Medical", CreatedBy, maxFileSize);
                        }

                        string Challanfp = SaveFile(Challan.PostedFile, "Challan", "Challan", CreatedBy, maxFileSize);
                        string Candidateimage = SaveFile(CandidateImage.PostedFile, "Candidate Image", "Candidate Image", CreatedBy, maxFileSize);
                        string Candidatesignature = SaveFile(CandidateSignature.PostedFile, "Candidate Signature", "Candidate Signature", CreatedBy, maxFileSize);



                        // DateTime Dateturn55 = DateTime.ParseExact("21-05-2003", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        bool check = CEI.CheckIfRenewalApplicationExist(CreatedBy);
                        if (check)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('You have already submitted a renewal application.')", true);
                            Response.Redirect("/Supervisor/RenewalHistory.aspx", false);
                            return;

                        }
                        else
                        {
                            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                            {
                                con.Open();
                                SqlTransaction tran = con.BeginTransaction();

                                try
                                {

                                    CEI.InsertRenewalData(con, tran, HdnUserType.Value, txtDOB.Text.Trim(),
                                        txtage.Text.Trim(), DateTime.TryParse(txtage55?.Text, out var dt55) ? dt55 : (DateTime)SqlDateTime.Null, txtFatherName.Text.Trim(), txtaadharno.Text.Trim(),
                                         txtPhone.Text.Trim(), txtEmail.Text.Trim(),
                                        txtcertificatenoNEW.Text.Trim(), txtcertificatenoOLD.Text.Trim(),
                                        rblbelated.Text.ToString(), txtdays.Text.Trim(), ddlRenewalTime.SelectedItem.ToString(),
                                        txtamount.Text.Trim(), txtgrnno.Text.Trim(), txtdate.Text.Trim(), RadioButtonList1.SelectedItem.ToString(),
                                        CreatedBy);

                                    CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Certificate of Competency/Wireman Permit. ", CertificateofCompetency, 1, CreatedBy);
                                    CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Present Working Status", PresentworkingStatusfp, 1, CreatedBy);
                                    CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Undertaking for delay or non-working during cancel period, in case of expiry of the Certificate/Permit.", Undertakingfp, 1, CreatedBy);

                                    if (MedicalCertificate.Visible == true && !string.IsNullOrEmpty(MedicalFitnessfp))
                                    {
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Medical Fitness Certificate issued from Government/Government Approved Hospital", MedicalFitnessfp, 1, CreatedBy);
                                    }

                                    CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Deposited Treasury Challan of fees, for the purpose in the Head of A/c: 0043-51-800-99-51-Other Receipt.", Challanfp, 1, CreatedBy);


                                    CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Candidate Image", Candidateimage, 1, CreatedBy);


                                    CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Candidate Signature", Candidatesignature, 1, CreatedBy);


                                    tran.Commit();
                                    Session["double_Clickbutton"] = "";
                                    Session["double_Clickbutton"] = null;

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Added Successfully !!!')", true);
                                    Response.Redirect("/Supervisor/RenewalHistory.aspx", false);
                                    resetfeilds();
                                }
                                catch (Exception ex2)
                                {

                                    tran.Rollback();
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Transaction Failed. Please try again.')", true);
                                }
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Unexpected error occurred.')", true);
            }
        }

        private string SaveFile(HttpPostedFile file, string folderName, string prefix, string createdBy, int maxFileSize)
        {
            if (file == null || file.ContentLength == 0)
                return null;

            // Validate file size
            if (file.ContentLength > maxFileSize)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('{prefix} must be less than {maxFileSize / 1024 / 1024}MB.')", true);
                return null;
            }

            string ext = Path.GetExtension(file.FileName).ToLower();

            // Allow only pdf, jpg, jpeg, png
            if (ext != ".pdf" && ext != ".jpg" && ext != ".jpeg" && ext != ".png")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('{prefix} must be a PDF or an Image file (.jpg, .jpeg, .png).')", true);
                return null;
            }

            // Set folder path
            string path = $"/Attachment/Renewal/{createdBy}/{folderName}/";
            string directoryPath = HttpContext.Current.Server.MapPath("~" + path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Generate unique file name
            string fileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";
            string filePath = Path.Combine(directoryPath, fileName);

            // Save file
            file.SaveAs(filePath);

            return path + fileName;
        }


        //private string SavePdf(HttpPostedFile file, string folderName, string prefix, string createdBy, int maxFileSize)
        //{
        //    if (file == null || file.ContentLength == 0)
        //        return null;

        //    if (file.ContentLength > maxFileSize)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
        //            $"alert('{prefix} must be a PDF file with a maximum size of 1MB.')", true);
        //        return null;
        //    }

        //    string ext = Path.GetExtension(file.FileName).ToLower();
        //    if (ext != ".pdf")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
        //            $"alert('{prefix} must be a PDF file.')", true);
        //        return null;
        //    }

        //    // Build folder path
        //    string path = $"/Attachment/Renewal/{createdBy}/{folderName}/";
        //    string directoryPath = HttpContext.Current.Server.MapPath("~" + path);
        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }

        //    // Unique file name
        //    string fileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmssfff}.pdf";
        //    string filePath = Path.Combine(directoryPath, fileName);

        //    // Save file
        //    file.SaveAs(filePath);

        //    // Return relative path to save in DB
        //    return path + fileName;
        //}


        protected void ddlRenewalTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Category = HdnUserType.Value;
            int DaysDelay = int.TryParse(txtdays.Text, out var value) ? value : 0;


            string fees = CEI.RenewalFees(Category, DaysDelay, Convert.ToInt32(ddlRenewalTime.SelectedValue));
            txtamount.Text = fees;

        }
        protected void resetfeilds()
        {
            ddlRenewalTime.SelectedValue = "0";
            txtgrnno.Text = "";
            txtdate.Text = "";
            RadioButtonList1.SelectedIndex = -1;
            txtamount.Text = "";
            chkDeclaration.Checked = false;
            chkdeclaration2.Checked = false;
            txtaadharno.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

        }
    }
}
