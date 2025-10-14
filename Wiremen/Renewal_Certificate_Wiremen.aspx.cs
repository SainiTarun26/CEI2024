using CEI_PRoject;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Wiremen
{
    public partial class Renewal_Certificate_Wiremen : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string userID = "";
        string Category = "";
        //page created by kalpana 18-Aug-2025
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["SupervisorID"] = "EPH-5030";
            ////EPH-4929
            //Session["SupervisorID"] = "EPH-4929";
            //Category = "Supervisor";
            //userID = Session["SupervisorID"].ToString();
            ////Session["SupervisorID"] = "CPH-3188";
            //GetSupervisorDetails();

            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        Category = "Wireman";
                        userID = Session["WiremanId"].ToString();
                        HdnUserId.Value = userID;
                        HdnUserType.Value = "Wireman";
                        if (Convert.ToString(Session["Renwal"]).Trim()== "Yes")
                        {
                            GetRenewalData(userID);
                        }
                        ddlLoadBindState1();
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
                    Response.Redirect("/Wiremen/RenewalHistoryWireman.aspx", false);
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
            txtaddress.Text = dt.Rows[0]["FullAddress"].ToString();
            txtAddressNew.Text=dt.Rows[0]["Address"].ToString();
            ddlState1.SelectedItem.Text=dt.Rows[0]["State"].ToString();
            ddlLoadBindDistrict1(ddlState1.SelectedItem.Text.ToString());
            ddlDistrict1.SelectedItem.Text=dt.Rows[0]["District"].ToString();
            txtPincodeNew.Text=dt.Rows[0]["PinCode"].ToString();
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
                if (chkDeclaration.Checked == true && chkdeclaration2.Checked == true)
                {
                    if (txtcertificatenoOLD.Text == txtcertificatenoNEW.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Old Certificate Number and New Certificate Number cannot be the same');", true);
                        return;
                    }
                    else
                    {
                        string CreatedBy = HdnUserId.Value;
                        string MedicalFitnessfp = "";
                        int maxFileSize = 1024 * 1024; // 1MB
                        bool isAllFilesValid = true;

                        // Save files with proper validation
                        string CertificateofCompetency = SaveFile(Certificate.PostedFile, "Certificate", "Certificate", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string PresentworkingStatusfp = SaveFile(PresentworkingStatus.PostedFile, "WorkStatus", "WorkStatus", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Undertakingfp = SaveFile(Undertaking.PostedFile, "Undertaking", "Undertaking", CreatedBy, maxFileSize, ref isAllFilesValid);

                        if (MedicalCertificate.Visible)
                        {
                            MedicalFitnessfp = SaveFile(MedicalFitness.PostedFile, "Medical", "Medical", CreatedBy, maxFileSize, ref isAllFilesValid);
                        }

                        string Challanfp = SaveFile(Challan.PostedFile, "Challan", "Challan", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Candidateimage = SaveFile(CandidateImage.PostedFile, "Candidate Image", "Candidate Image", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Candidatesignature = SaveFile(CandidateSignature.PostedFile, "Candidate Signature", "Candidate Signature", CreatedBy, maxFileSize, ref isAllFilesValid);

                        // Check if any file is invalid
                        if (!isAllFilesValid)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                                "alert('Only PDF or Image files (.jpg, .jpeg, .png) less than 1MB are allowed.');", true);
                            return;
                        }


                        //DateTime Dateturn55 = DateTime.ParseExact("21-05-2003", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        bool check = CEI.CheckIfRenewalApplicationExist(CreatedBy);
                        if (check)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('You have already submitted a renewal application.')", true);
                            return;

                        }
                        else
                        {
                            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                            {
                                SqlTransaction tran = null;
                                try
                                {
                                    con.Open();
                                    tran = con.BeginTransaction();

                                    CEI.InsertRenewalData(con, tran, HdnUserType.Value, txtDOB.Text.Trim(),
                                         txtage.Text.Trim(), DateTime.TryParse(txtage55?.Text, out var dt55) ? dt55 : (DateTime)SqlDateTime.Null, txtFatherName.Text.Trim(), txtaadharno.Text.Trim(),
                                          txtPhone.Text.Trim(), txtEmail.Text.Trim(),
                                         txtcertificatenoNEW.Text.Trim(), txtcertificatenoOLD.Text.Trim(),
                                         rblbelated.Text.ToString(), txtdays.Text.Trim(),
                                           rblChangeAddress.SelectedItem?.ToString() ?? string.Empty, txtAddressNew?.Text ?? string.Empty, ddlState1.SelectedItem?.ToString() ?? string.Empty,
                                            ddlDistrict1.SelectedItem?.ToString() ?? string.Empty, txtPincodeNew?.Text ?? string.Empty, ddlRenewalTime.SelectedItem.ToString(),
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

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Documents Added Successfully !!!')", true);
                                    Response.Redirect("/Wiremen/RenewalHistoryWireman.aspx", false);
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
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Unexpected error occurred.')", true);
            }
        }
        private string SaveFile(HttpPostedFile file, string folderName, string prefix, string createdBy, int maxFileSize, ref bool isValid)
        {
            if (file == null || file.ContentLength == 0)
                return null;

            string ext = Path.GetExtension(file.FileName).ToLower();
            bool isFileValid = false;

            // Check if folder is for images
            if (folderName.Equals("Candidate Image", StringComparison.OrdinalIgnoreCase) ||
                folderName.Equals("Candidate Signature", StringComparison.OrdinalIgnoreCase) )
            {
                isFileValid = IsValidPhoto(file);
            }
            else
            {
                // PDF validation
                isFileValid = ValidatePdfFile(file);
            }

            if (!isFileValid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('{prefix} has invalid format or exceeds 1MB.');", true);
                isValid = false;
                return null;
            }

            // Set folder path
            string path = $"/Attachment/Renewal/{createdBy}/{folderName}/";
            string directoryPath = HttpContext.Current.Server.MapPath("~" + path);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            // Generate unique file name
            string fileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";
            string filePath = Path.Combine(directoryPath, fileName);

            // Save file
            file.SaveAs(filePath);

            return path + fileName;
        }


        private bool IsValidPhoto(HttpPostedFile file)
        {
            string ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png") return false;

            if (file.ContentLength > 1048576) return false; // 1MB
            return true;
        }


        private bool ValidatePdfFile(HttpPostedFile file)
        {
            string ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".pdf") return false;

            if (file.ContentLength > 1048576) return false; // 1MB
            return true;
        }

        //private string SaveFile(HttpPostedFile file, string folderName, string prefix, string createdBy, int maxFileSize)
        //{
        //    if (file == null || file.ContentLength == 0)
        //        return null;

        //    // Validate file size
        //    if (file.ContentLength > maxFileSize)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
        //            $"alert('{prefix} must be less than {maxFileSize / 1024 / 1024}MB.')", true);
        //        return null;
        //    }

        //    string ext = Path.GetExtension(file.FileName).ToLower();

        //    // Allow only pdf, jpg, jpeg, png
        //    if (ext != ".pdf" && ext != ".jpg" && ext != ".jpeg" && ext != ".png")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
        //            $"alert('{prefix} must be a PDF or an Image file (.jpg, .jpeg, .png).')", true);
        //        return null;
        //    }

        //    // Set folder path
        //    string path = $"/Attachment/Renewal/{createdBy}/{folderName}/";
        //    string directoryPath = HttpContext.Current.Server.MapPath("~" + path);
        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }

        //    // Generate unique file name
        //    string fileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";
        //    string filePath = Path.Combine(directoryPath, fileName);

        //    // Save file
        //    file.SaveAs(filePath);

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

        protected void rblChangeAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblChangeAddress.SelectedValue == "1")
            {
                NewAddress.Visible = true;
                NewState.Visible = true;
                NewDistrict.Visible = true;
                NewPincode.Visible = true;

            }
            else
            {
                NewAddress.Visible = false;
                NewState.Visible = false;
                NewDistrict.Visible = false;
                NewPincode.Visible = false;

                //txtAddressNew.Text = "";
                //ddlState1.SelectedIndex = 0;
                //ddlDistrict1.SelectedIndex = 0;
                //txtPincodeNew.Text = "";


            }
        }

        protected void ddlState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindDistrict1(ddlState1.SelectedItem.ToString());
        }

        private void ddlLoadBindDistrict1(string state)
        {
            DataSet dsDistrict = new DataSet();
            dsDistrict = CEI.GetddlDrawDistrict(state);
            ddlDistrict1.DataSource = dsDistrict;
            ddlDistrict1.DataTextField = "District";
            ddlDistrict1.DataValueField = "District";
            ddlDistrict1.DataBind();
            ddlDistrict1.Items.Insert(0, new ListItem("Select", "0"));
            dsDistrict.Clear();
        }
        private void ddlLoadBindState1()
        {
            DataSet dsState = new DataSet();
            dsState = CEI.GetddlDrawState();
            ddlState1.DataSource = dsState;
            ddlState1.DataTextField = "StateName";
            ddlState1.DataValueField = "StateID";
            ddlState1.DataBind();
            ddlState1.Items.Insert(0, new ListItem("Select", "0"));
            dsState.Clear();
        }
    }
}