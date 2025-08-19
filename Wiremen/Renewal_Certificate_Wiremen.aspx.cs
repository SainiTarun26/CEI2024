using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Ocsp;
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
                if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                {
                    Category = "Wireman";
                    userID = Session["WiremanId"].ToString();
                    GetSupervisorDetails(userID);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
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
                rblbelated.SelectedValue = "1";
                days.Visible = true;
            }
            else
            {
                rblbelated.SelectedValue = "0";
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
                    string CreatedBy = userID;
                    string FileName = string.Empty;
                    string MedicalFitnessfp = "";
                    int maxFileSize = 1024 * 1024; // 1MB in bytes
                    string CertificateofCompetency = SavePdf(Certificate.PostedFile, "Certificate", "Certificate", CreatedBy, maxFileSize);
                    string PresentworkingStatusfp = SavePdf(PresentworkingStatus.PostedFile, "WorkStatus", "WorkStatus", CreatedBy, maxFileSize);

                    string Undertakingfp = SavePdf(Undertaking.PostedFile, "Undertaking", "Undertaking", CreatedBy, maxFileSize);

                    if (MedicalCertificate.Visible == true)
                    {
                        MedicalFitnessfp = SavePdf(MedicalFitness.PostedFile, "Medical", "Medical", CreatedBy, maxFileSize);
                    }

                    string Challanfp = SavePdf(Challan.PostedFile, "Challan", "Challan", CreatedBy, maxFileSize);




                    string name = txtname.Text.ToString();
                    string DOB = txtDOB.Text.ToString();
                    string age = txtage.Text.ToString();
                    string Dateturn55 = "21-05-2003";
                    string FatherName = txtFatherName.Text.ToString();
                    string AadharNo = txtaadharno.Text.ToString();
                    string PhoneNo = txtPhone.Text.ToString();
                    string Email = txtEmail.Text.ToString();
                    string District = txtDistrict.Text.ToString();
                    string Address = txtaddress.Text.ToString();
                    string LicenceNew = txtcertificatenoNEW.Text.ToString();
                    string LicenceOld = txtcertificatenoOLD.Text.ToString();
                    string RenewalTime = ddlRenewalTime.SelectedItem.ToString();
                    string amount = txtamount.Text.ToString();
                    string GRNno = txtgrnno.Text.ToString();
                    string ChallanDate = txtdate.Text.ToString();
                    string changeofemployer = RadioButtonList1.SelectedItem.ToString();


                    CEI.InsertRenewalData(Category, name, DOB, age, Dateturn55, FatherName, AadharNo, District, Address, PhoneNo, Email, LicenceNew, LicenceOld, RenewalTime, amount, GRNno, ChallanDate, changeofemployer, CreatedBy);

                    CEI.InsertRenewalDocuments(Category, "Certificate of Competency/Wireman Permit. ", CertificateofCompetency, 1, CreatedBy);
                    CEI.InsertRenewalDocuments(Category, "Present Working Status", PresentworkingStatusfp, 1, CreatedBy);
                    CEI.InsertRenewalDocuments(Category, "Undertaking for delay or non-working during cancel period, in case of expiry of the Certificate/Permit.", Undertakingfp, 1, CreatedBy);

                    if (MedicalCertificate.Visible == true && !string.IsNullOrEmpty(MedicalFitnessfp))
                    {
                        CEI.InsertRenewalDocuments(Category, "Medical Fitness Certificate issued from Government/Government Approved Hospital", MedicalFitnessfp, 1, CreatedBy);
                    }

                    CEI.InsertRenewalDocuments(Category, "Deposited Treasury Challan of fees, for the purpose in the Head of A/c: 0043-51-800-99-51-Other Receipt.", Challanfp, 1, CreatedBy);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Documents Added Successfully !!!')", true);
                    resetfeilds();


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private string SavePdf(HttpPostedFile file, string folderName, string prefix, string createdBy, int maxFileSize)
        {
            if (file == null || file.ContentLength == 0)
                return null;

            if (file.ContentLength > maxFileSize)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('{prefix} must be a PDF file with a maximum size of 1MB.')", true);
                return null;
            }

            string ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".pdf")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('{prefix} must be a PDF file.')", true);
                return null;
            }

            // Build folder path
            string path = $"/Attachment/Renewal/{createdBy}/{folderName}/";
            string directoryPath = HttpContext.Current.Server.MapPath("~" + path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Unique file name
            string fileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmssfff}.pdf";
            string filePath = Path.Combine(directoryPath, fileName);

            // Save file
            file.SaveAs(filePath);

            // Return relative path to save in DB
            return path + fileName;
        }


        protected void ddlRenewalTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRenewalTime.SelectedValue == "1")
            {
                txtamount.Text = "200";
            }
            else if (ddlRenewalTime.SelectedValue == "5")
            {
                txtamount.Text = "950";
            }
            else
            {
                txtamount.Text = " ";
            }
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